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
    public class FuncModel : MonoBehaviour
    {
        [SerializeField] private GameObject _prefab;
        [SerializeField] private GridModelParams _params;

        [SerializeField] private int _countX = 10;
        [SerializeField] private int _countZ = 10;

        [SerializeField] private float _spacingX = 2.0f;
        [SerializeField] private float _spacingZ = 2.0f;

        private GameObject[,] _objects;


        void Start()
        {
            _objects = new GameObject[_countZ, _countX];

            for (int i = 0; i < _countZ; i++)
            {
                for (int j = 0; j < _countX; j++)
                {
                    GameObject copy = Instantiate(_prefab, this.transform);

                    float x = j * _spacingX;
                    float z = i * _spacingZ;
                    copy.transform.localPosition = new Vector3(x, 0.0f, z);

                    // store the instantiated copy
                    _objects[i, j] = copy;
                }
            }
        }


        void Update()
        {
            float offsetX = Time.time * _params.SpeedX;
            float offsetZ = Time.time * _params.SpeedZ;

            for (int i = 0; i < _countZ; i++)
            {
                for (int j = 0; j < _countX; j++)
                {
                    GameObject obj = _objects[i, j];
                    Vector3 pos = obj.transform.localPosition;

                    // calculate y coordinate as a function of x and z coordinates
                    float x = (pos.x + offsetX) * _params.FrequencyX;
                    float z = (pos.z + offsetZ) * _params.FrequencyZ;

                    float y0 = Mathf.Sin(x) * _params.ScaleX;
                    float y1 = Mathf.Cos(z) * _params.ScaleZ;

                    pos.y = Mix(y0, y1);
                    obj.transform.localPosition = pos;
                }
            }
        }


        /// <summary>
        /// 
        /// </summary>
        private float Mix(float a, float b)
        {
            switch (_params.MixMode)
            {
                case MixMode.Add:
                    return a + b;
                case MixMode.Multiply:
                    return a * b;
                case MixMode.Min:
                    return Mathf.Min(a, b);
                case MixMode.Max:
                    return Mathf.Max(a, b);
                default:
                    throw new NotImplementedException();
            }
        }
    }
}
