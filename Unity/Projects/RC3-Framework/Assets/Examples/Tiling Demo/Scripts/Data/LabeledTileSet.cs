/*
 * Notes
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Domino;

namespace RC3.Unity.TilingDemo
{
    /// <summary>
    /// 
    /// </summary>
    [CreateAssetMenu(menuName = "RC3/TilingDemo/LabeledTileSet")]
    public class LabeledTileSet : TileSet
    {
        #region Static

        /// <summary>
        /// 
        /// </summary>
        private static readonly Dictionary<TileType, int> _degrees = new Dictionary<TileType, int>()
        {
            {TileType.Triangle, 3},
            {TileType.Square, 4},
            {TileType.Rhombus, 4},
            {TileType.Hexagon, 6},
            {TileType.Cube, 6},
            {TileType.TruncatedOctahedron, 14},
        };

        #endregion


        [SerializeField, HideInInspector] private LabeledTile[] _tiles;
        [SerializeField] private TileType _type;

        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="i"></param>
        /// <returns></returns>
        public LabeledTile this[int i]
        {
            get { return _tiles[i]; }
        }


        /// <summary>
        /// 
        /// </summary>
        public int Count
        {
            get { return _tiles.Length; }
        }

        
        /// <summary>
        /// 
        /// </summary>
        public override TileMap CreateMap()
        {
            var map = new LabeledTileMap<string>(_type, Count);
            var degree = _degrees[_type];

            for (int i = 0; i < _tiles.Length; i++)
            {
                var labels = _tiles[i].Labels;

                if (labels.Length != degree)
                    throw new System.ArgumentException("Unexpected number of tile labels");
                
                for (int j = 0; j < degree; j++)
                    map.SetLabel(j, i, labels[j]);
            }

            return map;
        }
    }
}
