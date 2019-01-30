using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RC3.Unity.GraphIntro
{
    /// <summary>
    /// 
    /// </summary>
    public class GraphProcessor : MonoBehaviour
    {
        [SerializeField] private Graph _graph;

        private Vector3[] _deltas = System.Array.Empty<Vector3>();


        /// <summary>
        /// 
        /// </summary>
        private void Update()
        {
            if(Input.GetKeyDown(KeyCode.Space))
            {
                var verts = _graph.Vertices;

                // Ensure delta buffer is large enough
                if (_deltas.Length < verts.Count)
                    _deltas = new Vector3[verts.Capacity];

                GraphFunctions.Assignment1(_graph, _deltas, 2);
            }
        }
    }
}
