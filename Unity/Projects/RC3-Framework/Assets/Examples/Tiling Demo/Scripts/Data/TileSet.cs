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
    [CreateAssetMenu(menuName = "RC3/TilingDemo/TileSet")]
    public class TileSet : ScriptableObject
    {
        [SerializeField, HideInInspector] private Tile[] _tiles;

        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="i"></param>
        /// <returns></returns>
        public Tile this[int i]
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
        public TileMap<string> CreateMap()
        {
            var degree = _tiles[0].Labels.Length;
            var map = new TileMap<string>(degree, Count);

            for (int i = 0; i < _tiles.Length; i++)
            {
                var labels = _tiles[i].Labels;
                
                for (int j = 0; j < degree; j++)
                    map.SetLabel(j, i, labels[j]);
            }

            return map;
        }
    }
}
