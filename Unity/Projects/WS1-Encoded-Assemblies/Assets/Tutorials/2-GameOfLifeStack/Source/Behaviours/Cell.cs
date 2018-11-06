using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RC3
{
    public class Cell : MonoBehaviour
    {
        private MeshRenderer _renderer;
        private const int _defaultState = 0;

        private int _state = 0;
        private int _age = 0;

        /// <summary>
        /// 
        /// </summary>
        private void Awake()
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
            _state = value;

            
            if (value == 0)
                _renderer.enabled = false;
            else
                _renderer.enabled = true;
                
        }

        /// <summary>
        /// 
        /// </summary>
        public int State
        {
            get { return _state; }
        }

        /// <summary>
        /// 
        /// </summary>
        public int Age
        {
            get { return _age; }
            set { _age = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        public MeshRenderer Renderer
        {
            get { return _renderer; }
        }
    }
}
