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

        [SerializeField] private int _columnCount = 10;
        [SerializeField] private int _rowCount = 10;
        [SerializeField] private int _layerCount = 10;

        private CellLayer[] _layers;
        private CAModel2D _model;
        private StackAnalyser _analyser;

        private int _stepCount;
        private bool _pause = true;


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
        public CellLayer[] Layers
        {
            get { return _layers; }
        }


        /// <summary>
        /// 
        /// </summary>
        public StackAnalyser Analyser
        {
            get { return _analyser; }
        }


        /// <summary>
        /// 
        /// </summary>
        private void Awake()
        {
            _layers = new CellLayer[_layerCount];

            // instantiate layers
            for (int i = 0; i < _layerCount; i++)
            {
                CellLayer copy = Instantiate(_layerPrefab, transform);
                copy.transform.localPosition = new Vector3(0.0f, i, 0.0f);

                // create cell layer
                copy.Initialize(_cellPrefab, _rowCount, _columnCount);
                _layers[i] = copy;
            }

            // create rule
            _analyser = new StackAnalyser(this);
            MyCA rule = new MyCA(_analyser);

            // create model
            _model = new CAModel2D(rule, _rowCount, _columnCount);

            // initialize model
            _initializer.Initialize(_model.CurrentState);

            // center manager gameobject at the world origin
            transform.localPosition = new Vector3(_columnCount, _layerCount, _rowCount) * -0.5f;
        }


        /// <summary>
        /// 
        /// </summary>
        private void Update()
        {
            //check all keypresses
            HandleKeyPress();

            //stop updating after reaching layer count
            if (_stepCount < _layerCount)
            {
                // advance model
                _model.Step();
                //_model.StepParallel();

                // update cells in the current layer
                UpdateCells();

                // update analysis manager
                 _analyser.Update();
                _stepCount++;
            }
        }


        /// <summary>
        /// Updates all cells in the current layer
        /// </summary>
        /// <param name="layer"></param>
        private void UpdateCells()
        {
            Cell[,] currCells = _layers[_stepCount].Cells;
            int[,] currState = _model.CurrentState;

            Cell[,] prevCells = _stepCount > 0 ? _layers[_stepCount - 1].Cells : null;
            
            for (int i = 0; i < _rowCount; i++)
            {
                for (int j = 0; j < _columnCount; j++)
                {
                    Cell cell = currCells[i, j];
                    int state = currState[i, j];

                    // assign state
                    cell.State = state;

                    // update age if history exists
                    if(prevCells != null)
                    {
                        if (state == 0)
                            cell.Age = 0;
                        else
                            cell.Age = prevCells[i, j].Age + 1;
                    }
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
                Reset();
        }


        /// <summary>
        /// 
        /// </summary>
        private void Reset()
        {
            // reset cells
            foreach (var layer in _layers)
            {
                foreach (var cell in layer.Cells)
                    cell.State = 0;
            }

            // reset the analyser
            _analyser.Reset();

            // re-initialize model
            _initializer.Initialize(_model.CurrentState);
            _stepCount = 0;
        }
    }
}
