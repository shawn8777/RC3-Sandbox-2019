using UnityEngine;

namespace RC3.Unity.TilingDemo
{
    /// <summary>
    /// 
    /// </summary>
    public class TileModelRecorderData : MonoBehaviour
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
    }
}
