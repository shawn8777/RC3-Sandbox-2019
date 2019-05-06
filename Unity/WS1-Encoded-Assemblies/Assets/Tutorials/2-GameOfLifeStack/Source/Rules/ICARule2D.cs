﻿namespace RC3
{
    /// <summary>
    /// 
    /// </summary>
    public interface ICARule2D
    {
        /// <summary>
        /// Calculates the next state at the given index
        /// </summary>
        int NextAt(Index2 index, int[,] current);
    }
}