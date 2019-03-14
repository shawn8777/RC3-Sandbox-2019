/*
 * Notes
 */

using UnityEngine;

namespace RC3.Unity
{
    /// <summary>
    /// 
    /// </summary>
    public abstract class Initializer<T> : ScriptableObject
    {
        /// <summary>
        /// 
        /// </summary>
        public abstract void Initialize(T target);
    }
}
