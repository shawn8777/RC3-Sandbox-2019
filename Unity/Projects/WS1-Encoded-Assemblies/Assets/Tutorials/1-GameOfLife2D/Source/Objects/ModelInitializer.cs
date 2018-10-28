using UnityEngine;

namespace RC3
{
    /// <summary>
    /// 
    /// </summary>
    public abstract class ModelInitializer : ScriptableObject
    {
        public abstract void Initialize(int[,] state);
    }
}
