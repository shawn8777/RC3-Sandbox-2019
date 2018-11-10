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
    [RequireComponent(typeof(StackModel))]
    [RequireComponent(typeof(StackAnalyser))]
    public partial class StackDisplay : MonoBehaviour
    {
        // TODO process OnModelReset event
        // TODO reference "AnalysisResults" scriptable object rather than "StackAnalyser"

        [SerializeField] private Material _material;
        [SerializeField] private Color _aliveColor;
        [SerializeField] private Color _ageColor;
        [SerializeField] private int _ageDisplayMax;
        [SerializeField] private Color _stackDensityColor;
        [SerializeField] private Color _layerDensityColor;
        [SerializeField] private CellDisplayMode _displayMode = CellDisplayMode.Alive;

        private StackModel _model;
        private StackAnalyser _analyser;
        private MaterialPropertyBlock _materialprops;
        private bool _displayChanged = false;


        /// <summary>
        /// 
        /// </summary>
        public CellDisplayMode DisplayMode
        {
            get { return _displayMode; }
            set
            {
                _displayChanged = _displayMode != value;
                _displayMode = value;
            }
        }


        /// <summary>
        /// 
        /// </summary>
        private void Start()
        {
            // TODO
            // MaterialPropertyBlock defaults to blue for some reason...

            _model = GetComponent<StackModel>();
            _analyser = GetComponent<StackAnalyser>();
            _materialprops = new MaterialPropertyBlock();

            // assign material to cells
            foreach (var layer in _model.Stack.Layers)
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
        private void LateUpdate()
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
            // TODO move to "InputManager"

            if (Input.GetKeyDown(KeyCode.Alpha1))
                DisplayMode = CellDisplayMode.Alive;
            else if (Input.GetKeyDown(KeyCode.Alpha2))
                DisplayMode = CellDisplayMode.Age;
            else if (Input.GetKeyDown(KeyCode.Alpha3))
                DisplayMode = CellDisplayMode.LayerDensity;
            else if (Input.GetKeyDown(KeyCode.Alpha4))
                DisplayMode = CellDisplayMode.StackDensity;
        }

        
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
            CellLayer[] layers = _model.Stack.Layers;
            int currentLayer = _model.CurrentLayer;

            //change color of material property block
            _materialprops.SetColor("_Color", _aliveColor);

            //apply material props to each obj renderer
            for(int i = 0; i <= currentLayer; i++)
            {
                foreach (var cell in layers[i].Cells)
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
            CellLayer[] layers = _model.Stack.Layers;
            int currentLayer = _model.CurrentLayer;

            //apply material props to each obj renderer
            for (int i = 0; i <= currentLayer; i++)
            {
                foreach (var cell in layers[i].Cells)
                {
                    // skip dead cells
                    if (cell.State == 0)
                        continue;

                    // map age to color
                    float value = Remap(cell.Age, 0.0f, Mathf.Max(_ageDisplayMax, _analyser.MaxAge), 0.0f, 1.0f);
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
            // TODO index out of range error

            CellLayer[] layers = _model.Stack.Layers;
            int currentLayer = _model.CurrentLayer;
      
            //apply material props to each obj renderer
            for (int k = 0; k <= currentLayer; k++)
            {
                CellLayer layer = layers[k];
                Cell[,] cells = layer.Cells;

                Index3[] neighb = Neighborhoods.Moore3Cen;
                int nrows = layer.RowCount;
                int ncols = layer.ColumnCount;

                for (int i = 0; i < nrows; i++)
                {
                    for (int j = 0; j < ncols; j++)
                    {
                        Cell cell = cells[i, j];

                        // skip dead cells
                        if (cell.State == 0)
                            continue;

                        // map density to color
                        int sum = GetNeighborSum3(new Index3(k, i, j), neighb);
                        float value = Remap(sum, 0.0f, neighb.Length, 0.0f, 1.0f);
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
            CellLayer[] layers = _model.Stack.Layers;
            int currentLayer = _model.CurrentLayer;
            
            float minDensity = layers.Min(layer => layer.Density);
            float maxDensity = layers.Max(layer => layer.Density);

            //change color of material property block
            _materialprops.SetColor("_Color", _layerDensityColor);

            for(int i = 0; i <= currentLayer; i++)
            {
                CellLayer layer = layers[i];

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
        /// 
        /// </summary>
        public int GetNeighborSum3(Index3 index, Index3[] neighborhood)
        {
            CellStack stack = _model.Stack;
            CellLayer[] layers = stack.Layers;
            Cell[,] layer0 = layers[index.I].Cells;

            int nlays = stack.LayerCount;
            int nrows = stack.RowCount;
            int ncols = stack.ColumnCount;
            int sum = 0;

            foreach (Index3 offset in neighborhood)
            {
                int i1 = Wrap(index.I + offset.I, nlays);
                int j1 = Wrap(index.J + offset.J, nrows);
                int k1 = Wrap(index.K + offset.K, ncols);

                if (layers[i1].Cells[j1, k1].State > 0)
                    sum++;
            }

            return sum;
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
