using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RC3
{
    /// <summary>
    /// 
    /// </summary>
    public abstract class InitScheduler : InitBehavior
    {
        [SerializeField] private InitBehavior[] _objects;


        /// <summary>
        /// 
        /// </summary>
        public override void Initialize()
        {
            foreach (var obj in _objects)
                obj.Initialize();
        }
    }
}
