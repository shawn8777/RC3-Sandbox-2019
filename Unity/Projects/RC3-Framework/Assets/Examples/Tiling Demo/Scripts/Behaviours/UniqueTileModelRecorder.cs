using System.Linq;
using UnityEngine;

using SpatialSlur;

namespace RC3.TilingDemo
{
    /// <summary>
    /// Only records new model results i.e. those which don't yet exist in the history
    /// </summary>
    public class UniqueTileModelRecorder : TileModelRecorder
    {
        /// <summary>
        /// 
        /// </summary>
        public override void Record()
        {
            var indices = Graph.AssignedTiles;

            if (IsUnique(indices))
                History.Data.Add(indices.ShallowCopy());
        }


        /// <summary>
        /// 
        /// </summary>
        private bool IsUnique(int[] indices)
        {
            var data = History.Data;

            for(int i = 0; i < data.Count; i++)
            {
                if (Equals(indices, data[i]))
                    return false;
            }

            return true;
        }


        /// <summary>
        /// 
        /// </summary>
        private static bool Equals(int[] a, int[] b)
        {
            for (int i = 0; i < a.Length; i++)
            {
                if (a[i] != b[i])
                    return false;
            }

            return true;
        }
    }
}
