using System.Collections.Generic;
using UnityEngine;

namespace RC3.TilingDemo
{
    /// <summary>
    /// 
    /// </summary>
    [CreateAssetMenu(menuName = "RC3/Tiling Demo/Tile Model History")]
    public class TileModelHistory : ScriptableObject
    {
        private List<int[]> _data = new List<int[]>();

        /// <summary>
        /// 
        /// </summary>
        public List<int[]> Data
        {
            get { return _data; }
        }
    }
}
