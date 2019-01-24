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
            [SerializeField] private bool _currentGenDisplay = true;

            [SerializeField] private Material _baseMaterial;

            [Space(12)]
            [SerializeField] private Material _fitnessMaterial;
            [SerializeField] private int _fitNumDisplay = 5;

            private PopulationManager _manager;
            private StackPopulation _population;
            private MaterialPropertyBlock _properties;

            private int _popSize = 0;
            private int _genSize = 0;

            private bool _displayChange = false;
            private bool _popDisplayChange = false;
            private bool _popIsUpdated = true;
            private bool _genIsUpdated = true;
            private bool _genDisplayChange = false;

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

            /// <summary>
            /// 
            /// </summary>
            public bool CurrentGenerationDisplay
            {
                get { return _currentGenDisplay; }
                set { _currentGenDisplay = value; }
            }

            /// <summary>
            /// 
            /// </summary>
            public bool DisplayChange
            {
                get { return _displayChange; }
                set { _displayChange = value; }
            }

            /// <summary>
            /// 
            /// </summary>
            public bool PopDisplayChange
            {
                get { return _popDisplayChange; }
                set { _popDisplayChange = value; }
            }

            /// <summary>
            /// 
            /// </summary>
            public bool GenDisplayChange
            {
                get { return _genDisplayChange; }
                set { _genDisplayChange = value; }
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
                if (_population.Population.Count != _popSize)
                {
                    _popSize = _population.Population.Count;
                    _popIsUpdated = false;
                }

                int genSize = _manager.CurrentGeneration.Count(s => s != null);

                if (genSize != _genSize)
                {
                    _genSize = genSize;
                    _genIsUpdated = false;
                }

                // update display
                if (_displayChange == true || _popDisplayChange == true || _popIsUpdated == false || _genDisplayChange == true || _genIsUpdated == false)
                {
                    UpdateDisplay();
                }

                _displayChange = false;
                _popDisplayChange = false;
                _genDisplayChange = false;
                _popIsUpdated = true;
                _genIsUpdated = true;
            }

            /// <summary>
            /// 
            /// </summary>
            private void UpdateDisplay()
            {
                if (_genDisplayChange == true || _genIsUpdated == false)
                {
                    if (_currentGenDisplay == true)
                    {
                        ShowGeneration();
                    }

                    else
                    {
                        HideGeneration();
                    }
                }

                //switch enable
                if (_popDisplayChange == true || _popIsUpdated == false)
                {
                    switch (_popDisplayMode)
                    {
                        case PopulationDisplayMode.None:
                            ShowNone();
                            break;

                        case PopulationDisplayMode.Fittest:
                            ShowFittest();
                            break;

                        case PopulationDisplayMode.All:
                            ShowAll();
                            break;

                        default:
                            break;
                    }
                }

                //switch color

                if (_displayChange == true || _popDisplayChange == true || _popIsUpdated == false)
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
                var generation = _manager.CurrentGeneration;
                if (generation[0] == null)
                {
                    return;
                }

                for (int i = 0; i < generation.Length; i++)
                {
                    if (generation[i] == null)
                    {
                        return;
                    }

                    var stack = generation[i];

                    if (stack.gameObject.active == false)
                    {
                        stack.gameObject.SetActive(true);
                        stack.UITextObj.SetActive(true);
                    }
                }
            }

            /// <summary>
            /// 
            /// </summary>
            private void HideGeneration()
            {
                var generation = _manager.CurrentGeneration;

                if (generation[0] == null)
                {
                    return;
                }

                for (int i = 0; i < generation.Length; i++)
                {
                    if (generation[i] == null)
                    {
                        return;
                    }
                    var stack = generation[i];

                    if (stack.gameObject.active == true)
                    {
                        stack.gameObject.SetActive(false);
                        stack.UITextObj.SetActive(false);
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

                //sort by fitness value (highest first - descending)
                var sortedList = population.OrderByDescending(o => (o.Fitness)).ToList();

                var selectedlist = new List<CellStack>();
                if (sortedList.Count <= _fitNumDisplay)
                {
                    selectedlist = sortedList;

                }

                if (sortedList.Count > _fitNumDisplay)
                {
                    selectedlist = sortedList.GetRange(0, _fitNumDisplay);
                }


                for (int i = 0; i < population.Count; i++)
                {
                    var stack = population[i];
                    float value = SlurMath.Normalize(stack.Fitness, _population.MinFitness, _population.MaxFitness);

                    if (selectedlist.Contains(stack) == true)
                    {
                        if (stack.gameObject.active == false)
                        {
                            stack.gameObject.SetActive(true);
                            stack.UITextObj.SetActive(true);

                        }
                    }

                    else
                    {
                        stack.gameObject.SetActive(false);
                        stack.UITextObj.SetActive(false);

                    }
                }
            }

            /// <summary>
            /// 
            /// </summary>
            private void ShowAll()
            {
                var population = _population.Population;
                for (int i = 0; i < population.Count; i++)
                {
                    var stack = population[i];
                    if (stack.gameObject.active == false)
                    {
                        stack.gameObject.SetActive(true);
                        stack.UITextObj.SetActive(true);

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
                        stack.UITextObj.SetActive(false);

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

            private void DisplayFitness()
            {
                const string propName = "_Value";
                var population = _population.Population;

                foreach (var stack in population)
                {

                    if (stack.gameObject.active == false)
                    {
                        continue;
                    }

                    // normalize fitness
                    float value = SlurMath.Normalize(stack.Fitness, _population.MinFitness, _population.MaxFitness);


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

            /*
            /// <summary>
            /// 
            /// </summary>
            private void DisplayFitness()
            {
                const string propName = "Value";
                var population = _population.Population;

                foreach (var stack in population)
                {

                    if (stack.gameObject.active == false)
                    {
                        continue;
                    }

                    // normalize fitness
                    float value = SlurMath.Normalize(stack.Fitness, _population.MinFitness, _population.MaxFitness);

                    if (stack.Fitness == _population.MinFitness)
                    {
                        value = .001f;
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
                            //renderer.GetPropertyBlock();
                            _properties = new MaterialPropertyBlock();
                            _properties.SetFloat(propName, value);
                            cell.Renderer.SetPropertyBlock(_properties);

                        }
                    }
                }
            }
            */
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
