using System.Collections.Generic;
using UnityEngine;

namespace RC3.Unity.TilingDemo
{
    /// <summary>
    /// 
    /// </summary>
    [CreateAssetMenu(menuName = "RC3/TilingDemo/TileModelHistory")]
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
