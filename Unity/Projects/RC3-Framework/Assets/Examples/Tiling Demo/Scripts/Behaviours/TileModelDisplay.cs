/*
 * Notes
 */

using UnityEngine;

namespace RC3.Unity.TilingDemo
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
            var indices = _graph.TileIndices;
            var tiles = _graph.TileSet;

            var model = transform.localToWorldMatrix;
            var camPos = _camera.transform.position;
            var camUp = _camera.transform.up;

            for(int i = 0; i < positions.Length; i++)
            {
                var index = indices[i];

                if (index == -1)
                {
                    var p = positions[i];
                    var d = model.MultiplyPoint(p) - camPos;
                    var q = Quaternion.LookRotation(d, camUp);

                    const float t = 0.5f;
                    Matrix4x4 m = Matrix4x4.TRS(p, q, new Vector3(t, t, t));
                    Graphics.DrawMesh(_unknown.Mesh, model * m, _unknown.Material, 0, _camera);
                }
                else
                {
                    var tile = tiles[index];

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
