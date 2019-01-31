using UnityEngine;

namespace RC3.Unity.GraphIntro
{
    /// <summary>
    /// 
    /// </summary>
    public class CustomMeshDisplay : CustomDisplay
    {
        [SerializeField] private Mesh _mesh;
        [SerializeField] private Material _material;

        /// <summary>
        /// 
        /// </summary>
        protected override void Display(Camera camera, Matrix4x4 model)
        {
            _material.SetPass(0);
            Graphics.DrawMeshNow(_mesh, model);
        }
    }
}
