/*
 * Notes
 */

using System.Linq;
using UnityEngine;

using Domino;

namespace RC3.TilingDemo.TileModelSelectors
{
    /// <summary>
    /// 
    /// </summary>
    [CreateAssetMenu(menuName = "RC3/Tiling Demo/Tile Selectors/Random")]
    public class RandomTileSelector : TileSelector
    {
        [SerializeField] private int _seed = 0;

        private Domino.RandomTileSelector _selector;


        /// <summary>
        /// 
        /// </summary>
        private void OnEnable()
        {
            _selector = new Domino.RandomTileSelector(_seed);
        }


        /// <summary>
        /// 
        /// </summary>
        public override int Select(TileModel model, int node)
        {
            return _selector.Select(model, node);
        }
    }
}
