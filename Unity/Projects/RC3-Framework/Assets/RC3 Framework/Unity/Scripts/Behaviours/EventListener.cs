using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using UnityEngine;
using UnityEngine.Events;

namespace RC3.Unity
{
    /// <summary>
    /// 
    /// </summary>
    public class EventListener : MonoBehaviour
    {
        [SerializeField]
        private Event _event;

        [SerializeField]
        private UnityEvent _response;


        /// <summary>
        /// 
        /// </summary>
        private void OnEnable()
        {
            _event.Register(this);
        }


        /// <summary>
        /// 
        /// </summary>
        private void OnDisable()
        {
            _event.Unregister(this);
        }


        /// <summary>
        /// 
        /// </summary>
        public void OnEventRaised()
        {
            _response.Invoke();
        }
    }
}
