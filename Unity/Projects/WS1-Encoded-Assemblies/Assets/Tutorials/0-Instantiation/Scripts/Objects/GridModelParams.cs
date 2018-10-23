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
        [SerializeField] private float _frequency = 0.1f;
        [SerializeField] private float _amplitude = 2.0f;
        [SerializeField] private float _scaleX = 0.1f;
        [SerializeField] private float _scaleZ = 0.1f;
        

        public float Frequency
        {
            get { return _frequency; }
            /*
            set
            {
                if (value < 0.0)
                    throw new ArgumentOutOfRangeException("Value was negative!");

                _frequency = value;
            }
            */
        }


        public float Amplitude
        {
            get { return _amplitude; }
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
