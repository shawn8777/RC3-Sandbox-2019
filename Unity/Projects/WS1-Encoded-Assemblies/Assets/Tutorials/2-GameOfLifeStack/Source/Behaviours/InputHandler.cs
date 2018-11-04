using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RC3
{
    /// <summary>
    /// 
    /// </summary>
    public class InputHandler : MonoBehaviour
    {
        private StackManager _manager;

        /// <summary>
        /// Array of rules that can be swapped between
        /// </summary>
        private ICARule2D[] _rules =
        {
            new ConwaySimple2D()
        };


        /// <summary>
        /// 
        /// </summary>
        private void Start()
        {
            _manager = GetComponent<StackManager>();
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        public void SetRule(int value)
        {
            _manager.Model.Rule = _rules[value];
        }
    }
}
