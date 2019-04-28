/*
 * Notes
 */

using UnityEngine;

using Domino;

namespace RC3.TilingDemo
{
    /// <summary>
    /// 
    /// </summary>
    public abstract class TileSelector : ScriptableObject, ITileSelector
    {
        public abstract int Select(TileModel model, int node);
    }
}
