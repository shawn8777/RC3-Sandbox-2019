
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
        private IndexPair[] _offsets = Neighborhoods.MooreR1;


        /// <summary>
        /// 
        /// </summary>
        public ModelState CurrentState
        {
            get { return _currentState; }
        }


        /// <summary>
        /// 
        /// </summary>
        public IndexPair[] Offsets
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
        /// <param name="countX"></param>
        /// <param name="countY"></param>
        public GameOfLife2D(int countX, int countY)
        {
            _currentState = new int[countY, countX];
            _nextState = new int[countY, countX];
        }


        /// <summary>
        /// 
        /// </summary>
        public void Step()
        {
            int countY = _currentState.GetLength(0);
            int countX = _currentState.GetLength(1); 

            // calculate next state
            for (int y = 0; y < countY; y++)
            {
                for (int x = 0; x < countX; x++)
                    Step(y, x);
            }
            
            // swap state buffers
            Swap(ref _currentState, ref _nextState);
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="y"></param>
        /// <param name="x"></param>
        private void Step(int y, int x)
        {
            int state = _currentState[y, x];
            int sum = GetNeighborSum(y, x);

            if (state == 0)
                _nextState[y, x] = (sum == 3) ? 1 : 0; // dead rule
            else
                _nextState[y, x] = (sum < 2 || sum > 3) ? 0 : 1; // alive rule
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="y0"></param>
        /// <param name="x0"></param>
        /// <returns></returns>
        private int GetNeighborSum(int y0, int x0)
        {
            var current = _currentState;

            int countY = current.GetLength(0);
            int countX = current.GetLength(1);
            int sum = 0;

            foreach(IndexPair offset in _offsets)
            {
                int y1 = Wrap(y0 + offset.I, countY);
                int x1 = Wrap(x0 + offset.J, countX);

                if (current[y1, x1] > 0)
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