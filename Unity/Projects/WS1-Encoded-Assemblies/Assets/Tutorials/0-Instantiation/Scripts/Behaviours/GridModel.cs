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
    public class GridModel : MonoBehaviour
    {
        [SerializeField] private GameObject _prefab;
        [SerializeField] private GridModelParams _params;

        [SerializeField] private int _countX = 10;
        [SerializeField] private int _countY = 10;

        [SerializeField] private float _spacingX = 2.0f;
        [SerializeField] private float _spacingY = 2.0f;

        private GameObject[,] _objects;

   
        void Start()
        {
            _objects = new GameObject[_countY, _countX];
            
            for (int i = 0; i < _countY; i++)
            {
                for (int j = 0; j < _countX; j++)
                {
                    GameObject copy = Instantiate(_prefab, this.transform);

                    float x = j * _spacingX;
                    float z = i * _spacingY;
                    copy.transform.localPosition = new Vector3(x, 0.0f, z);

                    // store the instantiated copy
                    _objects[i, j] = copy;
                }
            }
        }


        void Update()
        {
            float offset = Time.time * _params.Frequency;

            for(int i = 0; i < _countY; i++)
            {
                for(int j = 0; j < _countX; j++)
                {
                    GameObject obj = _objects[i, j];
                    Vector3 pos = obj.transform.localPosition;

                    // calculate y coordinate as a function of x coordinate
                    float x = (pos.x + offset) * _params.ScaleX;
                    float z = (pos.z + offset) * _params.ScaleZ;

                    float y0 = Mathf.Sin(x) * _params.Amplitude;
                    float y1 = Mathf.Cos(z) * _params.Amplitude;

                    // pos.y = Mathf.Min(y0,y1);
                    pos.y = y0 * y1;
                    obj.transform.localPosition = pos;
                }
            }
        }
    }
}
