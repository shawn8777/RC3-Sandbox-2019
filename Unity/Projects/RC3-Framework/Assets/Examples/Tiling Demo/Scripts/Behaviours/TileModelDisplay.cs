/*
 * Notes
 */

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
    public class TileModelDisplay : MonoBehaviour
    {
        [SerializeField] private LabeledTile _unknown;
        [SerializeField] private Camera _camera;

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
            var positions = _graph.Positions;
            var tileIndices = _graph.AssignedTiles;
            var domainSizes = _graph.DomainSizes;
            var tiles = _graph.TileSet;

            var model = transform.localToWorldMatrix;
            var camPos = _camera.transform.position;
            var camUp = _camera.transform.up;

            for(int i = 0; i < positions.Length; i++)
            {
                var tileIndex = tileIndices[i];
                
                if (tileIndex == -1)
                {
                    var p = positions[i];
                    var d = model.MultiplyPoint(p) - camPos;
                    var q = Quaternion.LookRotation(d, camUp);
                    
                    const float t0 = 0.25f;
                    const float t1 = 0.75f;

                    // Scale placeholder tile by domain size
                    float t = (float)domainSizes[i] / tiles.Count;
                    t = t0 + t * (t1 - t0);
                    
                    Matrix4x4 m = Matrix4x4.TRS(p, q, new Vector3(t, t, t));
                    Graphics.DrawMesh(_unknown.Mesh, model * m, _unknown.Material, 0, _camera);
                }
                else
                {
                    var tile = tiles[tileIndex];

                    if (tile.Mesh != null)
                    {
                        Matrix4x4 m = Matrix4x4.Translate(positions[i]);
                        Graphics.DrawMesh(tile.Mesh, model * m, tile.Material, 0, _camera);
                    }
                }
            }
        }
    }
}
