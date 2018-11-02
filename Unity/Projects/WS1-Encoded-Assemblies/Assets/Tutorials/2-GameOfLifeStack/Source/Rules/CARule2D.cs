
using System;

namespace RC3
{
    /// <summary>
    /// 
    /// </summary>
    public abstract class CARule2D : ICARule2D
    {
        private IndexPair[] _offsets = Neighborhoods.MooreR1;
        

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
        public abstract int NextAt(int i, int j, int[,] current);
    }
}