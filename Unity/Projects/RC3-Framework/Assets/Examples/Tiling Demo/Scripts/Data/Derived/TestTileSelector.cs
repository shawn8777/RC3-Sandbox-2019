/*
 * Notes
 */

using UnityEngine;
using System.Linq;

using Domino;

namespace RC3.Unity.TilingDemo.TileModelSelectors
{
    /// <summary>
    /// 
    /// </summary>
    [CreateAssetMenu(menuName = "RC3/TilingDemo/TileModelSelectors/Test")]
    public class TestTileSelector : TileSelector
    {
        /// <summary>
        /// 
        /// </summary>
        public override int Select(TileModel model, int position)
        {
            return model.GetDomain(position).First();
        }
    }
}
