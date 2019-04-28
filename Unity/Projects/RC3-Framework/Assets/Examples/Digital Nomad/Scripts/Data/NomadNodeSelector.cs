
/*
   
    Notes

    - Each actor needs a way of tracking the type of space it has and comparing it to the type of space it wants.
    - Ideally this should just be a matter of summing up attributes over the tiles it has placed.

    TODO

    - Finish implementation

*/

using System;
using Domino;
using Domino.Collections;
using UnityEngine;

namespace RC3.DigitalNomad
{
    /// <summary>
    /// Node selector that considers the objectives of the current actor
    /// </summary>
    [CreateAssetMenu(menuName = "RC3/DigitalNomad/NodeSelector")]
    public class NomadNodeSelector : TilingDemo.NodeSelector
    {
        [SerializeField] private NomadActor _current; // Current actor selecting the tile

        // ...
        // ...
        // ...

        /// <summary>
        /// 
        /// </summary>
        public override int Select(TileModel model, ArrayView<int> nodes)
        {
            // TODO
            throw new NotImplementedException();
        }
    }
}
