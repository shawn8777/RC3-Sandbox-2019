using UnityEngine;

namespace RC3.GraphIntro
{
    /// <summary>
    /// 
    /// </summary>
    public class VertexColorDisplay : DebugDisplay
    {
        [SerializeField] private Graph _graph;

        [Range(0.0f, 10.0f)]
        [SerializeField] private float _scale = 1.0f;

        /// <summary>
        /// 
        /// </summary>
        protected override void Display()
        {
            var verts = _graph.Vertices;
            var positions = _graph.Positions;
            var colors = _graph.Colors;

            GL.Begin(GL.QUADS);
            {
                for (int i = 0; i < verts.Count; i++)
                {
                    GL.Color(colors[i]);
                    
                    var p = positions[i];
                    GL.Vertex(p + new Vector3(-1.0f, 0.0f, 1.0f) * _scale);
                    GL.Vertex(p + new Vector3(1.0f, 0.0f, 1.0f) * _scale);
                    GL.Vertex(p + new Vector3(1.0f, 0.0f, -1.0f) * _scale);
                    GL.Vertex(p + new Vector3(-1.0f, 0.0f, -1.0f) * _scale);
                }
            }
            GL.End();

            GL.Begin(GL.LINES);
            {
                for (int i = 0; i < verts.Count; i++)
                {
                    foreach (int j in verts[i])
                    {
                        if (j > i) continue;

                        GL.Color(colors[i]);
                        GL.Vertex(positions[i]);

                        GL.Color(colors[j]);
                        GL.Vertex(positions[j]);
                    }
                }
            }
            GL.End();
        }
    }
}
