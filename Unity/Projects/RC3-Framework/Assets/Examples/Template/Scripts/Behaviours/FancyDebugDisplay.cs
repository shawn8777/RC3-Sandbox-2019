using UnityEngine;

namespace RC3.Unity.Template
{
    /// <summary>
    /// 
    /// </summary>
    [ExecuteInEditMode]
    public class FancyDebugDisplay : DebugDisplay
    {
        [SerializeField] private float _period = 2.0f;


        private Vector3[] _verts = new Vector3[]
        {
            new Vector3(0.0f, 0.0f, 0.0f),
            new Vector3(1.0f, 0.0f, 1.0f),
            new Vector3(1.0f, 1.0f, 0.0f),
            new Vector3(0.0f, 1.0f, 1.0f),
        };


        private int[] _faces = new int[]
        {
            2, 1, 0,
            3, 0, 1,
            0, 3, 2,
            1, 2, 3
        };


        private int[] _edges = new int[]
        {
            0, 1,
            0, 2,
            0, 3,
            1, 2,
            1, 3,
            2, 3
        };


        /// <summary>
        /// 
        /// </summary>
        protected override void Display()
        {
            Color color0 = Color.magenta;
            Color color1 = Color.black;

            const float scale0 = 1.0f;
            const float scale1 = 0.75f;
            
            const float twoPi = Mathf.PI * 2.0f;
            float t = Mathf.Cos(Time.time / _period * twoPi) * 0.5f + 0.5f;

            Color color = Color.Lerp(color0, color1, t);
            float scale = Mathf.Lerp(scale0, scale1, t);

            // Draw faces
            GL.Begin(GL.TRIANGLES);
            {
                GL.Color(color);

                for (int i = 0; i < _faces.Length; i += 3)
                {
                    var p0 = _verts[_faces[i]];
                    var p1 = _verts[_faces[i + 1]];
                    var p2 = _verts[_faces[i + 2]];

                    const float inv3 = 1.0f / 3.0f;
                    var cen = (p0 + p1 + p2) * inv3;

                    GL.Vertex(Vector3.Lerp(cen, p0, scale));
                    GL.Vertex(Vector3.Lerp(cen, p1, scale));
                    GL.Vertex(Vector3.Lerp(cen, p2, scale));
                }
            }
            GL.End();

            // Draw edges
            GL.Begin(GL.LINES);
            {
                GL.Color(Color.white);

                for (int i = 0; i < _edges.Length; i+=2)
                {
                    var p0 = _verts[_edges[i]];
                    var p1 = _verts[_edges[i + 1]];

                    var cen = (p0 + p1) * 0.5f;

                    GL.Vertex(Vector3.Lerp(cen, p0, scale));
                    GL.Vertex(Vector3.Lerp(cen, p1, scale));
                }
            }
            GL.End();
        }
    }
}
