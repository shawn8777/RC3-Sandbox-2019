using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RC3.Unity.GraphIntro
{
    /// <summary>
    /// 
    /// </summary>
    [CreateAssetMenu(menuName = "RC3/Graph Intro/Graph")]
    public class Graph : ScriptableObject
    {
        // Topology
        private List<List<int>> _vertices = new List<List<int>>();

        // Geometry
        private List<Vector3> _positions = new List<Vector3>();
        private List<Color> _colors = new List<Color>();
        // ...
        // ...
        // ...
        // ...


        /// <summary>
        /// 
        /// </summary>
        public List<List<int>> Vertices
        {
            get { return _vertices; }
        }


        /// <summary>
        /// 
        /// </summary>
        public List<Vector3> Positions
        {
            get { return _positions; }
        }


        /// <summary>
        /// 
        /// </summary>
        public List<Color> Colors
        {
            get { return _colors; }
        }


        /// <summary>
        /// 
        /// </summary>
        public void Clear()
        {
            _vertices.Clear();
            _positions.Clear();
            _colors.Clear();
        }


        /// <summary>
        /// 
        /// </summary>
        public void ClearEdges()
        {
            for(int i = 0; i < _vertices.Count; i++)
                _vertices[i].Clear();
        }
    }
}
