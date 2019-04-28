/*

    Notes

*/

using System;
using System.Collections.Generic;
using System.Linq;

using UnityEngine;

namespace RC3.DigitalNomad
{

    /// <summary>
    /// 
    /// </summary>
    [CreateAssetMenu(menuName = "RC3/DigitalNomad/Tile")]
    public class NomadTile : ScriptableObject
    {
        [SerializeField] private Material _material;

        [Space(5)]

        [SerializeField] private string _labelX0;
        [SerializeField] private string _labelX1;

        [Space(5)]

        [SerializeField] private string _labelY0;
        [SerializeField] private string _labelY1;

        [Space(5)]

        [SerializeField] private string _labelZ0;
        [SerializeField] private string _labelZ1;

        [Space(5)]

        [SerializeField] private bool _rotationX = false;
        [SerializeField] private bool _rotationY = false;
        [SerializeField] private bool _rotationZ = false;

        private string[] _labels = new string[6];
        private Mesh _mesh;
        private Matrix4x4 _xform;

        // TODO: Add other attributes here (i.e. floor area, weight, price etc.)
        // ...
        // ...
        // ...

        public string[] Labels
        {
            get { return _labels; }
        }

        public bool RotationX
        {
            get { return _rotationX; }
        }

        public bool RotationY
        {
            get { return _rotationY; }
        }

        public bool RotationZ
        {
            get { return _rotationZ; }
        }

        public Mesh Mesh
        {
            get { return _mesh; }
            set { _mesh = value; }
        }

        public Matrix4x4 Transform
        {
            get { return _xform; }
            set { _xform = value; }
        }
        
        /// <summary>
        /// 
        /// </summary>
        private void Awake()
        {
            // Collect labels in array for processing
            _labels[0] = _labelX0;
            _labels[1] = _labelX1;
            _labels[2] = _labelY0;
            _labels[3] = _labelY1;
            _labels[4] = _labelZ0;
            _labels[5] = _labelZ1;
        }
    }
}
