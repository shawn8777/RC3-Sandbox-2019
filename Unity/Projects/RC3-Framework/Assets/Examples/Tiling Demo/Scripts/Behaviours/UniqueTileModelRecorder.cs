using System.Linq;
using UnityEngine;

using SpatialSlur;

namespace RC3.Unity.TilingDemo
{
    /// <summary>
    /// Only records new model results i.e. those which don't yet exist in the history
    /// </summary>
    [RequireComponent(typeof(TileModelRecorderData))]
    public class UniqueTileModelRecorder : MonoBehaviour
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
            var indices = _graph.TileIndices;

            if (IsUnique(indices))
                _history.Data.Add(indices.ShallowCopy());
        }


        /// <summary>
        /// 
        /// </summary>
        private bool IsUnique(int[] indices)
        {
            var data = _history.Data;

            for(int i = 0; i < data.Count; i++)
            {
                if (Equals(indices, data[i]))
                    return false;
            }

            return true;
        }


        /// <summary>
        /// 
        /// </summary>
        public static bool Equals(int[] a, int[] b)
        {
            for (int i = 0; i < a.Length; i++)
            {
                if (a[i] != b[i])
                    return false;
            }

            return true;
        }
    }
}
