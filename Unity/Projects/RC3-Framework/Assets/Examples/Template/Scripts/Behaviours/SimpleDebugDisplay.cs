using UnityEngine;

namespace RC3.Unity.Template
{
    /// <summary>
    /// 
    /// </summary>
    [ExecuteInEditMode]
    public class SimpleDebugDisplay : DebugDisplay
    {
        /// <summary>
        /// 
        /// </summary>
        protected override void Display(Camera camera)
        {
            // Draw a line segment
            GL.Begin(GL.LINES);
            {
                GL.Color(Color.white);
                
                GL.Vertex3(0.0f, 0.0f, 0.0f);
                GL.Vertex3(1.0f, 0.0f, 1.0f);
            }
            GL.End();

            // Draw a triangle
            GL.Begin(GL.TRIANGLES);
            {
                GL.Color(Color.magenta);
                
                GL.Vertex(new Vector3(0.0f, 1.0f, 0.0f));
                GL.Vertex(new Vector3(1.0f, 1.0f, 1.0f));
                GL.Vertex(new Vector3(1.0f, 0.0f, 0.0f));
            }
            GL.End();
        }
    }
}
