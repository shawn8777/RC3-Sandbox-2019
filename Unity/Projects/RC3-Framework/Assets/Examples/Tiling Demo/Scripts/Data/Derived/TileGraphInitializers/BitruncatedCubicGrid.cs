/*
 * Notes
 * 
 * https://en.wikipedia.org/wiki/Bitruncated_cubic_honeycomb
 * https://en.wikipedia.org/wiki/Tetragonal_disphenoid_honeycomb
 */

using UnityEngine;


namespace RC3.Unity.TilingDemo.TileGraphInitializers
{
    /// <summary>
    /// 
    /// </summary>
    [CreateAssetMenu(menuName = "RC3/TilingDemo/TileGraphInitializers/BitruncatedCubicGrid")]
    public class BitruncatedCubicGrid : TileGraphInitializer
    {
        [SerializeField] private int _countX = 10;
        [SerializeField] private int _countY = 10;
        [SerializeField] private int _countZ = 10;


        /// <summary>
        /// 
        /// </summary>
        /// <param name="graph"></param>
        public override void Initialize(TileGraph graph)
        {
            CreateBitruncatedCubicGrid(graph, _countX, _countY, _countZ);
        }


        /// <summary>
        /// 
        /// </summary>
        private static void CreateBitruncatedCubicGrid(TileGraph graph, int countX, int countY, int countZ)
        {
            // TODO
        }


#if false
        
        
        /// <summary>
        /// 
        /// </summary>
        private G CreateTruncatedOctahedronGridUniform(int countX, int countY, int countZ)
        {
            var g = Create();
            int countXY = countX * countY;
            int count = countXY * countZ;

            int lastX = countX - 1;
            int lastY = countY - 1;
            int lastZ = countZ - 1;

            // add vertices
            for (int i = 0; i < count; i++)
            {
                g.AddVertex();
                g.AddVertex();
            }

            // add even layer edges
            for (int z = 0; z < countZ; z++)
            {
                for (int y = 0; y < countY; y++)
                {
                    for (int x = 0; x < countX; x++)
                    {
                        int i = x + y * countX + z * countXY;
                        int j = i + count;

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

                        // z-1
                        if (z > 0)
                            g.AddEdge(i, i - countXY);
                        else
                            g.AddEdge(i, i);

                        // z+1
                        if (z < lastZ)
                            g.AddEdge(i, i + countXY);
                        else
                            g.AddEdge(i, i);

                        // x-1, y-1, z-1
                        if (x > 0 && y > 0 && z > 0)
                            g.AddEdge(i, j - countXY - countX - 1);
                        else
                            g.AddEdge(i, i);

                        //
                        g.AddEdge(i, j);

                        // y-1, z-1
                        if (y > 0 && z > 0)
                            g.AddEdge(i, j - countXY - countX);
                        else
                            g.AddEdge(i, i);

                        // x-1
                        if (x > 0)
                            g.AddEdge(i, j - 1);
                        else
                            g.AddEdge(i, i);

                        // x-1, z-1
                        if (x > 0 && z > 0)
                            g.AddEdge(i, j - countXY - 1);
                        else
                            g.AddEdge(i, i);

                        // y-1
                        if (y > 0)
                            g.AddEdge(i, j - countX);
                        else
                            g.AddEdge(i, i);

                        // z-1
                        if (z > 0)
                            g.AddEdge(i, j - countXY);
                        else
                            g.AddEdge(i, i);

                        // x-1, y-1
                        if (x > 0 && y > 0)
                            g.AddEdge(i, j - countX - 1);
                        else
                            g.AddEdge(i, i);
                    }
                }
            }

            // add odd layer edges
            for (int z = 0; z < countZ; z++)
            {
                for (int y = 0; y < countY; y++)
                {
                    for (int x = 0; x < countX; x++)
                    {
                        int i = x + y * countX + z * countXY;
                        int j = i + count;

                        // x-1
                        if (x > 0)
                            g.AddEdge(j, j - 1);
                        else
                            g.AddEdge(j, j);

                        // x+1
                        if (x < lastX)
                            g.AddEdge(j, j + 1);
                        else
                            g.AddEdge(j, j);

                        // y-1
                        if (y > 0)
                            g.AddEdge(j, j - countX);
                        else
                            g.AddEdge(j, j);

                        // y+1
                        if (y < lastY)
                            g.AddEdge(j, j + countX);
                        else
                            g.AddEdge(j, j);

                        // z-1
                        if (z > 0)
                            g.AddEdge(j, j - countXY);
                        else
                            g.AddEdge(j, j);

                        // z+1
                        if (z < lastZ)
                            g.AddEdge(j, j + countXY);
                        else
                            g.AddEdge(j, j);

                        //
                        g.AddEdge(j, i);

                        // x+1, y+1, z+1
                        if (x < lastX && y < lastY && z < lastZ)
                            g.AddEdge(j, i + countXY + countX + 1);
                        else
                            g.AddEdge(j, j);

                        // x+1
                        if (x < lastX)
                            g.AddEdge(j, i + 1);
                        else
                            g.AddEdge(j, j);

                        // y+1, z+1
                        if (y < lastY && z < lastZ)
                            g.AddEdge(j, i + countXY + countX);
                        else
                            g.AddEdge(j, j);

                        // y+1
                        if (y < lastY)
                            g.AddEdge(j, i + countX);
                        else
                            g.AddEdge(j, j);

                        // x+1, z+1
                        if (x < lastX && z < lastZ)
                            g.AddEdge(j, i + countXY + 1);
                        else
                            g.AddEdge(j, j);

                        // x+1, y+1
                        if (x < lastX && y < lastY)
                            g.AddEdge(j, i + countX + 1);
                        else
                            g.AddEdge(j, j);
                        
                        // z+1
                        if (z < lastZ)
                            g.AddEdge(j, i + countXY);
                        else
                            g.AddEdge(j, j);
                    }
                }
            }

            return g;
        }

#endif
    }
}
