/*
 * Notes
 */

using UnityEngine;

namespace RC3.TilingDemo.TileGraphInitializers
{
    /// <summary>
    /// 
    /// </summary>
    [CreateAssetMenu(menuName = "RC3/Tiling Demo/Tile Graph Initializers/Create Cubic Grid")]
    public class CreateCubicGrid : TileGraphInitializer
    {
        [SerializeField] private Vector3Int _count = new Vector3Int(10, 10, 10);
        [SerializeField] private Vector3 _scale = new Vector3(1.0f, 1.0f, 1.0f);


        /// <summary>
        /// 
        /// </summary>
        public Vector3Int Count
        {
            get { return _count; }
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="graph"></param>
        public override void Initialize(TileGraph graph)
        {
            CreateCubicGridImpl(graph, _count.x, _count.y, _count.z, _scale.x, _scale.y, _scale.z);
        }


        /// <summary>
        /// 
        /// </summary>
        private static void CreateCubicGridImpl(TileGraph graph, int countX, int countY, int countZ, float scaleX, float scaleY, float scaleZ)
        {
            int nxy = countX * countY;
            graph.Initialize(nxy * countZ, 6);

            var verts = graph.Adjacency;
            var positions = graph.Positions;

            int lastX = countX - 1;
            int lastY = countY - 1;
            int lastZ = countZ - 1;

            for (int z = 0; z < countZ; z++)
            {
                for (int y = 0; y < countY; y++)
                {
                    for (int x = 0; x < countX; x++)
                    {
                        int i = x + y * countX + z * nxy;
                        positions[i] = new Vector3(x * scaleX, y * scaleY, z * scaleZ);

                        // -x
                        if (x > 0)
                            verts[i, 0] = i - 1;

                        // +x
                        if (x < lastX)
                            verts[i, 1] = i + 1;

                        // -y
                        if (y > 0)
                            verts[i, 2] = i - countX;

                        // +y
                        if (y < lastY)
                            verts[i, 3] = i + countX;

                        // -z
                        if (z > 0)
                            verts[i, 4] = i - nxy;

                        // +z
                        if (z < lastZ)
                            verts[i, 5] = i + nxy;
                    }
                }
            }
        }
    }
}
