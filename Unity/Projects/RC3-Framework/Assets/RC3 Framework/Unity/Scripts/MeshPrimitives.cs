/*
 * Notes
 */ 

using UnityEngine;

namespace RC3
{
    /// <summary>
    /// 
    /// </summary>
    public static class MeshPrimitives
    {
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public static Mesh CreateQuad()
        {
            Mesh mesh = new Mesh();

            mesh.vertices = new Vector3[]
            {
                new Vector3(-0.5f, -0.5f, 0.0f),
                new Vector3(0.5f, -0.5f, 0.0f),
                new Vector3(-0.5f, 0.5f, 0.0f),
                new Vector3(0.5f, 0.5f, 0.0f)
            };

            mesh.uv = new Vector2[]
            {
                new Vector2(0.0f, 0.0f),
                new Vector2(1.0f, 0.0f),
                new Vector2(0.0f, 1.0f),
                new Vector2(1.0f, 1.0f),
            };

            mesh.triangles = new int[]
            {
                0, 1, 2,
                3, 2, 1
            };

            return mesh;
        }
    }
}
