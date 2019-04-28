using UnityEngine;

using SpatialSlur;

namespace RC3.TilingDemo
{
    /// <summary>
    /// 
    /// </summary>
    public class TileModelRecorder : MonoBehaviour
    {
        [SerializeField] private TileModelHistory _history;
        [SerializeField] private TileGraph _graph;


        /// <summary>
        /// 
        /// </summary>
        public TileModelHistory History
        {
            get { return _history; }
        }


        /// <summary>
        /// 
        /// </summary>
        public TileGraph Graph
        {
            get { return _graph; }
        }


        /// <summary>
        /// 
        /// </summary>
        public virtual void Record()
        {
            _history.Data.Add(_graph.AssignedTiles.ShallowCopy());
        }
    }
}
