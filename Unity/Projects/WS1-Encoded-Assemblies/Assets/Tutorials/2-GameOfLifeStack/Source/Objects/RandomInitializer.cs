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
        INITIALIZERTYPE _type = INITIALIZERTYPE.Random;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="state"></param>
        public override void Initialize(int[,] state)
        {
            int nrows = state.GetLength(0);
            int ncols = state.GetLength(1);

            for (int i = 0; i < nrows; i++)
            {
                for (int j = 0; j < ncols; j++)
                {
                    if (Random.Range(0.0f, 1.0f) > _threshold)
                        state[i, j] = 1;
                    else
                        state[i, j] = 0;
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="state"></param>
        /// <param name="texture"></param>
        public override void Initialize(int[,] state, Texture2D texture)
        {
            Initialize(state);
        }

        /// <summary>
        /// 
        /// </summary>
        public override INITIALIZERTYPE Type
        {
            get { return _type; }
        }


    }
}
