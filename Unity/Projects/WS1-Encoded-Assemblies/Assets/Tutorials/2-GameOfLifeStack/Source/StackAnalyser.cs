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
    public class StackAnalyser
    {
        private StackManager _stackManager;
        private float[] _layerDensities;
        private float _stackDensity;
        private int _highestAge = 0;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="stackmanager"></param>
        public StackAnalyser(StackManager stackmanager)
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
        public float CurrentLayerDensity
        {
            get { return _layerDensities[StepCount - 1]; }
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
        public float[] LayerDensities
        {
            get { return _layerDensities; }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="i0"></param>
        /// <param name="j0"></param>
        /// <param name="k0"></param>
        /// <param name="neighborhood"></param>
        /// <returns></returns>
        public int GetNeighborSum3(int i0, int j0, int k0, Index3[] neighborhood)
        {
            //get ModelState from stack manager history at this location
            int[,] current = _stackManager.History[k0];

            int m = current.GetLength(0);
            int n = current.GetLength(1);
            int p = _stackManager.History.Length;

            int sum = 0;

            foreach (Index3 offset in neighborhood)
            {
                int i1 = Wrap(i0 + offset.I, m);
                int j1 = Wrap(j0 + offset.J, n);
                int k1 = Wrap(k0 + offset.K, p);

                //layer k1
                current = _stackManager.History[k1];

                if (current[i1, j1] > 0)
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
        /// 
        /// </summary>
        public void UpdateAnalysis()
        {
            //update highest cell age
            foreach (var cell in _stackManager.Layers[StepCount - 1].Cells)
            {
                if (cell.Age > _highestAge)
                {
                    _highestAge = cell.Age;
                }
            }

            //update layer current density
            _layerDensities[StepCount] = _stackManager.Layers[StepCount].CalculateDensity();
            float densitytotal = 0;
            for (int i = 0; i <= StepCount - 1; i++)
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
            CellLayer layer = _stackManager.Layers[StepCount - 1];
            return layer.Cells[i, j].Age;
        }

        /// <summary>
        /// 
        /// </summary>
        public int HighestAge
        {
            get { return _highestAge; }
        }
    }
}
