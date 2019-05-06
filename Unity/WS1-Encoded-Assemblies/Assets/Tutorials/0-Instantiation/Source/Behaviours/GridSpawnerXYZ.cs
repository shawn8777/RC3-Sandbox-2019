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
    public class GridSpawnerXYZ : MonoBehaviour
    {
        public GameObject prefab;
        public int countX = 10;
        public int countY = 10;
        public int countZ = 10;
        public float spacingX = 2.0f;
        public float spacingY = 2.0f;
        public float spacingZ = 2.0f;

        void Start()
        {
            // instantiates a volume of prefabs
            for(int z = 0; z < countZ; z++)
            {

                // instantiates a layer of prefabs
                for(int y = 0; y < countY; y++)
                {

                    // instantiates a row of prefabs
                    for(int x = 0; x < countX; x++)
                    {
                        // instantiate copy of prefab as a child of this gameobject
                        GameObject copy = Instantiate(prefab, this.transform);

                        // create local position of copy
                        Vector3 pos = new Vector3(x * spacingX, y * spacingY, z * spacingZ);

                        // assign local position of copy
                        copy.transform.localPosition = pos;
                    }

                }

            }

        }
        

        
    }

    
}
