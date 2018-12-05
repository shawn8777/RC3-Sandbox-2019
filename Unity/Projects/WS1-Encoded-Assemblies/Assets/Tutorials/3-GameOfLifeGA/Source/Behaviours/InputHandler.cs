using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RC3
{
    namespace WS2
    {
        /// <summary>
        /// 
        /// </summary>
        public class InputHandler : MonoBehaviour
        {
            private StackModel _model;
            private StackDisplay _stackDisplay;

            /// <summary>
            /// 
            /// </summary>
            private void Start()
            {
                _model = GetComponent<StackModel>();
                _stackDisplay = GetComponent<StackDisplay>();
            }


            /// <summary>
            /// 
            /// </summary>
            private void Update()
            {
                HandleKeyPress();
            }


            /// <summary>
            /// 
            /// </summary>
            private void HandleKeyPress()
            {
                // Reset model
                if (Input.GetKeyDown(KeyCode.Space))
                    _model.ResetModel();

                if (Input.GetKeyDown(KeyCode.P))
                {
                    if (_model.Pause == true)
                    {
                        _model.Pause = false;
                    }

                    else
                    {
                        _model.Pause = true;
                    }
                }

                // Update display mode
                if (Input.GetKeyDown(KeyCode.Alpha1))
                    _stackDisplay.DisplayMode = CellDisplayMode.Alive;
                else if (Input.GetKeyDown(KeyCode.Alpha2))
                    _stackDisplay.DisplayMode = CellDisplayMode.Age;
                else if (Input.GetKeyDown(KeyCode.Alpha3))
                    _stackDisplay.DisplayMode = CellDisplayMode.LayerDensity;
                else if (Input.GetKeyDown(KeyCode.Alpha4))
                    _stackDisplay.DisplayMode = CellDisplayMode.NeighborDensity;
            }
        }
    }
}
