using UnityEngine;

namespace RC3.GraphIntro
{

    /// <summary>
    /// 
    /// </summary>
    public class GraphDegreeDisplay : DebugDisplay
    {
        [SerializeField] private Graph _graph;
        [SerializeField] private Texture2D _gradient;

        [SerializeField] private int _minDegree = 0;
        [SerializeField] private int _maxDegree = 10;

        /// <summary>
        /// 
        /// </summary>
        protected override void Display()
        {
            var verts = _graph.Vertices;
            var positions = _graph.Positions;

            GL.Begin(GL.LINES);
            
            for (int i = 0; i < verts.Count; i++)
            {
                float t0 = Mathf.InverseLerp(_minDegree, _maxDegree, verts[i].Count);
                Color c0 = _gradient.GetPixelBilinear(t0, t0);

                foreach (var j in verts[i])
                {
                    if (j > i)
                    {
                        float t1 = Mathf.InverseLerp(_minDegree, _maxDegree, verts[j].Count);
                        Color c1 = _gradient.GetPixelBilinear(t1, t1);

                        GL.Color(c0);
                        GL.Vertex(positions[i]);

                        GL.Color(c1);
                        GL.Vertex(positions[j]);
                    }
                }
            }

            GL.End();
        }
    }
}
