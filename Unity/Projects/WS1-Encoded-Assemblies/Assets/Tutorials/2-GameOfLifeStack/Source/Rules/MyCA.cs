using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using SpatialSlur;

namespace RC3
{
    /// <summary>
    /// Rule for Conway's game of life
    /// </summary>
    public class MyCA : ICARule2D
    {

        //setup some possible instruction sets
        private GOLInstructionSet _instSetMO1 = new GOLInstructionSet(2, 3, 3, 3);
        private GOLInstructionSet _instSetMO2 = new GOLInstructionSet(3, 4, 3, 4);
        private GOLInstructionSet _instSetMO3 = new GOLInstructionSet(2, 5, 2, 6);

        //analysis manager - provides global model data and data analysis
        private StackAnalyser _stackAnalyser;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="offsets"></param>
        public MyCA(StackAnalyser stackAnalyser)
        {
            _stackAnalyser = stackAnalyser;
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="i"></param>
        /// <param name="j"></param>
        /// <param name="current"></param>
        /// <returns></returns>
        public int NextAt(int i, int j, int[,] current)
        {
            //get current state
            int state = current[i, j];

            //get local neighborhood data
            int sumMO = GetNeighborSum(i, j, current, Neighborhoods.MooreR1);
            int sumVNPair = GetNeighborSum(i, j, current, Neighborhoods.VonNeumannPair1);

            int currentlevel = _stackAnalyser.StepCount;

            //choose an instruction set
            GOLInstructionSet instructionSet = _instSetMO1;

            //Get current density of the previous layer
            float currentlayerdensity = _stackAnalyser.CurrentLayerDensity;
            instructionSet = _instSetMO1;

            //Get current age of the previous cell at this location...
            int age = _stackAnalyser.GetCellAge(i, j);

            //Get current density of the overall stack so far...
            float currentstackdensity = _stackAnalyser.StackDensity;

            /*
            if (currentlayerdensity < .17)
            {
                instructionSet = _instSetMO3;
            }

            if (currentlayerdensity >= .17 && currentlayerdensity<.2)
            {
                instructionSet = _instSetMO1;
            }

            if (currentlayerdensity >.2)
            {
                instructionSet = _instSetMO2;
            }
            */

            /*
            if(state==0 && sumVNPair == 2)
            {
                return 1;
            }

            if (state == 1 && sumVNPair == 2)
            {
                return 0;
            }
            */


            /*
            if(currentlevel <= 40)
            {
                instructionSet = _instSetMO1;
            }

            if (currentlevel > 40 && currentlevel<65)
            {
                instructionSet = _instSetMO2;
            }

            if (currentlevel >= 65)
            {
                instructionSet = _instSetMO3;
            }
            */


            int output = 0;

            //if current state is "alive"
            if (state == 1)
            {
                if (sumMO < instructionSet.getInstruction(0))
                {
                    output = 0;
                }

                if (sumMO >= instructionSet.getInstruction(0) && sumMO <= instructionSet.getInstruction(1))
                {
                    output = 1;
                }

                if (sumMO > instructionSet.getInstruction(1))
                {
                    output = 0;
                }
            }

            //if current state is "dead"
            if (state == 0)
            {
                if (sumMO >= instructionSet.getInstruction(2) && sumMO <= instructionSet.getInstruction(3))
                {
                    output = 1;
                }
                else
                {
                    output = 0;
                }
            }

            return output;

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="i0"></param>
        /// <param name="j0"></param>
        /// <returns></returns>
        private int GetNeighborSum(int i0, int j0, int[,] current, Index2[] neighborhood)
        {
            int m = current.GetLength(0);
            int n = current.GetLength(1);
            int sum = 0;

            foreach (Index2 offset in neighborhood)
            {
                int i1 = Wrap(i0 + offset.I, m);
                int j1 = Wrap(j0 + offset.J, n);

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
    }
}