using System;

namespace RC3
{
    /// <summary>
    /// 
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
        public int CountY
        {
            get { return _data.GetLength(0); }
        }

        /// <summary>
        /// 
        /// </summary>
        public int CountX
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
