/*
 * Notes
 */
 
using System.Linq;
using UnityEngine;

using Domino;

namespace RC3.Unity.TilingDemo.TileModelSelectors
{
    /// <summary>
    /// 
    /// </summary>
    [CreateAssetMenu(menuName = "RC3/Tiling Demo/Tile Model Selectors/Random")]
    public class RandomTileSelector : TileSelector
    {
        [SerializeField] private int _seed = 0;

        private System.Random _random;


        /// <summary>
        /// 
        /// </summary>
        private void OnEnable()
        {
            _random = new System.Random(_seed);
        }


        /// <summary>
        /// 
        /// </summary>
        public override int Select(TileModel model, int position)
        {
            var d = model.GetDomain(position);
            return d.ElementAt(_random.Next(d.Count));
        }
    }
}
