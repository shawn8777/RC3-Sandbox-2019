/*

    Notes

*/

using System;
using System.Collections.Generic;

using UnityEngine;

namespace RC3.DigitalNomad
{
    public class CustomDisplay : MonoBehaviour
    {
        [SerializeField] private string _modelPath;
        [SerializeField] private Material _material;
        [SerializeField] private Camera _camera;

        private List<Mesh> _meshes = new List<Mesh>();

        private void Start()
        {
            // .fbx or .mb files can be loaded directly as GameObjects
            var obj = Resources.Load<GameObject>(_modelPath);
            Debug.Log(obj.name);

            // Contents can be parsed by iterating over components in children
            foreach (var meshFilter in obj.GetComponentsInChildren<MeshFilter>())
            {
                Debug.Log(meshFilter.name);
                _meshes.Add(meshFilter.sharedMesh);
            }
        }

        private void Update()
        {
            foreach (var mesh in _meshes)
                Graphics.DrawMesh(mesh, Matrix4x4.identity, _material, 0, _camera);
        }
    }
}
