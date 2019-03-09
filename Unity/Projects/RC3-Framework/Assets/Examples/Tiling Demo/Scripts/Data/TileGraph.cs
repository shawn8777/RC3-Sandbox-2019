using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RC3.Unity.TilingDemo
{
    /// <summary>
    /// 
    /// </summary>
    [CreateAssetMenu(menuName = "RC3/TilingDemo/TileGraph")]
    public class TileGraph : ScriptableObject
    {
        [SerializeField] private LabeledTileSet _tileSet;

        // Topology
        private int[,] _vertices;

        // Attributes
        private Vector3[] _positions;
        private int[] _tileIndices;
        // ...
        // ...
        // ...

        
        /// <summary>
        /// 
        /// </summary>
        public LabeledTileSet TileSet
        {
            get { return _tileSet; }
        }


        /// <summary>
        /// 
        /// </summary>
        public int[,] Vertices
        {
            get { return _vertices; }
        }


        /// <summary>
        /// 
        /// </summary>
        public Vector3[] Positions
        {
            get { return _positions; }
        }


        /// <summary>
        /// 
        /// </summary>
        public int[] TileIndices
        {
            get { return _tileIndices; }
        }


        /// <summary>
        /// 
        /// </summary>
        public void Initialize(int vertexCount, int vertexDegree)
        {
            _vertices = new int[vertexCount, vertexDegree];
            Set(_vertices, -1);

            _tileIndices = new int[vertexCount];
            Set(_tileIndices, -1);

            _positions = new Vector3[vertexCount];
        }


        /// <summary>
        /// 
        /// </summary>
        private static void Set<T>(T[] source, T value)
        {
            int n = source.Length;

            for (int i = 0; i < n; i++)
                source[i] = value;
        }


        /// <summary>
        /// 
        /// </summary>
        private static void Set<T>(T[,] source, T value)
        {
            int m = source.GetLength(0);
            int n = source.GetLength(1);
            
            for(int i = 0; i < m; i++)
            {
                for (int j = 0; j < n; j++)
                    source[i, j] = value;
            }
        }
    }
}
