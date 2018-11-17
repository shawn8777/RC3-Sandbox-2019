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
    [RequireComponent(typeof(StackManager))]
    public partial class StackDisplay : MonoBehaviour
    {
        [SerializeField]
        private Material _material;

        [SerializeField]
        private Color _aliveColor;

        [SerializeField]
        private Color _ageColor;

        [SerializeField]
        private int _ageDisplayMax;

        [SerializeField]
        private Color _stackDensityColor;

        [SerializeField]
        private Color _layerDensityColor;

        [SerializeField]
        private CellDisplayMode _displayMode = CellDisplayMode.Alive;


        private StackManager _manager;
        MaterialPropertyBlock _materialprops;
        bool _displayChanged = false;


        /// <summary>
        /// 
        /// </summary>
        void Start()
        {
            // TODO
            // bug with MaterialPropertyBlock
            // Cells default to blue

            _manager = GetComponent<StackManager>();
            _materialprops = new MaterialPropertyBlock();

            // assign material to cells
            foreach (var layer in _manager.Layers)
            {
                foreach (var cell in layer.Cells)
                    cell.Renderer.sharedMaterial = _material;
            }

            // default mode
            DisplayAlive();
        }


        /// <summary>
        /// 
        /// </summary>
        private void Update()
        {
            HandleKeyPress();

            if (_displayChanged)
                ChangeDisplay();
        }


        /// <summary>
        /// 
        /// </summary>
        private void HandleKeyPress()
        {
            CellDisplayMode prevMode = _displayMode;

            if (Input.GetKeyDown(KeyCode.Alpha1))
                _displayMode = CellDisplayMode.Alive;
            else if (Input.GetKeyDown(KeyCode.Alpha2))
                _displayMode = CellDisplayMode.Age;
            else if (Input.GetKeyDown(KeyCode.Alpha3))
                _displayMode = CellDisplayMode.LayerDensity;
            else if (Input.GetKeyDown(KeyCode.Alpha4))
                _displayMode = CellDisplayMode.StackDensity;

            // flag if display mode changed
            _displayChanged = _displayMode != prevMode;
        }


        /*
        /// <summary>
        /// 
        /// </summary>
        private void HandleKeyPress()
        {
            // TODO
            // not sure whats going on here
            // simplified implementation above

            if (Input.GetKeyDown(KeyCode.Keypad0))
            {
                ChangeDisplay();
            }

            if (Input.GetKeyDown(KeyCode.Keypad1))
            {
                if ((int)_displayMode > 0)
                {
                    int dmode = (int)_displayMode - 1;
                    _displayMode = (CellDisplayMode)dmode;
                }
                else
                {
                    _displayMode = (CellDisplayMode)Enum.GetNames(typeof(CellDisplayMode)).Length - 1;
                }

                _displayChanged = true;
            }

            if (Input.GetKeyDown(KeyCode.Keypad2))
            {
                if (((int)_displayMode) < Enum.GetNames(typeof(CellDisplayMode)).Length - 1)
                {
                    int dmode = (int)_displayMode + 1;
                    _displayMode = (CellDisplayMode)dmode;
                }
                else
                {
                    _displayMode = (CellDisplayMode)0;
                }

                _displayChanged = true;
            }
        }
        */


        /// <summary>
        /// 
        /// </summary>
        public void ChangeDisplay()
        {
            _displayChanged = false;

            switch (_displayMode)
            {
                case CellDisplayMode.Alive:
                    DisplayAlive();
                    break;
                case CellDisplayMode.Age:
                    DisplayAge();
                    break;
                case CellDisplayMode.LayerDensity:
                    DisplayLayerDensity();
                    break;
                case CellDisplayMode.StackDensity:
                    DisplayStackDensity();
                    break;
            }
        }


        /// <summary>
        /// 
        /// </summary>
        private void DisplayAlive()
        {
            //change color of material property block
            _materialprops.SetColor("_Color", _aliveColor);

            //apply material props to each obj renderer
            foreach (var layer in _manager.Layers)
            {
                foreach (var cell in layer.Cells)
                {
                    if (cell.State > 0)
                        cell.Renderer.SetPropertyBlock(_materialprops);
                }
            }
        }


        /// <summary>
        /// 
        /// </summary>
        private void DisplayAge()
        {
            StackAnalyser analyser = _manager.Analyser;

            //apply material props to each obj renderer
            foreach (var layer in _manager.Layers)
            {
                foreach (var cell in layer.Cells)
                {
                    // skip dead cells
                    if (cell.State == 0)
                        continue;

                    // map age to color
                    float value = Remap(cell.Age, 0.0f, Mathf.Max(_ageDisplayMax, analyser.MaxAge), 0.0f, 1.0f);
                    Color color = Color.Lerp(Color.white, _ageColor, value);

                    //change color of material property block
                    _materialprops.SetColor("_Color", color);
                    cell.Renderer.SetPropertyBlock(_materialprops);
                }
            }
        }


        /// <summary>
        /// 
        /// </summary>
        private void DisplayStackDensity()
        {
            CellLayer[] layers = _manager.Layers;
            StackAnalyser analyser = _manager.Analyser;
            Index3[] neighb = Neighborhoods.Moore3Cen;

            //apply material props to each obj renderer
            for (int k = 0; k < layers.Length; k++)
            {
                CellLayer layer = layers[k];
                int m = layer.Rows;
                int n = layer.Columns;

                Cell[,] cells = layer.Cells;

                for (int i = 0; i < m; i++)
                {
                    // Note: keep the 2nd index on the inner loop for better cache locality
                    for (int j = 0; j < m; j++) 
                    {
                        Cell cell = cells[i, j];

                        // skip dead cells
                        if (cell.State == 0)
                            continue;
                
                        // map density to color
                        int sum = analyser.GetNeighborSum3(i, j, k, neighb);
                        float value = Remap(sum, 0, neighb.Length, 0, 1);
                        Color color = Color.Lerp(Color.white, _stackDensityColor, value);

                        //change color of material property block
                        _materialprops.SetColor("_Color", color);
                        cell.Renderer.SetPropertyBlock(_materialprops);
                    }
                }
            }
        }


        /// <summary>
        /// 
        /// </summary>
        private void DisplayLayerDensity()
        {
            CellLayer[] layers = _manager.Layers;
            float minDensity = layers.Min(layer => layer.Density);
            float maxDensity = layers.Max(layer => layer.Density);

            StackAnalyser analyser = _manager.Analyser;

            //change color of material property block
            _materialprops.SetColor("_Color", _layerDensityColor);

            foreach(var layer in layers)
            {
                float value = Remap(layer.Density, minDensity, maxDensity, 0.0f, 1.0f);
                Color color = Color.Lerp(Color.white, _layerDensityColor, value);

                foreach (var cell in layer.Cells)
                {
                    // skip dead cells
                    if (cell.State == 0)
                        continue;

                    //change color of material property block
                    _materialprops.SetColor("_Color", color);
                    cell.Renderer.SetPropertyBlock(_materialprops);
                }
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
