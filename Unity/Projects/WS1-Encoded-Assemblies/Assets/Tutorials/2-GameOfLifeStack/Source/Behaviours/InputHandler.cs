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

        private IndexPair[][] _neighbourhoods =
        {
            Neighborhoods.MooreR1,
            Neighborhoods.VonNeumannR1
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
        public void SetNeighbourhood(int value)
        {
            _manager.Model.Offsets = _neighbourhoods[value];
        }
    }
}
