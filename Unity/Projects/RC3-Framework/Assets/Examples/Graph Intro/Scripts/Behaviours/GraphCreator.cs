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


        /// <summary>
        /// 
        /// </summary>
        private void Update()
        {
            if (_vertexCount != _graph.Vertices.Count)
            {
                _graph.Clear();
                GraphFactory.CreateScatterGraph(_graph, _maxRadius, _vertexCount);
            }
            else
            {
                _graph.ClearEdges();
                GraphFactory.AddEdgesByRange(_graph, _maxRadius);
            }
        }
    }
}
