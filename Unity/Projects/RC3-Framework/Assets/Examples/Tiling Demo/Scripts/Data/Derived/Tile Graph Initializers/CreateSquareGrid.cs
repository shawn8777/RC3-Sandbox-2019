/*
 * Notes
 */

using UnityEngine;

namespace RC3.TilingDemo.TileGraphInitializers
{
    /// <summary>
    /// 
    /// </summary>
    [CreateAssetMenu(menuName = "RC3/Tiling Demo/Tile Graph Initializers/Create Square Grid")]
    public class CreateSquareGrid : TileGraphInitializer
    {
        [SerializeField] private Vector2Int _count = new Vector2Int(1, 1);
        [SerializeField] private Vector2 _scale = new Vector2(1.0f, 1.0f);


        /// <summary>
        /// 
        /// </summary>
        public Vector2Int Count
        {
            get { return _count; }
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="graph"></param>
        public override void Initialize(TileGraph graph)
        {
            CreateSquareGridImpl(graph, _count.x, _count.y, _scale.x, _scale.y);
        }


        /// <summary>
        /// 
        /// </summary>
        private static void CreateSquareGridImpl(TileGraph graph, int countX, int countY, float scaleX, float scaleY)
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
                    positions[i] = new Vector3(x * scaleX, y * scaleY, 0);

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
