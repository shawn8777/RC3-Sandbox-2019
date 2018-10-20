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
    public class LineSpawner : MonoBehaviour
    {
        public GameObject prefab;
        public int count = 10;
        public float spacing = 3.0f;

        void Start()
        {
            float slopeY = 2.0f;

            for(int i = 0; i < count; i++)
            {
                GameObject copy = Instantiate(prefab);

                Vector3 pos = new Vector3(spacing * i, slopeY * i, 0.0f);

                copy.transform.position = pos;
            }
        }
    }
}
