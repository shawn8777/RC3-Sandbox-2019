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
        [SerializeField] private float _smoothStrength = 0.5f;

        // Delta buffers
        private Vector3[] _positionDeltas = System.Array.Empty<Vector3>();
        private Color[] _colorDeltas = System.Array.Empty<Color>();
        // ...
        // ...
        // ...
        // ...


        /// <summary>
        /// 
        /// </summary>
        private void Update()
        {
            var verts = _graph.Vertices;

            // Fix vertex zero to red
            _graph.Colors[0] = Color.red;

            if (Input.GetKeyDown(KeyCode.P))
            {
                _positionDeltas = ResizeBuffer(_graph, _positionDeltas);
                GraphFunctions.UniformSmooth(_graph, _positionDeltas, _smoothStrength);
            }

            if(Input.GetKeyDown(KeyCode.C))
            {
                _colorDeltas = ResizeBuffer(_graph, _colorDeltas);
                GraphFunctions.UniformSmooth(_graph, _colorDeltas, _smoothStrength);
            }
        }


        /// <summary>
        /// Ensure the given buffer is large enough
        /// </summary>
        private T[] ResizeBuffer<T>(Graph graph, T[] buffer)
        {
            var verts = graph.Vertices;

            if (buffer.Length < verts.Count)
                return new T[verts.Capacity];

            return buffer;
        }
    }
}
