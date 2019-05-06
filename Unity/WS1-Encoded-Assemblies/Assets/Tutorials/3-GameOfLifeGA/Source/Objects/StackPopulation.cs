using System;
using System.Collections;
using System.Collections.Generic;

using UnityEngine;

using SpatialSlur.Collections;

namespace RC3
{
    namespace WS2
    {
        [CreateAssetMenu(menuName = "RC3/WS2/StackPopulation")]

        /// <summary>
        /// 
        /// </summary>
        public class StackPopulation : ScriptableObject
        {
            private List<CellStack> _population;
            private float _maxFitness = float.MinValue;
            private float _minFitness = float.MaxValue;

            /// <summary>
            /// 
            /// </summary>
            public float MaxFitness
            {
                get { return _maxFitness; }
                set { _maxFitness = value; }
            }

            /// <summary>
            /// 
            /// </summary>
            public float MinFitness
            {
                get { return _minFitness; }
                set { _minFitness = value; }
            }

            /// <summary>
            /// 
            /// </summary>
            public List<CellStack> Population
            {
                get { return _population; }
            }

            /// <summary>
            /// 
            /// </summary>
            /// <param name="generation"></param>
            public void AddGeneration(CellStack[] generation)
            {
                _population.AddRange(generation);
            }

            public void Reset()
            {
                _population = new List<CellStack>();
                _maxFitness = float.MinValue;
                _minFitness = float.MaxValue;
            }
        }
    }
}
