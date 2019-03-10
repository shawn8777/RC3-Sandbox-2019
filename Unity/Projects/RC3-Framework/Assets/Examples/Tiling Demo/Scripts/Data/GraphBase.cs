using UnityEngine;

namespace RC3.Unity.TilingDemo
{
    /// <summary>
    /// 
    /// </summary>
    public abstract class GraphBase : ScriptableObject
    {
        private int[,] _adjacency;


        /// <summary>
        /// [Vertex Index, Direction]
        /// </summary>
        public int[,] Adjacency
        {
            get { return _adjacency; }
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
