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
        private StackModel _model;
        private StackDisplay _display;


        /// <summary>
        /// 
        /// </summary>
        private void Start()
        {
            _model = GetComponent<StackModel>();
            _display = GetComponent<StackDisplay>();
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

            // Update display mode
            if (Input.GetKeyDown(KeyCode.Alpha1))
                _display.DisplayMode = CellDisplayMode.Age;
            else if (Input.GetKeyDown(KeyCode.Alpha2))
                _display.DisplayMode = CellDisplayMode.LayerDensity;
            else if (Input.GetKeyDown(KeyCode.Alpha3))
                _display.DisplayMode = CellDisplayMode.NeighborDensity;
        }
    }
}
