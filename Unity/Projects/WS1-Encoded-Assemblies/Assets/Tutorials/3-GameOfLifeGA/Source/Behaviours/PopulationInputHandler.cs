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
        [RequireComponent(typeof(PopulationManager))]
        public class PopulationInputHandler : MonoBehaviour
        {
            private PopulationManager _manager;
            private PopulationDisplay _display;

            /// <summary>
            /// 
            /// </summary>
            private void Start()
            {
                _manager = GetComponent<PopulationManager>();
                _display = GetComponent<PopulationDisplay>();
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
                // Update display mode
                if (Input.GetKeyDown(KeyCode.Alpha4))
                {
                    if (_display.DisplayMode != CellDisplayMode.Fitness)
                    {
                        _display.DisplayMode = CellDisplayMode.Fitness;
                        _display.DisplayChange = true;
                    }
                }

                if (Input.GetKeyDown(KeyCode.Alpha5))
                {
                    if (_display.PopDisplayMode != PopulationDisplayMode.None)
                    {
                        _display.PopDisplayMode = PopulationDisplayMode.None;
                        _display.PopDisplayChange = true;
                    }
                }

                else if (Input.GetKeyDown(KeyCode.Alpha6))
                {
                    if (_display.PopDisplayMode != PopulationDisplayMode.Generation)
                    {
                        _display.PopDisplayMode = PopulationDisplayMode.Generation;
                        _display.PopDisplayChange = true;
                    }
                }

                else if (Input.GetKeyDown(KeyCode.Alpha7))
                {
                    if (_display.PopDisplayMode != PopulationDisplayMode.Fittest)
                    {
                        _display.PopDisplayMode = PopulationDisplayMode.Fittest;
                        _display.PopDisplayChange = true;
                    }
                }

                else if (Input.GetKeyDown(KeyCode.Alpha8))
                {
                    if (_display.PopDisplayMode != PopulationDisplayMode.All)
                    {
                        _display.PopDisplayMode = PopulationDisplayMode.All;
                        _display.DisplayChange = true;
                    }
                }
            }
        }
    }
}
