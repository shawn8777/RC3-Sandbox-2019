/*
 * Notes
 */

using UnityEngine;

namespace RC3.Unity.TilingDemo.TileGraphInitializers
{
    /// <summary>
    /// 
    /// </summary>
    [CreateAssetMenu(menuName = "RC3/TilingDemo/TileGraphInitializers/CubicGrid")]
    public class CubicGrid : TileGraphInitializer
    {
        [SerializeField] private int _countX = 10;
        [SerializeField] private int _countY = 10;
        [SerializeField] private int _countZ = 10;


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
        public int CountZ
        {
            get { return _countZ; }
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="graph"></param>
        public override void Initialize(TileGraph graph)
        {
            CreateCubicGrid(graph, _countX, _countY, _countZ);
        }


        /// <summary>
        /// 
        /// </summary>
        private static void CreateCubicGrid(TileGraph graph, int countX, int countY, int countZ)
        {
            int nxy = countX * countY;
            graph.Initialize(nxy * countZ, 6);

            var verts = graph.Vertices;
            var positions = graph.Positions;

            int lastX = countX - 1;
            int lastY = countY - 1;
            int lastZ = countZ - 1;

            float x0 = countX * -0.5f;
            float y0 = countY * -0.5f;
            float z0 = countZ * -0.5f;

            for (int z = 0; z < countZ; z++)
            {
                for (int y = 0; y < countY; y++)
                {
                    for (int x = 0; x < countX; x++)
                    {
                        int i = x + y * countX + z * nxy;
                        positions[i] = new Vector3(x + x0, y + y0, z + z0);

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

                        // z-1
                        if (z > 0)
                            verts[i, 4] = i - nxy;

                        // y+1
                        if (z < lastZ)
                            verts[i, 5] = i + nxy;
                    }
                }
            }
        }
    }
}
