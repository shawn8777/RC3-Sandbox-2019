/*
 * Notes
 */

using System;
using UnityEngine;

namespace RC3.TilingDemo
{
    /// <summary>
    /// 
    /// </summary>
    public abstract class TileGraphInitializer : ScriptableObject, IInitializer<TileGraph>
    {
        public abstract void Initialize(TileGraph target);
    }
}
