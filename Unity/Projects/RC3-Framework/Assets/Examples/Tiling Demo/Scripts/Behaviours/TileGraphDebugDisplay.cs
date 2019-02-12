using UnityEngine;

namespace RC3.Unity.TilingDemo
{
    /// <summary>
    /// 
    /// </summary>
    public class TileGraphDebugDisplay : DebugDisplay
    {
        [SerializeField] private TileGraph _graph;
        [SerializeField] private Color _color = Color.white;

        [Range(0.0f, 1.0f)]
        [SerializeField] private float _scale = 0.05f;

        /// <summary>
        /// 
        /// </summary>
        protected override void Display(Camera camera)
        {
            var verts = _graph.Vertices;
            var positions = _graph.Positions;

            var m = verts.GetLength(0);
            var n = verts.GetLength(1);


            GL.Begin(GL.QUADS);
            {
                GL.Color(_color);

                for (int i = 0; i < m; i++)
                {
                    var p = positions[i];
                    GL.Vertex(p + new Vector3(-1.0f, 1.0f) * _scale);
                    GL.Vertex(p + new Vector3(1.0f, 1.0f) * _scale);
                    GL.Vertex(p + new Vector3(1.0f, -1.0f) * _scale);
                    GL.Vertex(p + new Vector3(-1.0f, -1.0f) * _scale);
                }
            }
            GL.End();

            GL.Begin(GL.LINES);
            {
                GL.Color(_color);

                for (int i = 0; i < m; i++)
                {
                    for (int dir = 0; dir < n; dir++)
                    {
                        var j = verts[i, dir];
                        if (j < 0 || j > i) continue;
                        
                        GL.Vertex(positions[i]);
                        GL.Vertex(positions[j]);
                    }
                }
            }
            GL.End();
        }
    }
}
