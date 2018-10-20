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
    public class GridSpawnerXY : MonoBehaviour
    {
        public GameObject prefab;
        public int countX = 10;
        public int countY = 10;
        public float spacingX = 2.0f;
        public float spacingY = 2.0f;

        void Start()
        {
            for(int i = 0; i < countY; i++)
            {
                // instantiate a row of prefabs
                for(int j = 0; j < countX; j++)
                {
                    // instantiate copy of prefab as a child of this gameobject
                    GameObject copy = Instantiate(prefab, this.transform);

                    // create local position of copy
                    Vector3 pos = new Vector3(j * spacingX, i * spacingY, 0.0f);

                    // assign local position of copy
                    copy.transform.localPosition = pos;
                }
            }
        }
       
    }

}
