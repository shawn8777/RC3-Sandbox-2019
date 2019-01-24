using UnityEngine;

namespace RC3.Unity
{
    /// <summary>
    /// 
    /// </summary>
    [RequireComponent(typeof(Camera))]
    public abstract class DebugDisplay : MonoBehaviour
    {
        [SerializeField] private Transform _transform;
        [SerializeField] private Material _material;
        private Camera _camera;


        /// <summary>
        /// 
        /// </summary>
        private void Start()
        {
            _camera = GetComponent<Camera>();
        }


        /// <summary>
        /// 
        /// </summary>
        void OnPostRender()
        {
            _material.SetPass(0);

            GL.PushMatrix();

            GL.LoadIdentity();
            GL.MultMatrix(_camera.worldToCameraMatrix * _transform.localToWorldMatrix);

            Display();

            GL.PopMatrix();
        }


        /// <summary>
        /// 
        /// </summary>
        protected abstract void Display();
    }
}
