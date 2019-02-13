using UnityEngine;

namespace RC3.Unity.GraphIntro
{
    /// <summary>
    /// 
    /// </summary>
    public class GraphDebugDisplay : DebugDisplay
    {
        [SerializeField] private Graph _graph;

        [SerializeField] Color _color0 = Color.white;
        [SerializeField] Color _color1 = Color.black;

        [SerializeField] float _scale0 = 1.0f;
        [SerializeField] float _scale1 = 0.5f;

        [SerializeField] private float _period = 3.0f; // Time in seconds per cycle

        /// <summary>
        /// 
        /// </summary>
        protected override void Display()
        {
            DisplayFancy();
        }


        /// <summary>
        /// 
        /// </summary>
        private void DisplayFancy()
        {
            var verts = _graph.Vertices;
            var positions = _graph.Positions;

            // 0 <= t < = 1
            float t = Mathf.Sin(Time.time / _period * Mathf.PI * 2.0f) * 0.5f + 0.5f;

            Color color = Color.Lerp(_color0, _color1, t);
            float scale = Mathf.Lerp(_scale0, _scale1, t);

            GL.Begin(GL.LINES);

            GL.Color(color);

            for (int i = 0; i < verts.Count; i++)
            {
                foreach (var j in verts[i])
                {
                    if (j > i)
                    {
                        var p0 = positions[i];
                        var p1 = positions[j];
                        var mid = (p0 + p1) * 0.5f;

                        GL.Vertex(Vector3.Lerp(mid, p0, scale));
                        GL.Vertex(Vector3.Lerp(mid, p1, scale));
                    }
                }
            }

            GL.End();
        }


        /// <summary>
        /// 
        /// </summary>
        private void DisplaySimple()
        {
            var verts = _graph.Vertices;
            var positions = _graph.Positions;

            GL.Begin(GL.LINES);

            GL.Color(Color.white);

            for (int i = 0; i < verts.Count; i++)
            {
                foreach (var j in verts[i])
                {
                    if (j > i)
                    {
                        GL.Vertex(positions[i]);
                        GL.Vertex(positions[j]);
                    }
                }
            }

            GL.End();
        }
    }
}
