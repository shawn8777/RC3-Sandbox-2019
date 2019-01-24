using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RC3.Unity.GraphIntro
{
    /// <summary>
    /// 
    /// </summary>
    public class GraphCreator : MonoBehaviour
    {
        [SerializeField] private Graph _graph;


        /// <summary>
        /// 
        /// </summary>
        private void Start()
        {
            CreateGraph();
        }


        /// <summary>
        /// 
        /// </summary>
        private void CreateGraph()
        {
            var verts = _graph.Vertices;
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
                var positions = _graph.Positions;

                positions.Add(new Vector3(0.0f, 0.0f, 2.0f));
                positions.Add(new Vector3(4.0f, 0.0f, 2.0f));

                positions.Add(new Vector3(1.0f, 0.0f, 1.0f));
                positions.Add(new Vector3(3.0f, 0.0f, 1.0f));

                positions.Add(new Vector3(0.0f, 0.0f, 0.0f));
                positions.Add(new Vector3(4.0f, 0.0f, 0.0f));
            }
        }
    }
}
