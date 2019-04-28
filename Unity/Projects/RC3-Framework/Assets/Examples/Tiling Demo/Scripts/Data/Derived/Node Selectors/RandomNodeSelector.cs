/*
 * Notes
 */

using UnityEngine;

using Domino;
using Domino.Collections;

namespace RC3.TilingDemo.TileModelSelectors
{
    /// <summary>
    /// 
    /// </summary>
    [CreateAssetMenu(menuName = "RC3/Tiling Demo/Node Selectors/Random")]
    public class RandomNodeSelector : NodeSelector
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
        public override int Select(TileModel model, ArrayView<int> nodes)
        {
            return nodes[_random.Next(nodes.Count)];
        }
    }
}
