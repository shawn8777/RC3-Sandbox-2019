using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RC3
{
    public class Cell : MonoBehaviour
    {
        private MeshRenderer _renderer;
        private const int _defaultState = 0;


        /// <summary>
        /// 
        /// </summary>
        private void Start()
        {
            _renderer = GetComponent<MeshRenderer>();
            SetState(_defaultState);
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        public void SetState(int value)
        {
            // if dead, turn off cell
            // if alive, turn on
            if (value == 0)
                _renderer.enabled = false;
            else
                _renderer.enabled = true;
        }
    }
}
