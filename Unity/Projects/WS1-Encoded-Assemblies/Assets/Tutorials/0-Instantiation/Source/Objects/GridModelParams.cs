using System;
using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using SpatialSlur;

namespace RC3
{
    /// <summary>
    /// 
    /// </summary>
    [CreateAssetMenu(menuName = "RC3/WS1/GridModelParams")]
    public class GridModelParams : ScriptableObject
    {
        [SerializeField] private MixMode _mixMode;

        [SerializeField] private float _speedX = 0.1f;
        [SerializeField] private float _speedZ = 0.1f;

        [SerializeField] private float _frequencyX = 0.1f;
        [SerializeField] private float _frequencyZ = 0.1f;

        [SerializeField] private float _scaleX = 0.1f;
        [SerializeField] private float _scaleZ = 0.1f;


        public MixMode MixMode
        {
            get { return _mixMode; }
        }
        

        public float SpeedX
        {
            get { return _speedX; }
        }


        public float SpeedZ
        {
            get { return _speedZ; }
        }


        public float FrequencyX
        {
            get { return _frequencyX; }
        }


        public float FrequencyZ
        {
            get { return _frequencyZ; }
        }


        public float ScaleX
        {
            get { return _scaleX; }
        }


        public float ScaleZ
        {
            get { return _scaleZ; }
        }
    }
}
