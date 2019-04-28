using UnityEngine;

namespace RC3.TilingDemo
{
    /// <summary>
    /// 
    /// </summary>
    public abstract class UniformGraph : ScriptableObject
    {
        private int[,] _adjacency;


        /// <summary>
        /// Table containing adjacency information for each vertex in the graph. 
        /// Elements are accessed via [vertex index, direction].
        /// </summary>
        public int[,] Adjacency
        {
            get { return _adjacency; }
        }


        /// <summary>
        /// Returns the number of vertices in the graph.
        /// </summary>
        public int Count
        {
            get { return _adjacency.GetLength(0); }
        }


        /// <summary>
        /// Returns the degree of all vertices in the graph.
        /// </summary>
        public int Degree
        {
            get { return _adjacency.GetLength(1); }
        }


        /// <summary>
        /// 
        /// </summary>
        public virtual void Initialize(int vertexCount, int vertexDegree)
        {
            _adjacency = new int[vertexCount, vertexDegree];
            Set(_adjacency, -1);
        }


        /// <summary>
        /// 
        /// </summary>
        protected static void Set<T>(T[] source, T value)
        {
            int n = source.Length;

            for (int i = 0; i < n; i++)
                source[i] = value;
        }


        /// <summary>
        /// 
        /// </summary>
        protected static void Set<T>(T[,] source, T value)
        {
            int m = source.GetLength(0);
            int n = source.GetLength(1);

            for (int i = 0; i < m; i++)
            {
                for (int j = 0; j < n; j++)
                    source[i, j] = value;
            }
        }
    }
}
