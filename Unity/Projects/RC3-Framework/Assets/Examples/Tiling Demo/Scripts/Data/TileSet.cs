﻿/*
 * Notes
 */

using UnityEngine;

using Domino;

namespace RC3.TilingDemo
{
    /// <summary>
    /// 
    /// </summary>
    public abstract class TileSet : ScriptableObject
    {
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public abstract TileMap CreateMap();
    }
}