using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RC3.Unity.GraphIntro
{
    /// <summary>
    /// 
    /// </summary>
    [CreateAssetMenu(menuName = "RC3/GraphIntro/Graph")]
    public class Graph : ScriptableObject
    {
        // Topology
        private List<List<int>> _vertices = new List<List<int>>();

        // Geometry
        private List<Vector3> _positions = new List<Vector3>();
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
    }
}
