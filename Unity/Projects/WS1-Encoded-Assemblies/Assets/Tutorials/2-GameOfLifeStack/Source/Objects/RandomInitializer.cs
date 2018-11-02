using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RC3
{
    /// <summary>
    /// 
    /// </summary>
    [CreateAssetMenu(menuName = "RC3/WS1/RandomInitializer")]
    public class RandomInitializer : ModelInitializer
    {
        [SerializeField] float _threshold = 0.75f;


        /// <summary>
        /// 
        /// </summary>
        /// <param name="state"></param>
        public override void Initialize(int[,] state)
        {
            int m = state.GetLength(0);
            int n = state.GetLength(1);

            for(int i = 0; i < m; i++)
            {
                for(int j = 0; j < n; j++)
                {
                    if (Random.Range(0.0f, 1.0f) > _threshold)
                        state[i, j] = 1;
                    else
                        state[i, j] = 0;
                }
            }
        }
    }
}
