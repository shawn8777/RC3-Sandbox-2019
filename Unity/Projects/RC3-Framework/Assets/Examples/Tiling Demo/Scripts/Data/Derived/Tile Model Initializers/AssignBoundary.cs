using UnityEngine;

using Domino;

namespace RC3.TilingDemo
{
    /// <summary>
    /// 
    /// </summary>
    [CreateAssetMenu(menuName = "RC3/Tiling Demo/Tile Model Initializers/Assign Boundary")]
    public class AssignBoundary : TileModelInitializer
    {
        [SerializeField] private int[] _domain;


        /// <summary>
        /// 
        /// </summary>
        /// <param name="model"></param>
        public override void Initialize(TileModel model, TileGraph graph)
        {
            var adj = graph.Adjacency;
            int m = adj.GetLength(0);
            int n = adj.GetLength(1);

            for (int i = 0; i < m; i++)
            {
                bool boundary = false;
                {
                    for (int j = 0; j < n; j++)
                    {
                        if (adj[i, j] < 0)
                        {
                            boundary = true;
                            break;
                        }
                    }
                }

                if (boundary)
                    model.SetDomain(i, _domain);
            }
        }
    }
}
