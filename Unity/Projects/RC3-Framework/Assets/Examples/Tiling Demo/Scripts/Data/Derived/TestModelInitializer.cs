/*
 * Notes
 */

using UnityEngine;
using Domino;

namespace RC3.Unity.TilingDemo
{
    /// <summary>
    /// 
    /// </summary>
    [CreateAssetMenu(menuName = "RC3/TilingDemo/TileModelInitializers/Test")]
    public class TestModelInitializer : TileModelInitializer
    {
        [SerializeField] private int[] _allowedTiles;
        [SerializeField] private int _count;


        /// <summary>
        /// 
        /// </summary>
        /// <param name="model"></param>
        public override void Initialize(TileModel model)
        {
            for(int i = 0; i < _count; i++)
                model.SetDomain(i, _allowedTiles);
        }
    }
}
