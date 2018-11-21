using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

using SpatialSlur;

namespace RC3
{
    namespace WS2
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

            /// <summary>
            /// 
            /// </summary>
            public void Fitness()
            {
                float fitness = 1;
                //calculate separate objective fitness values
                float structuralFit = StructuralFitness();
                float massFit = MassFitness();

                //setup fitness function to combine and weight these factors
                fitness = (structuralFit + massFit) / 2;

                fitness = MeanStackDensity;

                //set stack fitness value
                _model.Stack.SetFitness(fitness);
                //Debug.Log("Fitness " + fitness);
            }

            /// <summary>
            /// 
            /// </summary>
            /// <returns></returns>
            private float PatternFitness()
            {
                float patternFitness = 1;
                //calculate assign pattern fitness value

                return patternFitness;
            }

            /// <summary>
            /// 
            /// </summary>
            /// <returns></returns>
            private float DensityFitness()
            {
                float densityFitness = 1;
                //calculate assign density fitness value

                return densityFitness;
            }

            /// <summary>
            /// 
            /// </summary>
            /// <returns></returns>
            private float MassFitness()
            {
                float massFitness = 1;
                //calculate overall mass - assign fitness value

                return massFitness;
            }

            /// <summary>
            /// 
            /// </summary>
            /// <returns></returns>
            private float StructuralFitness()
            {
                float structuralFitness = 1;
                //calculate structural forces and return fitness value
                return structuralFitness;
            }
        }
    }
}
