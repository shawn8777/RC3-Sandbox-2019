
using System;

namespace RC3
{
    /// <summary>
    /// Rule for Conway's game of life
    /// </summary>
    public class Conway2D : CARule2D
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="offsets"></param>
        public Conway2D(IndexPair[] offsets)
        {
            Offsets = offsets;
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="i"></param>
        /// <param name="j"></param>
        /// <param name="current"></param>
        /// <returns></returns>
        public override int NextAt(int i, int j, int[,] current)
        {
            int sum = GetNeighborSum(i, j, current);
            int state = current[i, j];

            if (state == 0)
                return (sum == 3) ? 1 : 0;
            else
                return (sum < 2 || sum > 3) ? 0 : 1;
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="i0"></param>
        /// <param name="j0"></param>
        /// <returns></returns>
        private int GetNeighborSum(int i0, int j0, int[,] current)
        {
            int m = current.GetLength(0);
            int n = current.GetLength(1);
            int sum = 0;

            foreach (IndexPair offset in Offsets)
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