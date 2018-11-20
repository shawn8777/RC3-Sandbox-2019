using UnityEngine;

namespace RC3
{
    /// <summary>
    /// 
    /// </summary>
    public abstract class ModelInitializer : ScriptableObject
    {
        public abstract void Initialize(int[,] state);
        public abstract void Initialize(int[,] state, Texture2D texture);
        public abstract INITIALIZERTYPE Type { get; }
    }

    public enum INITIALIZERTYPE
    {
        Random,
        Image,
    }
}
