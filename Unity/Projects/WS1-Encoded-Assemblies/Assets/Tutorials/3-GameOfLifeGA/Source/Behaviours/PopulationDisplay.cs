using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

using SpatialSlur;

namespace RC3
{
    namespace WS2
    {
        /// <summary>
        /// 
        /// </summary>
        [RequireComponent(typeof(PopulationManager))]
        public partial class PopulationDisplay : MonoBehaviour
        {

            [SerializeField] private CellDisplayMode _displayMode = CellDisplayMode.Alive;
            [SerializeField] private PopulationDisplayMode _popDisplayMode = PopulationDisplayMode.None;

            [SerializeField] private Material _baseMaterial;

            [Space(12)]
            [SerializeField] private Material _fitnessMaterial;
            [Range(0, 1)]
            [SerializeField] private float _fitnessCutoff = .9f;

            private PopulationManager _manager;
            private StackPopulation _population;
            private MaterialPropertyBlock _properties;

            /// <summary>
            /// 
            /// </summary>
            public CellDisplayMode DisplayMode
            {
                get { return _displayMode; }
                set
                {
                    if (_displayMode != value)
                        _displayMode = value;
                }
            }

            /// <summary>
            /// 
            /// </summary>
            public PopulationDisplayMode PopDisplayMode
            {
                get { return _popDisplayMode; }
                set
                {
                    if (_popDisplayMode != value)
                        _popDisplayMode = value;
                }
            }


            private bool _displayChange = false;
            private bool _popDisplayChange = false;

            public bool DisplayChange
            {
                get { return _displayChange; }
                set { _displayChange = value; }
            }
            public bool PopDisplayChange
            {
                get { return _popDisplayChange; }
                set { _popDisplayChange = value; }
            }

            /// <summary>
            /// 
            /// </summary>
            private void Start()
            {
                _manager = GetComponent<PopulationManager>();
                _population = _manager.Population;
                _properties = new MaterialPropertyBlock();
                ResetDisplay();
            }


            /// <summary>
            /// 
            /// </summary>
            private void LateUpdate()
            {
                // update display
                if (_displayChange == true || _popDisplayChange == true)
                {
                    UpdateDisplay();
                }
                _displayChange = false;
                _popDisplayChange = false;
            }


            /// <summary>
            /// 
            /// </summary>
            private void UpdateDisplay()
            {
                //switch enable
                if (_popDisplayChange == true)
                {
                    switch (_popDisplayMode)
                    {
                        case PopulationDisplayMode.None:
                            ShowNone();
                            break;

                        case PopulationDisplayMode.Generation:
                            ShowGeneration();
                            break;

                        case PopulationDisplayMode.Fittest:
                            ShowFittest();
                            break;

                        case PopulationDisplayMode.All:
                            ShowFittest();
                            break;

                        default:
                            break;
                    }
                }

                //switch color

                if (_displayChange == true || _popDisplayChange == true)
                {
                    if (_popDisplayMode == PopulationDisplayMode.None)
                    {
                        return;
                    }

                    switch (_displayMode)
                    {
                        case CellDisplayMode.Alive:
                            DisplayAlive();
                            break;

                        case CellDisplayMode.Fitness:
                            DisplayFitness();
                            break;

                        default:
                            DisplayAlive();
                            break;
                    }
                }

            }


            /// <summary>
            /// 
            /// </summary>
            private void ResetDisplay()
            {
            }

            /// <summary>
            /// 
            /// </summary>
            private void ShowGeneration()
            {
                const string propName = "_Value";
                var population = _population.Population;
                for (int i = 0; i < population.Count; i++)
                {
                    var stack = population[i];

                    if (i < population.Count - _manager.GenSize - 1)
                    {
                        if (stack.gameObject.active == true)
                        {
                            stack.gameObject.SetActive(false);
                        }
                    }

                    else
                    {
                        if (stack.gameObject.active == false)
                        {
                            stack.gameObject.SetActive(true);
                        }
                    }
                }
            }

            /// <summary>
            /// 
            /// </summary>
            private void ShowFittest()
            {
                const string propName = "_Value";
                var population = _population.Population;
                for (int i = 0; i < population.Count; i++)
                {
                    var stack = population[i];
                    float value = SlurMath.Normalize(stack.Fitness, _population.MinFitness, _population.MaxFitness);

                    if (value > _fitnessCutoff)
                    {
                        if (stack.gameObject.active == false)
                        {
                            stack.gameObject.SetActive(true);
                        }
                    }

                    else
                    {
                        if (stack.gameObject.active == true)
                        {
                            stack.gameObject.SetActive(false);
                        }
                    }
                }
            }

            /// <summary>
            /// 
            /// </summary>
            private void ShowAll()
            {
                const string propName = "_Value";
                var population = _population.Population;
                for (int i = 0; i < population.Count; i++)
                {
                    var stack = population[i];
                    if (stack.gameObject.active == false)
                    {
                        stack.gameObject.SetActive(true);
                    }
                }
            }

            /// <summary>
            /// 
            /// </summary>
            private void ShowNone()
            {
                const string propName = "_Value";
                var population = _population.Population;
                for (int i = 0; i < population.Count; i++)
                {
                    var stack = population[i];
                    if (stack.gameObject.active == true)
                    {
                        stack.gameObject.SetActive(false);
                    }
                }
            }



            /// <summary>
            /// 
            /// </summary>
            private void DisplayAlive()
            {
                var population = _population.Population;
                foreach (var stack in population)
                {
                    if (stack.gameObject.active == false)
                    {
                        continue;
                    }

                    foreach (var layer in stack.Layers)
                    {
                        foreach (var cell in layer.Cells)
                        {
                            // skip dead cells
                            if (cell.State == 0)
                                continue;

                            // update cell material
                            MeshRenderer renderer = cell.Renderer;
                            renderer.sharedMaterial = _baseMaterial;
                        }
                    }
                }
            }

            /// <summary>
            /// 
            /// </summary>
            private void DisplayFitness()
            {
                const string propName = "_Value";
                var population = _population.Population;
                foreach (var stack in population)
                {
                    // normalize fitness
                    float value = SlurMath.Normalize(stack.Fitness, _population.MinFitness, _population.MaxFitness);
                    if (stack.Fitness == _population.MaxFitness)
                    {
                        value = .999f;
                    }

                    if (stack.Fitness == _population.MinFitness)
                    {
                        value = .001f;
                    }

                    if (stack.gameObject.active == false)
                    {
                        continue;
                    }

                    foreach (var layer in stack.Layers)
                    {
                        foreach (var cell in layer.Cells)
                        {
                            // skip dead cells
                            if (cell.State == 0)
                                continue;

                            // update cell material
                            MeshRenderer renderer = cell.Renderer;
                            renderer.sharedMaterial = _fitnessMaterial;

                            // set material properties
                            {
                                renderer.GetPropertyBlock(_properties);
                                _properties.SetFloat(propName, value);
                                renderer.SetPropertyBlock(_properties);
                            }
                        }
                    }
                }
            }

            /// <summary>
            /// 
            /// </summary>
            /// <param name="i"></param>
            /// <param name="n"></param>
            /// <returns></returns>
            private static int Wrap(int i, int n)
            {
                i %= n;
                return (i < 0) ? i + n : i;
            }
        }
    }
}
