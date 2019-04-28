using UnityEngine;

namespace RC3.TilingDemo
{
    /// <summary>
    /// 
    /// </summary>
    public class TileTopologyDebugDisplay : DebugDisplay
    {
        [SerializeField] private TileGraph _graph;
        [SerializeField] private Color[] _colors;


        /// <summary>
        /// 
        /// </summary>
        protected override void Display()
        {
            var adj = _graph.Adjacency;
            var pos = _graph.Positions;

            var m = adj.GetLength(0);
            var n = adj.GetLength(1);

            GL.Begin(GL.LINES);
            {
                for (int i = 0; i < m; i++)
                {

                    for(int dir = 0; dir < n; dir++)
                    {
                        var j = adj[i, dir];

                        if (j < 0)
                            continue;

                        GL.Color(_colors[dir]);

                        var p0 = pos[i];
                        var p1 = pos[j];

                        GL.Vertex(p0);
                        GL.Vertex(Vector3.Lerp(p0, p1, 0.45f));
                    }
                }
            }
            GL.End();
        }
    }
}
