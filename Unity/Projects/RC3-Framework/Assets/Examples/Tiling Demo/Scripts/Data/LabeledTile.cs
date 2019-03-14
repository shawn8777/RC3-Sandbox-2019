/*
 * Notes
 */

using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEditor;

namespace RC3.Unity.TilingDemo
{
    /// <summary>
    /// 
    /// </summary>
    [CreateAssetMenu(menuName = "RC3/Tiling Demo/Labeled Tile")]
    public class LabeledTile : ScriptableObject
    {
        [SerializeField] private Mesh _mesh;
        [SerializeField] private Material _material;
        [SerializeField, HideInInspector] private string[] _labels;


        /// <summary>
        /// 
        /// </summary>
        public Mesh Mesh
        {
            get { return _mesh; }
        }


        /// <summary>
        /// 
        /// </summary>
        public Material Material
        {
            get { return _material; }
        }


        /// <summary>
        /// 
        /// </summary>
        public string[] Labels
        {
            get { return _labels; }
        }
    }
}
