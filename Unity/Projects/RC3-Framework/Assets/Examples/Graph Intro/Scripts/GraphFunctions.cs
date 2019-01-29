using System.Collections;
using UnityEngine;

namespace RC3.Unity.GraphIntro
{
    /// <summary>
    /// 
    /// </summary>
    public class GraphFunctions
    {
        /// <summary>
        /// Moves each vertex in a given graph to the average position of its neigbours
        /// </summary>
        public static void Assignment1(Graph graph, Vector3[] deltas, int minDegree)
        {
            var verts = graph.Vertices;
            var positions = graph.Positions;

            // Compute deltas
            for(int i = 0; i < verts.Count; i++)
            {
                if (verts[i].Count < minDegree)
                    continue;

                Vector3 sum = Vector3.zero;

                // Add up positions of neighbors
                foreach(int j in verts[i])
                    sum += positions[j];

                // Cache the delta
                deltas[i] = sum / verts[i].Count - positions[i];
            }

            // Apply deltas
            for(int i = 0; i < verts.Count; i++)
            {
                positions[i] += deltas[i];
            }
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="graph"></param>
        /// <param name="deltas"></param>
        public static void Assignment2(Graph graph, Color[] deltas)
        {
            // TODO
            // ...
            // ...
            // ...
            // ...
        }
    }
}
