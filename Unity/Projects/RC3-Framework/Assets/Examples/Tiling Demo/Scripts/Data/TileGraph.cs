using System.Collections;
using UnityEngine;

namespace RC3.Unity.TilingDemo
{
    /// <summary>
    /// 
    /// </summary>
    [CreateAssetMenu(menuName = "RC3/TilingDemo/TileGraph")]
    public class TileGraph : UniformGraph
    {
        [SerializeField] private LabeledTileSet _tileSet;

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
        public override void Initialize(int vertexCount, int vertexDegree)
        {
            base.Initialize(vertexCount, vertexDegree);

            _tileIndices = new int[vertexCount];
            Set(_tileIndices, -1);

            _positions = new Vector3[vertexCount];
            // ...
            // ...
        }
    }
}
