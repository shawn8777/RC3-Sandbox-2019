/*
 * Notes
 */

using UnityEngine;

using Domino;
using Domino.Collections;

namespace RC3.TilingDemo
{
    /// <summary>
    /// 
    /// </summary>
    public abstract class NodeSelector : ScriptableObject, INodeSelector
    {
        public abstract int Select(TileModel model, ArrayView<int> nodes);
    }
}
