/*
 * Notes
 */

using UnityEngine;
using Domino;

namespace RC3.Unity.TilingDemo.TileModelInitializers
{
    /// <summary>
    /// 
    /// </summary>
    [CreateAssetMenu(menuName = "RC3/TilingDemo/TileModelInitializers/AssignBoundary")]
    public class AssignBoundary : TileModelInitializer
    {
        [SerializeField] private TileGraph _graph;
        [SerializeField] private int[] _tiles;


        /// <summary>
        /// 
        /// </summary>
        /// <param name="model"></param>
        public override void Initialize(TileModel model)
        {
            var verts = _graph.Vertices;

            int m = verts.GetLength(0);
            int n = verts.GetLength(1);

            for (int i = 0; i < m; i++)
            {
                bool boundary = false;
                {
                    for (int j = 0; j < n; j++)
                    {
                        if (verts[i, j] < 0)
                        {
                            boundary = true;
                            break;
                        }
                    }
                }

                if (boundary)
                    model.SetDomain(i, _tiles);
            }
        }
    }
}
