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
    public class StackAnalyser : MonoBehaviour
    {
        private StackModel _model;
        private float _densitySum;
        private int _currentLayer; // index of the most recently analysed layer


        /// <summary>
        /// 
        /// </summary>
        private void Start()
        {
            _model = GetComponent<StackModel>();
            ResetAnalysis();
        }


        /// <summary>
        /// 
        /// </summary>
        private void LateUpdate()
        {
            // reset analysis if necessary
            if (_currentLayer > _model.CurrentLayer)
                ResetAnalysis();

            // update analysis if model has been updated
            if (_currentLayer < _model.CurrentLayer)
                UpdateAnalysis();
        }


        /// <summary>
        /// Returns the current mean density of the stack
        /// </summary>
        public float MeanStackDensity
        {
            get { return _densitySum / (_model.CurrentLayer + 1); }
        }


        /// <summary>
        /// 
        /// </summary>
        public void UpdateAnalysis()
        {
            int currentLayer = _model.CurrentLayer;
            CellLayer layer = _model.Stack.Layers[currentLayer];

            //update layer current density
            var density = CalculateDensity(layer);
            layer.Density = density;
            _densitySum += density; // add to running sum
            
            _currentLayer = currentLayer;
        }


        /// <summary>
        /// Calculate the density of alive cells for the given layer
        /// </summary>
        /// <returns></returns>
        private float CalculateDensity(CellLayer layer)
        {
            var cells = layer.Cells;
            int aliveCount = 0;

            foreach (var cell in cells)
                aliveCount += cell.State;

            return (float)aliveCount / cells.Length;
        }


        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        private void ResetAnalysis()
        {
            _densitySum = 0.0f;
            _currentLayer = -1;
        }
    }
}
