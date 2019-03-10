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

        [Range(0.0f, 0.1f)]
        [SerializeField] private float _scale = 0.05f;

        /// <summary>
        /// 
        /// </summary>
        protected override void Display()
        {
            var verts = _graph.Adjacency;
            var positions = _graph.Positions;

            var m = verts.GetLength(0);
            var n = verts.GetLength(1);
            
            GL.PushMatrix();
            {
                var modelView = GL.modelview;
                GL.LoadIdentity();

                GL.Begin(GL.QUADS);
                {
                    GL.Color(_color);

                    for (int i = 0; i < m; i++)
                    {
                        var p = modelView.MultiplyPoint(positions[i]);
                        var t = _scale * p.z; // Creates fixed size quads

                        GL.Vertex(p + new Vector3(-t, t));
                        GL.Vertex(p + new Vector3(t, t));
                        GL.Vertex(p + new Vector3(t, -t));
                        GL.Vertex(p + new Vector3(-t, -t));
                    }
                }
                GL.End();
            }
            GL.PopMatrix();

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
