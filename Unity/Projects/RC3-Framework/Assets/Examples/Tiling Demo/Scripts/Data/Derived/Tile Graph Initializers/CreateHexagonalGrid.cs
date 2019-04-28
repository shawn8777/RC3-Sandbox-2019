/*
 * Notes
 */

using UnityEngine;


namespace RC3.TilingDemo.TileGraphInitializers
{
    /// <summary>
    /// 
    /// </summary>
    [CreateAssetMenu(menuName = "RC3/Tiling Demo/Tile Graph Initializers/Create Hexagonal Grid")]
    public class CreateHexagonalGrid : TileGraphInitializer
    {
        [SerializeField] private int _countX = 10;
        [SerializeField] private int _countY = 10;


        /// <summary>
        /// 
        /// </summary>
        /// <param name="graph"></param>
        public override void Initialize(TileGraph graph)
        {
            CreateHexagonalGridImpl(graph, _countX, _countY);
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="graph"></param>
        /// <param name="countX"></param>
        /// <param name="countY"></param>
        private static void CreateHexagonalGridImpl(TileGraph graph, int countX, int countY)
        {
            // TODO
        }


#if false
        /// <summary>
        /// 
        /// </summary>
        private G CreateHexagonGridUniform(int countX, int countY)
        {
            var g = Create();
            int n = countX * countY;

            var lastX = countX - 1;
            var lastY = countY - 1;

            // add vertices
            for (int i = 0; i < n; i++)
                g.AddVertex();

            // add even row edges
            for (int y = 0; y < countY; y += 2)
            {
                for (int x = 0; x < countX; x++)
                {
                    int i = x + y * countX;

                    // x-1
                    if (x > 0)
                        g.AddEdge(i, i - 1);
                    else
                        g.AddEdge(i, i);

                    // x+1
                    if (x < lastX)
                        g.AddEdge(i, i + 1);
                    else
                        g.AddEdge(i, i);

                    // x-1, y-1
                    if (x > 0 && y > 0)
                        g.AddEdge(i, i - countX - 1);
                    else
                        g.AddEdge(i, i);

                    // x-1, y+1
                    if (x > 0 && y < lastY)
                        g.AddEdge(i, i + countX - 1);
                    else
                        g.AddEdge(i, i);

                    // y-1
                    if (y > 0)
                        g.AddEdge(i, i - countX);
                    else
                        g.AddEdge(i, i);

                    // y+1
                    if (y < lastY)
                        g.AddEdge(i, i + countX);
                    else
                        g.AddEdge(i, i);
                }
            }

            // add odd row edges
            for (int y = 1; y < countY; y += 2)
            {
                for (int x = 0; x < countX; x++)
                {
                    int i = x + y * countX;

                    // x-1
                    if (x > 0)
                        g.AddEdge(i, i - 1);
                    else
                        g.AddEdge(i, i);

                    // x+1
                    if (x < lastX)
                        g.AddEdge(i, i + 1);
                    else
                        g.AddEdge(i, i);

                    // y-1
                    if (y > 0)
                        g.AddEdge(i, i - countX);
                    else
                        g.AddEdge(i, i);

                    // y+1
                    if (y < lastY)
                        g.AddEdge(i, i + countX);
                    else
                        g.AddEdge(i, i);

                    // x+1, y-1
                    if (x < lastX && y > 0)
                        g.AddEdge(i, i - countX + 1);
                    else
                        g.AddEdge(i, i);

                    // x+1, y+1
                    if (x < lastX && y < lastY)
                        g.AddEdge(i, i + countX + 1);
                    else
                        g.AddEdge(i, i);
                }
            }

            return g;
        }
#endif
    }
}
