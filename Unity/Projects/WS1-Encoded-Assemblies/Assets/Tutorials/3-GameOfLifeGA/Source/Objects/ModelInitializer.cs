using UnityEngine;

namespace RC3
{
    namespace WS2
    {

        /// <summary>
        /// 
        /// </summary>
        public abstract class ModelInitializer : ScriptableObject
        {
            public abstract void Initialize(int[,] state);
            public abstract void Initialize(int[,] state, Texture2D texture);

        }
    }
}
