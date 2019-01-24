
using System;
using System.Collections.Generic;

namespace RC3
{
    /// <summary>
    /// 
    /// </summary>
    public class GameOfLife2D
    {
        private int[,] _currentState;
        private int[,] _nextState;
        private Index2[] _offsets = Neighborhoods.MooreR1;


        /// <summary>
        /// 
        /// </summary>
        public int[,] CurrentState
        {
            get { return _currentState; }
        }


        /// <summary>
        /// 
        /// </summary>
        public Index2[] Offsets
        {
            get { return _offsets; }
            set
            {
                if (value == null)
                    throw new ArgumentNullException();

                _offsets = value;
            }
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="rows"></param>
        /// <param name="columns"></param>
        public GameOfLife2D(int rows, int columns)
        {
            _currentState = new int[rows, columns];
            _nextState = new int[rows, columns];
        }


        /// <summary>
        /// 
        /// </summary>
        public void Step()
        {
            int nrows = _currentState.GetLength(0);
            int ncols = _currentState.GetLength(1); 

            // calculate next state
            for (int i = 0; i < nrows; i++)
            {
                for (int j = 0; j < ncols; j++)
                    Step(i, j);
            }
            
            // swap state buffers
            Swap(ref _currentState, ref _nextState);
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="i"></param>
        /// <param name="j"></param>
        private void Step(int i, int j)
        {
            int state = _currentState[i, j];
            int sum = GetNeighborSum(i, j);

            if (state == 0)
                _nextState[i, j] = (sum == 3) ? 1 : 0; // dead rule
            else
                _nextState[i, j] = (sum < 2 || sum > 3) ? 0 : 1; // alive rule
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="i0"></param>
        /// <param name="j0"></param>
        /// <returns></returns>
        private int GetNeighborSum(int i0, int j0)
        {
            var current = _currentState;
            int nrows = current.GetLength(0);
            int ncols = current.GetLength(1);
            int sum = 0;

            foreach(Index2 offset in _offsets)
            {
                int i1 = Wrap(i0 + offset.I, nrows);
                int j1 = Wrap(j0 + offset.J, ncols);

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
        /// <typeparam name="T"></typeparam>
        /// <param name="t0"></param>
        /// <param name="t1"></param>
        private static void Swap<T>(ref T t0, ref T t1)
        {
            var temp = t0;
            t0 = t1;
            t1 = temp;
        }
    }
}