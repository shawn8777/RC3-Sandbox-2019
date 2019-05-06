/*
 * Notes
 */

using UnityEngine;

using Domino;

namespace RC3.Unity.TilingDemo
{


    /// <summary>
    /// 
    /// </summary>
    public abstract class TileSelector : ScriptableObject, ITileSelector
    {
        public abstract int Select(TileModel model, int position);
    }
}
