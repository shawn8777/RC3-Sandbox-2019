/*
 * Notes
 */

using UnityEngine;

namespace RC3.Unity.TilingDemo
{
    /// <summary>
    /// 
    /// </summary>
    public class TileModelDisplay : CustomDisplay
    {
        [SerializeField] private TileGraph _graph;
        [SerializeField] private Tile _unknown;


        /// <summary>
        /// 
        /// </summary>
        /// <param name="camera"></param>
        /// <param name="model"></param>
        protected override void Display(Camera camera, Matrix4x4 model)
        {
            var positions = _graph.Positions;
            var indices = _graph.TileIndices;
            var tiles = _graph.TileSet;

            var camPos = camera.transform.position;
            var camRight = camera.transform.right;

            const float t = 0.5f;

            for(int i = 0; i < positions.Length; i++)
            {
                var index = indices[i];

                if (index == -1)
                {
                    var p = positions[i];
                    var d = p - camPos;
                    var q = Quaternion.LookRotation(d, Vector3.Cross(d, camRight));
                    
                    Matrix4x4 m = Matrix4x4.TRS(p, q, new Vector3(t, t, t));

                    _unknown.Material.SetPass(0);
                    Graphics.DrawMeshNow(_unknown.Mesh, model * m, 0);
                }
                else
                {
                    var tile = tiles[index];

                    if (tile.Mesh != null)
                    {
                        Matrix4x4 m = Matrix4x4.Translate(positions[i]);

                        tile.Material.SetPass(0);
                        Graphics.DrawMeshNow(tile.Mesh, model * m, 0);
                    }
                }
            }
        }
    }
}
