using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RC3.Unity.GraphIntro
{
    /// <summary>
    /// 
    /// </summary>
    public class GraphCreator : MonoBehaviour
    {
        [SerializeField] private Graph _graph;

        [Range(0.0f, 1.0f)]
        [SerializeField] private float _maxRadius = 0.125f;

        [Range(0, 1000)]
        [SerializeField] private int _vertexCount = 100;

        private float _lastMaxRadius = 0.0f;


        /// <summary>
        /// 
        /// </summary>
        private void Update()
        {
            const float tolerance = 1.0e-6f;

            // Rebuild graph if number of vertices has changed
            if (_vertexCount != _graph.Vertices.Count)
            {
                _graph.Clear();
                GraphFactory.AddVertices(_graph, _vertexCount);
                GraphFactory.AddRandomPositions(_graph);
                GraphFactory.AddColors(_graph, Color.black);
            }

            // Rebuild edges if radius has changed
            if (Mathf.Abs(_lastMaxRadius -_maxRadius) > tolerance)
            {
                _graph.ClearEdges();
                GraphFactory.AddEdgesByRange(_graph, _maxRadius);
                _lastMaxRadius = _maxRadius;
            }
        }
    }
}
