using System;
using System.Collections.Generic;
using System.Linq;

using UnityEngine;

namespace RC3.TilingDemo
{
    /// <summary>
    /// 
    /// </summary>
    [RequireComponent(typeof(TileModelManager))]
    public class TileGraphExporter : MonoBehaviour
    {
        [SerializeField] private string _path;
        [SerializeField] private Vector3 _scale = new Vector3(1.0f, 1.0f, 1.0f);

        private TileGraph _graph;


        /// <summary>
        /// 
        /// </summary>
        private void Start()
        {
            _graph = GetComponent<TileModelManager>().Graph;
        }


        /// <summary>
        /// 
        /// </summary>
        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Alpha1))
                Export();
        }


        /// <summary>
        /// 
        /// </summary>
        public void Export()
        {
            var adj = Flatten(_graph.Adjacency).ToArray();
            var pos = Flatten(_graph.Positions).ToArray();

            var data = Tuple.Create(adj, _graph.Degree, pos);
            Utilities.SerializeBinary(data, _path);

            Debug.Log("TileGraph export complete!");
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="points"></param>
        /// <returns></returns>
        private IEnumerable<float> Flatten(IEnumerable<Vector3> points)
        {
            var scale = _scale;

            foreach (var p in points)
            {
                yield return p.x * scale.x;
                yield return p.y * scale.y;
                yield return p.z * scale.z;
            }
        }


        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="source"></param>
        /// <returns></returns>
        private static IEnumerable<T> Flatten<T>(T[,] source)
        {
            var m = source.GetLength(0);
            var n = source.GetLength(1);

            for (int i = 0; i < m; i++)
            {
                for (int j = 0; j < n; j++)
                    yield return source[i, j];
            }
        }
    }
}
