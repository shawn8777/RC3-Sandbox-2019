using UnityEngine;

using SpatialSlur;

namespace RC3.Unity.TilingDemo
{
    /// <summary>
    /// 
    /// </summary>
    [RequireComponent(typeof(TileModelRecorderData))]
    public class TileModelRecorder : MonoBehaviour
    {
        private TileModelHistory _history;
        private TileGraph _graph;


        /// <summary>
        /// 
        /// </summary>
        private void Start()
        {
            var data = GetComponent<TileModelRecorderData>();
            _history = data.History;
            _graph = data.Graph;
        }


        /// <summary>
        /// 
        /// </summary>
        public void Record()
        {
            _history.Data.Add(_graph.TileIndices.ShallowCopy());
        }
    }
}
