﻿using System.Collections.Generic;
using UnityEngine;

namespace RC3.Unity.GraphIntro
{
    /// <summary>
    /// 
    /// </summary>
    public static class GraphFactory
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="count"></param>
        public static void AddVertices(Graph graph, int count)
        {
            var verts = graph.Vertices;
            
            for (int i = 0; i < count; i++)
                verts.Add(new List<int>());
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="graph"></param>
        public static void AddRandomPositions(Graph graph)
        {
            var verts = graph.Vertices;
            var positions = graph.Positions;

            var random = new System.Random(1);

            while (positions.Count < verts.Count)
            {
                float x = (float)random.NextDouble();
                float y = (float)random.NextDouble();
                float z = (float)random.NextDouble();
                positions.Add(new Vector3(x, y, z));
            }
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="graph"></param>
        public static void AddColors(Graph graph, Color color)
        {
            var verts = graph.Vertices;
            var colors = graph.Colors;

            while (colors.Count < verts.Count)
                colors.Add(color);
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="graph"></param>
        /// <param name="radius"></param>
        public static void AddEdgesByRange(Graph graph, float radius)
        {
            var verts = graph.Vertices;
            var positions = graph.Positions;

            float sqrRad = radius * radius;
            
            for (int i = 0; i < verts.Count; i++)
            {
                for (int j = i + 1; j < verts.Count; j++)
                {
                    var sqrDist = (positions[i] - positions[j]).sqrMagnitude;

                    if (sqrDist < sqrRad)
                    {
                        verts[i].Add(j);
                        verts[j].Add(i);
                    }
                }
            }
        }


        /// <summary>
        /// 
        /// </summary>
        public static void CreateTestGraph0(Graph graph)
        {
            var verts = graph.Vertices;
            const int nv = 6;

            // Add vertices
            {
                for (int i = 0; i < nv; i++)
                    verts.Add(new List<int>());

                Debug.Log($"The graph has {verts.Count} vertices.");
            }

            // Add edges
            {
                verts[0].Add(2);
                verts[2].Add(0);

                verts[1].Add(3);
                verts[3].Add(1);

                verts[2].Add(3);
                verts[3].Add(2);

                verts[2].Add(4);
                verts[4].Add(2);

                verts[3].Add(5);
                verts[5].Add(3);

                for (int i = 0; i < nv; i++)
                    Debug.Log($"Vertex {i} is degree {verts[i].Count}.");
            }

            // Add positions
            {
                var positions = graph.Positions;

                positions.Add(new Vector3(0.0f, 0.0f, 2.0f));
                positions.Add(new Vector3(4.0f, 0.0f, 2.0f));

                positions.Add(new Vector3(0.0f, 0.0f, 1.0f));
                positions.Add(new Vector3(4.0f, 0.0f, 1.0f));

                positions.Add(new Vector3(0.0f, 0.0f, 0.0f));
                positions.Add(new Vector3(4.0f, 0.0f, 0.0f));
            }
        }

    }
}
