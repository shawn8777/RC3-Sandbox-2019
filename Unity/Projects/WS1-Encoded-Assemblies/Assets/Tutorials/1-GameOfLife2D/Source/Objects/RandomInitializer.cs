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
            int countY = state.GetLength(0);
            int countX = state.GetLength(1);

            for(int y = 0; y < countY; y++)
            {
                for(int x = 0; x < countX; x++)
                {
                    if (Random.Range(0.0f, 1.0f) > _threshold)
                        state[y, x] = 1;
                    else
                        state[y, x] = 0;
                    
                    // same as above
                    // state[y, x] = (Random.Range(0.0f, 1.0f) > _threshold) ? 1 : 0;
                }
            }
        }
    }
}
