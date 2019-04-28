
/*
   
    Notes

*/

using System;
using Domino;
using UnityEngine;

namespace RC3.DigitalNomad
{
    /// <summary>
    /// Tile selector that considers the objectives of the current actor
    /// </summary>
    [CreateAssetMenu(menuName = "RC3/DigitalNomad/TileSelector")]
    public class NomadTileSelector : TilingDemo.TileSelector
    {
        [SerializeField] private NomadActor _current; // Current actor selecting the tile

        // ...
        // ...
        // ...

        /// <summary>
        /// 
        /// </summary>
        public override int Select(TileModel model, int node)
        {
            // TODO
            throw new NotImplementedException();
        }
    }
}
