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
    public class AnalysisManager
    {
        private StackManager _stackManager;
        private float[] _layerDensities;
        private float _stackDensity;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="stackmanager"></param>
        public AnalysisManager(StackManager stackmanager)
        {
            _stackManager = stackmanager;
            _layerDensities = new float[_stackManager.LayerCount];
            for (int i = 0; i < _layerDensities.Length; i++)
            {
                _layerDensities[i] = 0;
            }
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
        public int StepCount
        {
            get { return _stackManager.StepCount; }
        }


        /// <summary>
        /// 
        /// </summary>
        public void UpdateAnalysis()
        {
            //update layer current density
            _layerDensities[StepCount] = _stackManager.Layers[StepCount].CalculateDensity();
            float densitytotal = 0;
            for(int i = 0; i <= StepCount; i++)
            {
                densitytotal += _layerDensities[i];
            }

            //update density of stack overall so far
            _stackDensity = densitytotal / StepCount;

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="i"></param>
        /// <param name="j"></param>
        /// <returns></returns>
        public int GetCellAge(int i, int j)
        {
            int layerindex = StepCount;
            CellLayer layer = _stackManager.Layers[StepCount];
            return layer.Cells[i, j].Age;
        }
    }
}
