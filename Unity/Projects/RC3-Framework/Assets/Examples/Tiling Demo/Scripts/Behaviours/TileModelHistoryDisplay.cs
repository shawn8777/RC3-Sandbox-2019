/*
 * Notes
 */

using System.Collections.Generic;

using UnityEngine;

namespace RC3.Unity.TilingDemo
{
    /// <summary>
    /// Custom display method for rendering accumulated history of tile model
    /// </summary>
    public class TileModelHistoryDisplay : MonoBehaviour
    {
        [SerializeField] private TileGraph _graph;
        [SerializeField] private TileModelHistory _modelHistory;
        [SerializeField] private Camera _camera;
        [SerializeField] private float _rowSpacing = 10.0f;
        [SerializeField] private float _columnSpacing = 10.0f;
        [SerializeField] private int _columnCount = 10;


        /// <summary>
        /// 
        /// </summary>
        private void Update()
        {
            var positions = _graph.Positions;
            var tiles = _graph.TileSet;

            var model = transform.localToWorldMatrix;
            var camPos = _camera.transform.position;
            var camUp = _camera.transform.up;
            
            var deltas = GetTranslations().GetEnumerator();

            foreach(var tileIndices in _modelHistory.Data)
            {
                deltas.MoveNext();
                var delta = deltas.Current;

                for (int j = 0; j < positions.Length; j++)
                {
                    var index = tileIndices[j];

                    if (index != -1)
                    {
                        var tile = tiles[index];

                        if (tile.Mesh != null)
                        {
                            Matrix4x4 m = Matrix4x4.Translate(positions[j] + delta);
                            Graphics.DrawMesh(tile.Mesh, model * m, tile.Material, 0, _camera);
                        }
                    }
                }
            }
        }

        
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        private IEnumerable<Vector3> GetTranslations()
        {
            float dx = _columnSpacing;
            float dy = _rowSpacing;
            int nx = _columnCount;

            Vector3 current = Vector3.zero;

            while (true)
            {
                for (int i = 0; i < nx; i++)
                {
                    yield return current;
                    current.x += dx;
                }

                current.x = 0.0f;
                current.y += dy;
            }
        }
    }
}
