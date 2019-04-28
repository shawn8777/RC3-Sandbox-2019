using System.Collections.Generic;
using System.Linq;

using UnityEngine;

using Domino.Collections;

namespace RC3.TilingDemo
{ 
    /// <summary>
    /// 
    /// </summary>
    [CreateAssetMenu(menuName = "RC3/Tiling Demo/Tile Graph")]
    public class TileGraph : UniformGraph
    {
        [SerializeField] private LabeledTileSet _tileSet;

        // Attributes
        private Vector3[] _positions;
        private int[] _assignedTiles;
        private int[] _domainSizes;
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
        public int[] AssignedTiles
        {
            get { return _assignedTiles; }
        }


        /// <summary>
        /// 
        /// </summary>
        public int[] DomainSizes
        {
            get { return _domainSizes; }
        }


        /// <summary>
        /// 
        /// </summary>
        public override void Initialize(int vertexCount, int vertexDegree)
        {
            base.Initialize(vertexCount, vertexDegree);
            
            _assignedTiles = new int[vertexCount];
            Set(_assignedTiles, -1);

            _domainSizes = new int[vertexCount];
            Set(_domainSizes, _tileSet.Count);

            _positions = new Vector3[vertexCount];
            // ...
            // ...
        }
    }
}
