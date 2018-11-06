using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

using SpatialSlur;

namespace RC3
{
    /// <summary>
    /// 
    /// </summary>
    public class StackDisplay : MonoBehaviour
    {
        [SerializeField]
        private StackManager _stackManager;
        [SerializeField]
        private Material _material;

        private StackAnalyser _stackAnalyser;
        private DISPLAYMODE _displayMode = DISPLAYMODE.LiveCells;
        MaterialPropertyBlock _materialprops;
        bool _displayChanged = false;

        [SerializeField]
        Color _liveColor;

        [SerializeField]
        Color _ageColor;
        [SerializeField]
        int _ageVizMax;

        [SerializeField]
        Color _neighborhoodDensityColor;

        [SerializeField]
        Color _layerDensityColor;

        public void SetupDisplay()
        {
            _stackAnalyser = _stackManager.StackAnalyser;
            _materialprops = new MaterialPropertyBlock();
            SetupMaterials();
        }

        /// <summary>
        /// 
        /// </summary>
        private void SetupMaterials()
        {
            foreach (var layer in _stackManager.Layers)
            {
                foreach (var cell in layer.Cells)
                {
                    cell.Renderer.sharedMaterial = _material;

                }
            }
        }


        /// <summary>
        /// 
        /// </summary>
        private enum DISPLAYMODE
        {
            LiveCells,
            ColorAge,
            ColorMO3DDensity,
            ColorLayerDensity
        }


        /// <summary>
        /// 
        /// </summary>
        public StackManager StackManager
        {
            get { return _stackManager; }
        }

        /// <summary>
        /// 
        /// </summary>
        public StackAnalyser AnalysisManager
        {
            get { return _stackAnalyser; }
        }

        /// <summary>
        /// 
        /// </summary>
        public void UpdateDisplay()
        {
            //check all keypresses
            HandleKeyPress();

            if (_displayChanged == true)
            {
                ChangeDisplay();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        private void HandleKeyPress()
        {
            if (Input.GetKeyDown(KeyCode.Keypad0))
            {
                ChangeDisplay();
            }

            if (Input.GetKeyDown(KeyCode.Keypad1))
            {

                if ((int)_displayMode > 0)
                {
                    int dmode = (int)_displayMode - 1;
                    _displayMode = (DISPLAYMODE)dmode;
                }
                else
                {
                    _displayMode = (DISPLAYMODE)Enum.GetNames(typeof(DISPLAYMODE)).Length - 1;
                }

                _displayChanged = true;

            }

            if (Input.GetKeyDown(KeyCode.Keypad2))
            {
                if (((int)_displayMode) < Enum.GetNames(typeof(DISPLAYMODE)).Length - 1)
                {
                    int dmode = (int)_displayMode + 1;
                    _displayMode = (DISPLAYMODE)dmode;
                }
                else
                {
                    _displayMode = (DISPLAYMODE)0;
                }

                _displayChanged = true;

            }
        }


        /// <summary>
        /// 
        /// </summary>
        public void ChangeDisplay()
        {
            _displayChanged = false;

            switch (_displayMode)
            {

                case DISPLAYMODE.LiveCells:
                    //change color of material property block
                    _materialprops.SetColor("_Color", _liveColor);

                    //apply material props to each obj renderer
                    foreach (var layer in _stackManager.Layers)
                    {
                        foreach (var cell in layer.Cells)
                        {
                            if (cell.State == 1)
                            {
                                cell.Renderer.SetPropertyBlock(_materialprops);
                            }
                        }
                    }

                    return;

                case DISPLAYMODE.ColorAge:

                    //apply material props to each obj renderer
                    foreach (var layer in _stackManager.Layers)
                    {
                        foreach (var cell in layer.Cells)
                        {
                            if (cell.State == 1)
                            {
                                float ageVizMax = _ageVizMax;
                                if (_ageVizMax > _stackAnalyser.HighestAge)
                                {
                                    _ageVizMax = _stackAnalyser.HighestAge;
                                }

                                float value = Remap(cell.Age, 0, ageVizMax, 0, 1);
                                Color color = Color.Lerp(Color.white, _ageColor, value);

                                //change color of material property block
                                _materialprops.SetColor("_Color", color);
                                cell.Renderer.SetPropertyBlock(_materialprops);
                            }
                        }
                    }

                    return;

                case DISPLAYMODE.ColorMO3DDensity:

                    //apply material props to each obj renderer
                    for (int k = 0; k < _stackManager.History.Length; k++)
                    {
                        int[,] layerState = _stackManager.History[k];
                        int m = layerState.GetLength(0);
                        int n = layerState.GetLength(1);

                        for (int j = 0; j < n; j++)
                        {
                            for (int i = 0; i < m; i++)
                            {
                                Cell cell = _stackManager.Layers[k].Cells[i, j];

                                if (cell.State == 1)
                                {
                                    Index3[] neighborhood = Neighborhoods.Moore3Cen;
                                    int sum = _stackAnalyser.GetNeighborSum3(i, j, k, neighborhood);

                                    float value = Remap(sum, 0, neighborhood.Length, 0, 1);
                                    Color color = Color.Lerp(Color.white, _neighborhoodDensityColor, value);

                                    //change color of material property block
                                    _materialprops.SetColor("_Color", color);
                                    cell.Renderer.SetPropertyBlock(_materialprops);
                                }
                            }
                        }

                    }
                    return;

                case DISPLAYMODE.ColorLayerDensity:
                    //change color of material property block
                    _materialprops.SetColor("_Color", _layerDensityColor);

                    //apply material props to each obj renderer
                    for (int i = 0; i < _stackAnalyser.LayerDensities.Length; i++)
                    {
                        float minDensity = _stackAnalyser.LayerDensities.Min();
                        float maxDensity = _stackAnalyser.LayerDensities.Max();
                        float layerDensity = _stackAnalyser.LayerDensities[i];
                        float value = Remap(layerDensity, minDensity, maxDensity, 0, 1);
                        Color color = Color.Lerp(Color.white, _layerDensityColor, value);
                        CellLayer layer = _stackManager.Layers[i];
                        foreach (var cell in layer.Cells)
                        {
                            if (cell.State == 1)
                            {
                                //change color of material property block
                                _materialprops.SetColor("_Color", color);
                                cell.Renderer.SetPropertyBlock(_materialprops);
                            }
                        }
                    }
                    return;

                default:
                    return;

            }
        }

        /// <summary>
        /// Remap range function.
        /// </summary>
        /// <param name="value"></param>
        /// <param name="from1"></param>
        /// <param name="to1"></param>
        /// <param name="from2"></param>
        /// <param name="to2"></param>
        /// <returns></returns>
        // Remap numbers - used here for getting a gradient of color across a range
        private float Remap(float value, float from1, float to1, float from2, float to2)
        {
            return (value - from1) / (to1 - from1) * (to2 - from2) + from2;
        }
    }
}
