using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RC3.Unity.TilingDemo
{
    public class GraphExporter : MonoBehaviour
    {
        [SerializeField] TileGraph _graph;
        [SerializeField] string _path;
        

        /// <summary>
        /// 
        /// </summary>
        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.E))
                Export();
        }


        /// <summary>
        /// 
        /// </summary>
        public void Export()
        {
            int[,] verts = _graph.Adjacency;
            float[] pos = FormatPositions();
            var data = Tuple.Create(verts, pos);
            Utilities.SerializeBinary(data, _path);

            Debug.Log("TileGraph export complete!");
        }


        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        private float[] FormatPositions()
        {
            var pos = _graph.Positions;
            float[] result = new float[pos.Length * 3];

            for (int i = 0; i < pos.Length; i++)
            {
                var p = pos[i];
                int j = i * 3;
                result[j] = p.x;
                result[j + 1] = p.y;
                result[j + 2] = p.z;
            }

            return result;
        }


        IEnumerable<T> AsFlat<T>(T[,] source)
        {
            var m = source.GetLength(0);
            var n = source.GetLength(1);

            for(int i = 0; i < m; i++)
            {
                for (int j = 0; j < n; j++)
                    yield return source[i, j];
            }
        }
    }

}

