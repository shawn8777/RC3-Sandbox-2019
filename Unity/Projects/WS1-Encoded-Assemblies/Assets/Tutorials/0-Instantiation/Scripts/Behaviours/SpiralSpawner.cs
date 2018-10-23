using System;
using System.Collections;
using System.Collections.Generic;

using UnityEngine;

namespace RC3
{
    /// <summary>
    /// 
    /// </summary>
    public class SpiralSpawner : MonoBehaviour
    {
        public GameObject prefab;
        public float angleStep = Mathf.PI * 0.05f;
        public float radiusStart = 10.0f;
        public float radiusScale = 0.5f;
        public float spacingZ = 0.5f;
        public int count = 10;

        
        void Start()
        {
            for(int i = 0; i < count; i++)
            {
                GameObject copy = Instantiate(prefab, this.transform);

                float angle = i * angleStep;
                float radius = radiusStart + radiusScale * i;

                float x = Mathf.Cos(angle) * radius;
                float y = Mathf.Sin(angle) * radius;
                float z = i * spacingZ;

                copy.transform.localPosition = new Vector3(x, z, y);
            }
        }
    }
}
