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
    public abstract class TileModelInitializer : Initializer<TileModel>
    {
        private TileGraph _graph;


        /// <summary>
        /// 
        /// </summary>
        public TileGraph Graph
        {
            get { return _graph; }
            set { _graph = value; }
        }
    }
}
