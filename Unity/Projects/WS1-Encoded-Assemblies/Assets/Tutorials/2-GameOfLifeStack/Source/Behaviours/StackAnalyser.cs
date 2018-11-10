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
        // TODO process OnModelReset event
        // TODO publish analysis results in scriptable object "AnalysisResults"

        private StackModel _model;
        private float _stackDensity;
        private int _maxAge = 0;


        /// <summary>
        /// 
        /// </summary>
        void Start()
        {
            _model = GetComponent<StackModel>();
        }


        /// <summary>
        /// 
        /// </summary>
        private void LateUpdate()
        {
            //UpdateAnalysis();
        }


        /// <summary>
        /// 
        /// </summary>
        public void Reset()
        {
            _maxAge = 0;
        }


        /// <summary>
        /// 
        /// </summary>
        public float StackDensity
        {
            get { return _stackDensity; }
        }


        /// <summary>
        /// 
        /// </summary>
        public int MaxAge
        {
            get { return _maxAge; }
        }


        /// <summary>
        /// 
        /// </summary>
        public void UpdateAnalysis()
        {
            CellStack stack = _model.Stack;
            int currentIndex = _model.CurrentLayer;

            var layers = stack.Layers;
            CellLayer currentLayer = layers[currentIndex];

            //update layer current density
            currentLayer.Density = CalculateDensity(currentLayer);

            //update highest cell age
            foreach (var cell in currentLayer.Cells)
                _maxAge = Math.Max(cell.Age, _maxAge);

            // calculate mean density of stack
            float sum = 0.0f;
            for(int i = 0; i <= currentIndex; i++)
                sum += layers[i].Density;

            _stackDensity = sum / (currentIndex + 1);
        }


        /// <summary>
        /// Calculate the density of alive cells for the given layer
        /// </summary>
        /// <returns></returns>
        public float CalculateDensity(CellLayer layer)
        {
            var cells = layer.Cells;
            int aliveCount = 0;

            foreach (var cell in cells)
                aliveCount += cell.State;

            return (float)aliveCount / cells.Length;
        }
    }
}
