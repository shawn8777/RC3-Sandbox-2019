/*
 * Notes
 */

using UnityEngine;

namespace RC3.Unity.TilingDemo.TileGraphInitializers
{
    /// <summary>
    /// 
    /// </summary>
    [CreateAssetMenu(menuName = "RC3/TilingDemo/TileGraphInitializers/SquareGrid")]
    public class SquareGrid : TileGraphInitializer
    {
        [SerializeField] private int _countX = 10;
        [SerializeField] private int _countY = 10;


        /// <summary>
        /// 
        /// </summary>
        public int CountX
        {
            get { return _countX; }
        }


        /// <summary>
        /// 
        /// </summary>
        public int CountY
        {
            get { return _countY; }
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="graph"></param>
        public override void Initialize(TileGraph graph)
        {
            CreateSquareGrid(graph, _countX, _countY);
        }


        /// <summary>
        /// 
        /// </summary>
        private static void CreateSquareGrid(TileGraph graph, int countX, int countY)
        {
            graph.Initialize(countX * countY, 4);

            var verts = graph.Adjacency;
            var positions = graph.Positions;

            int lastX = countX - 1;
            int lastY = countY - 1;

            for (int y = 0; y < countY; y++)
            {
                for (int x = 0; x < countX; x++)
                {
                    int i = x + y * countX;
                    positions[i] = new Vector3(x, y, 0);

                    // x-1
                    if (x > 0)
                        verts[i, 0] = i - 1;

                    // x+1
                    if (x < lastX)
                        verts[i, 1] = i + 1;

                    // y-1
                    if (y > 0)
                        verts[i, 2] = i - countX;

                    // y+1
                    if (y < lastY)
                        verts[i, 3] = i + countX;
                }
            }
        }
    }
}
