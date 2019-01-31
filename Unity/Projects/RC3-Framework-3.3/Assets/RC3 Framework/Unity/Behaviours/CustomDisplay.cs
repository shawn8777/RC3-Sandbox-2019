using UnityEngine;

namespace RC3.Unity
{
    /// <summary>
    /// 
    /// </summary>
    [RequireComponent(typeof(Camera))]
    public abstract class CustomDisplay : MonoBehaviour
    {
        [SerializeField] private Transform _transform;
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
        private void OnPostRender()
        {
            if (_transform == null)
                Display(_camera, Matrix4x4.identity);
            else
                Display(_camera, _transform.localToWorldMatrix);
        }


        /// <summary>
        /// 
        /// </summary>
        protected abstract void Display(Camera camera, Matrix4x4 model);
    }
}
