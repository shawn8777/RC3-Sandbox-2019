using UnityEngine;

using Domino;

namespace RC3.TilingDemo
{
    /// <summary>
    /// 
    /// </summary>
    public abstract class TileModelInitializer : ScriptableObject
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="model"></param>
        public abstract void Initialize(TileModel model, TileGraph graph);
    }
}
