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
        /// 
        /// </summary>
        private CARule2D[] _rules =
        {
            new Conway2D(Neighborhoods.MooreR1),
            new Conway2D(Neighborhoods.VonNeumannR1)
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
