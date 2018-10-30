using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RC3
{
    public class Test : MonoBehaviour
    {
        /// <summary>
        /// 
        /// </summary>
        void Start()
        {
            ModuloTest();
        }


        /// <summary>
        /// 
        /// </summary>
        private void ModuloTest()
        {
            int n = 100;
            int d = 5;

            for(int i = 0; i < n; i++)
            {
                int x = i % d;
                Debug.Log($"{i} % {d} = {x}");
            }
        }
    }
}
