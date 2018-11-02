using System;

namespace RC3
{
    /// <summary>
    /// Lightweight wrapper for a 2D array of integers
    /// </summary>
    [Serializable]
    public struct ModelState
    {
        /// <summary>
        /// 
        /// </summary>
        public static implicit operator int[,](ModelState state)
        {
            return state._data;
        }
        
        /// <summary>
        /// 
        /// </summary>
        public static implicit operator ModelState (int[,] data)
        {
            return new ModelState(data);
        }

        private int[,] _data;

        /// <summary>
        /// 
        /// </summary>
        private ModelState(int[,] data)
        {
            _data = data;
        }
            
        /// <summary>
        /// 
        /// </summary>
        public int Rows
        {
            get { return _data.GetLength(0); }
        }

        /// <summary>
        /// 
        /// </summary>
        public int Columns
        {
            get { return _data.GetLength(1); }
        }

        /// <summary>
        /// 
        /// </summary>
        public int Count
        {
            get { return _data.Length; }
        }
    }
}
