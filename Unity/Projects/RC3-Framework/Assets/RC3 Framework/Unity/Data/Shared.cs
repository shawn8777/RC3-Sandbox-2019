using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RC3.Unity
{
    /// <summary>
    /// 
    /// </summary>
    public class Shared<T> : ScriptableObject
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="shared"></param>
        public static implicit operator T(Shared<T> shared)
        {
            return shared.Value;
        }


        [SerializeField] private T _value;


        /// <summary>
        /// 
        /// </summary>
        public T Value
        {
            get { return _value; }
            set { _value = value; }
        }
    }
}
