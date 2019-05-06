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
    [RequireComponent(typeof(ICARule2D))]
    public class StackModel : MonoBehaviour
    {
        // TODO fire OnModelReset event

        [SerializeField] private ModelInitializer _initializer;
        [SerializeField] private CellStack _stack;

        private CAModel2D _model;
        private StackAnalyser _analyser;

        private int _currentLayer = -1;


        /// <summary>
        /// 
        /// </summary>
        public CellStack Stack
        {
            get { return _stack; }
        }


        /// <summary>
        /// 
        /// </summary>
        public CAModel2D Model
        {
            get { return _model; }
        }


        /// <summary>
        /// Returns the index of the most recently processed layer
        /// </summary>
        public int CurrentLayer
        {
            get { return _currentLayer; }
        }


        /// <summary>
        /// 
        /// </summary>
        private void Awake()
        {
            // create model
            _model = new CAModel2D(GetComponent<ICARule2D>(), _stack.RowCount, _stack.ColumnCount);
            
            // initialize model
            _initializer.Initialize(_model.CurrentState);
        }


        /// <summary>
        /// 
        /// </summary>
        private void Update()
        {
            // bail if stack is full
            if (_currentLayer == _stack.LayerCount - 1)
                return;

            // advance later
            _currentLayer++;

            // advance model
            _model.Step();
            //_model.StepParallel();

            // update cells in the stack
            UpdateStack();
        }


        /// <summary>
        /// 
        /// </summary>
        public void ResetModel()
        {
            // reset cell states
            foreach (var layer in _stack.Layers)
            {
                foreach (var cell in layer.Cells)
                    cell.State = 0;
            }

            // re-initialize model
            _initializer.Initialize(_model.CurrentState);

            // reset layer
            _currentLayer = -1;
        }


        /// <summary>
        /// 
        /// </summary>
        public void UpdateStack()
        {
            int[,] currState = _model.CurrentState;
            Cell[,] currCells = _stack.Layers[_currentLayer].Cells;

            int nrows = _stack.RowCount;
            int ncols = _stack.ColumnCount;

            // set cell state
            for (int i = 0; i < nrows; i++)
            {
                for (int j = 0; j < ncols; j++)
                    currCells[i, j].State = currState[i, j];
            }

            // update cell age
            if (_currentLayer > 0)
            {
                Cell[,] prevCells = _stack.Layers[_currentLayer - 1].Cells;

                for (int i = 0; i < nrows; i++)
                {
                    for (int j = 0; j < ncols; j++)
                        currCells[i, j].Age = currState[i, j] > 0 ? prevCells[i, j].Age + 1 : 0;
                }
            }
        }
    }
}
