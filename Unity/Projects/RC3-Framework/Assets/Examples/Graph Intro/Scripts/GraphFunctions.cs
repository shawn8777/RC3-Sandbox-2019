using System.Collections;
using UnityEngine;

namespace RC3.GraphIntro
{
    /// <summary>
    /// 
    /// </summary>
    public class GraphFunctions
    {
        /// <summary>
        /// Moves each vertex in a given graph to the average position of its neigbours
        /// </summary>
        public static void UniformSmooth(Graph graph, Vector3[] deltas, float strength)
        {
            var verts = graph.Vertices;
            var positions = graph.Positions;

            // Compute deltas
            for(int i = 0; i < verts.Count; i++)
            {
                if (verts[i].Count == 0)
                    continue;

                Vector3 sum = Vector3.zero;

                foreach(int j in verts[i])
                    sum += positions[j];
                
                deltas[i] = sum / verts[i].Count - positions[i];
            }

            // Apply deltas
            for(int i = 0; i < verts.Count; i++)
                positions[i] += deltas[i] * strength;
        }


        /// <summary>
        /// Set the color of each vertex to the average of its neighbors
        /// </summary>
        /// <param name="graph"></param>
        /// <param name="deltas"></param>
        public static void UniformSmooth(Graph graph, Color[] deltas, float strength)
        {
            var verts = graph.Vertices;
            var colors = graph.Colors;

            // Compute deltas
            for(int i = 0; i < verts.Count; i++)
            {
                if (verts[i].Count == 0)
                    continue;

                Color sum = new Color();

                foreach(int j in verts[i])
                    sum += colors[j];

                deltas[i] = sum / verts[i].Count;
            }

            // Apply deltas
            for (int i = 0; i < verts.Count; i++)
                colors[i] += deltas[i] * strength;
        }
    }
}
