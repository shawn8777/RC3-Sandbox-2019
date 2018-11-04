using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using SpatialSlur;

namespace RC3
{
    /// <summary>
    /// 
    /// </summary>
    public class StackManager : MonoBehaviour
    {

        [SerializeField] private ModelInitializer _initializer;
        [SerializeField] private CellLayer _layerPrefab; 
        [SerializeField] private Cell _cellPrefab; 

        [SerializeField] private int _layerColumns = 10; 
        [SerializeField] private int _layerRows = 10; 
        [SerializeField] private int _layerCount = 10; 

        private CellLayer[] _layers; 
        private ModelState[] _history; 
        private CAModel2D _model;
        private ICARule2D _modelRule; 

        private AnalysisManager _analysisManager;

        private int _stepCount; 
        private bool _pause = true; 
        private bool _stopLayCount = false;

        /// <summary>
        /// 
        /// </summary>
        public CAModel2D Model
        {
            get { return _model; }
        }

        /// <summary>
        /// 
        /// </summary>
        public bool Pause
        {
            get { return _pause; }
            set { _pause = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        public int StepCount
        {
            get { return _stepCount; }
        }

        /// <summary>
        /// 
        /// </summary>
        public int LayerCount
        {
            get { return _layerCount; }
        }

        /// <summary>
        /// 
        /// </summary>
        public int LayerColumns
        {
            get { return _layerColumns; }
        }

        /// <summary>
        /// 
        /// </summary>
        public int LayerRows
        {
            get { return _layerRows; }
        }

        /// <summary>
        /// 
        /// </summary>
        public CellLayer[] Layers
        {
            get { return _layers; }
        }


        /// <summary>
        /// 
        /// </summary>
        private void Start()
        {
            _analysisManager = new AnalysisManager(this);
            _modelRule = new MyCA(_analysisManager);

            _layers = new CellLayer[_layerCount];
            _history = new ModelState[_layerCount];

            // instantiate layers
            for (int i = 0; i < _layerCount; i++)
            {
                CellLayer copy = Instantiate(_layerPrefab, transform);
                copy.transform.localPosition = new Vector3(0.0f, i, 0.0f);

                // create cell layer
                copy.Initialize(_cellPrefab, _layerRows, _layerColumns);
                _layers[i] = copy;

                // create history
                _history[i] = new int[_layerRows, _layerColumns];
            }

            // instantiate rule and model
            _model = new CAModel2D(_modelRule, _layerRows, _layerColumns);

            // initialize model
            _initializer.Initialize(_model.CurrentState);

            // center manager gameobject at the world origin
            transform.localPosition = new Vector3(_layerColumns, _layerCount, _layerRows) * -0.5f;
        }


        /// <summary>
        /// 
        /// </summary>
        private void Update()
        {
            //check all keypresses
            HandleKeyPress();

            //stop updating after reaching layer count
            if (++_stepCount < LayerCount - 1)
            {
                // advance model
                _model.Step();
                //_model.StepParallel();

                // copy model state to current layer
                ModelState current = _model.CurrentState;
                Array.Copy(current, _history[_stepCount], current.Count);

                // update cells in the current layer
                UpdateCells();

                // update analysis manager
                _analysisManager.UpdateAnalysis();
            }
        }


        /// <summary>
        /// Places the oldest layer at the bottom and shifts the rest up
        /// </summary>
        private void ShiftLayers()
        {
            // shifts array elements by the given offset
            _layers.Shift(1);
            _history.Shift(1);

            // update layer positions
            for (int j = 0; j < _layerCount; j++)
                _layers[j].transform.localPosition = new Vector3(0.0f, j, 0.0f);
        }


        /// <summary>
        /// Updates cells in the most recent layer
        /// </summary>
        /// <param name="layer"></param>
        private void UpdateCells()
        {
            Cell[,] cells = _layers[_stepCount].Cells;
            int[,] state = _model.CurrentState;

            for (int i = 0; i < _layerRows; i++)
            {
                for (int j = 0; j < _layerColumns; j++)
                {
                    //update cell age - FIXME
                    int prevAge = cells[i, j].Age;
                    if (state[i, j] == 1)
                    {
                        cells[i, j].Age = prevAge++;
                    }
                    else
                    {
                        cells[i, j].Age = 0;
                    }

                    //set state
                    cells[i, j].SetState(state[i, j]);
                }
            }
        }


        /// <summary>
        /// 
        /// </summary>
        private void HandleKeyPress()
        {
            // re-initialize on key down
            if (Input.GetKeyDown(KeyCode.Space))
            {
                _initializer.Initialize(_model.CurrentState);
            }
        }
    }
}
