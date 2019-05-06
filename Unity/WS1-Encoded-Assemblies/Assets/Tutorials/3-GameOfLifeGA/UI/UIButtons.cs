using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.AI;
using UnityEditor;
using SpatialSlur;
using System;
using System.Collections;
using System.Collections.Generic;
using ABPS;

namespace ABPS
{
    [AddComponentMenu("ABPSFramework/UIButtons")]
    public class UIButtons : MonoBehaviour
    {
        /*
        #region Member Variables

        // Main Buttons ////////////
        // Bool
        private bool _is_displaypanelopen = false;
        private bool _is_setuppanelopen = false;
        private bool _startscene = false;
        private bool _is_behaviorpanelopen = false;
        private bool _is_outputpanelopen = false;//added
        private bool _is_datapanelopen = false;


        private bool _paused = false;
        //private bool _is_startbuttonPressed = false;

        // Button
        private Button _displaybutton;
        private Button _setupbutton;
        private Button _startbutton;
        private Button _behaviorbutton;
        private Button _pausebutton;

        private Button _outputbutton; //added
        private Button _databutton;//added
      


        // Panel
        private GameObject _displaypanel;
        private GameObject _setuppanel;
        private GameObject _behaviorpanel;

        private GameObject _outputpanel;//added
        private GameObject _datapanel;//added

        // Nested Panels ///////////
        // Toggles
        private Toggle _togglemainshowagentcolor;
        private Toggle _togglemainshowslider;
        private Toggle _togglemainshowdata;
        private Toggle _togglemainshowperception;
        private Toggle _togglemainshowagentdisplay;
        private Toggle _toggleinfluencemap;

        private Toggle _togglehistory;
        private Toggle _togglehistorymappanel;
        private GameObject _panelhistorymap;
        private GameObject _panelmapsettings;

        private Toggle _togglemainshowagentdata;//added
        private Toggle _togglemainshowconvodata;//added
        private Toggle _togglemainshowdestdata;//added
        private Toggle _togglemainshowactiondata;//added


        // Panels
        private GameObject _paneltogglecolor;
        private GameObject _paneltoggleslider;
        private GameObject _paneltoggledata;
        private GameObject _panelperception;
        private GameObject _panelagentdisplay;
        private GameObject _panelinfluencemap;

        private GameObject _paneloutput;//added
        private GameObject _paneloutputdata; //added
        private GameObject _panelagentdata;
        private GameObject _panelconvodata;
        private GameObject _paneldestdata;
        private GameObject _panelactiondata;


        //private GameObject _displaypanel;

        // Bool 
        private bool _isSubPanelOpen = true; //modified

        private GameObject _contextObj;
        private Context _context;

        #endregion

        #region Constructors

        // Use this for initialization
        private void Awake()
        {

            _contextObj = GameObject.Find("Context");

            if (_contextObj == null)
            {
                Debug.Log("Epic Fail - No game object named- Context -");
            }

            _context = _contextObj.GetComponent<Context>();

            if (_context == null)
            {
                Debug.Log("Epic Fail - No game object with Context component attached");
            }

        }
        private void Start()
        {


            // Start
            _startbutton = GameObject.Find("StartButton").GetComponent<Button>();
            _startbutton.onClick.AddListener(StartScene);

            // Displays
            _displaybutton = GameObject.Find("DisplayButton").GetComponent<Button>();
            _displaypanel = GameObject.Find("DisplayPanel");
            _displaybutton.onClick.AddListener(TaskOn_DisplayButtonClick);

            // Setup
            _setupbutton = GameObject.Find("SetupButton").GetComponent<Button>();
            _setuppanel = GameObject.Find("SetupPanel");
            _setupbutton.onClick.AddListener(TaskOn_SetupButtonClick);

            // Behavior
            _behaviorbutton = GameObject.Find("BehaviorButton").GetComponent<Button>();
            _behaviorpanel = GameObject.Find("BehaviorPanel");
            _behaviorbutton.onClick.AddListener(TaskOn_BehaviorButtonClick);

            //Output
            _outputbutton = GameObject.Find("OutputButton").GetComponent<Button>();
            _outputpanel = GameObject.Find("OutputPanel");
            _outputbutton.onClick.AddListener(TaskOn_OutputButtonClick);

            //Data
            _databutton = GameObject.Find("DataButton").GetComponent<Button>();
            _datapanel = GameObject.Find("DataPanel");
            _databutton.onClick.AddListener(TaskOn_DataButtonClick);

            // Pause
            _pausebutton = GameObject.Find("PauseButton").GetComponent<Button>();
            _pausebutton.onClick.AddListener(Press_PauseButton);

            // Nested Panels 

            _togglemainshowagentcolor = GameObject.Find("Main_Toggle_Color").GetComponent<Toggle>();
            _togglemainshowslider = GameObject.Find("Main_Toggle_Slider").GetComponent<Toggle>();
            _togglemainshowdata = GameObject.Find("Main_Toggle_Data").GetComponent<Toggle>();
            _togglemainshowperception = GameObject.Find("Main_Toggle_Perception").GetComponent<Toggle>();
            _togglemainshowagentdisplay = GameObject.Find("Main_Toggle_AgentDisplay").GetComponent<Toggle>();
            _toggleinfluencemap = GameObject.Find("Main_Toggle_InfluenceMap").GetComponent<Toggle>();

            _togglehistory = GameObject.Find("Toggle_HistoryMap").GetComponent<Toggle>();
            _togglehistorymappanel = GameObject.Find("Main_Toggle_HistoryMap").GetComponent<Toggle>();
            _panelhistorymap = GameObject.Find("Panel_Toggle_HistoryMap");
            _panelmapsettings = GameObject.Find("Panel_MapSettings");

            _paneltogglecolor = GameObject.Find("Panel_Toggle_Color");
            _paneltoggleslider = GameObject.Find("Panel_Toggle_Sliders");
            _paneltoggledata = GameObject.Find("Panel_Toggle_Data");
            _panelperception = GameObject.Find("Panel_Toggle_Perception");
            _panelagentdisplay = GameObject.Find("Panel_Toggle_AgentDisplayMode");
            _panelinfluencemap = GameObject.Find("Panel_Toggle_InfluenceMap");

            //output data
            _togglemainshowagentdata = GameObject.Find("Main_Toggle_AgentData").GetComponent<Toggle>();
            _togglemainshowconvodata = GameObject.Find("Main_Toggle_ConvoData").GetComponent<Toggle>();
            _togglemainshowdestdata = GameObject.Find("Main_Toggle_DestData").GetComponent<Toggle>();
            _togglemainshowactiondata = GameObject.Find("Main_Toggle_ActionData").GetComponent<Toggle>();

            _panelagentdata = GameObject.Find("Panel_Toggle_AgentData");
            _panelconvodata = GameObject.Find("Panel_Toggle_ConvoData");
            _paneldestdata = GameObject.Find("Panel_Toggle_DestData");
            _panelactiondata = GameObject.Find("Panel_Toggle_ActionData");

            PauseScene();
        }

        #endregion

        #region Private Methods

        // Update is called once per frame
        private void Update()
        {
            SwitchOnOff_DisplayPanel();
            SwitchOnOff_SetupPanel();
            //startScene();
            //Debug.Log("UIButton_ Start Button: " + _startscene);
            SwitchOnOff_BehaviorPanel();

            //data output
            SwitchOnOff_OutputPanel();
            SwitchOnOff_DataPanel();

            // Start / restart function
            if (_startscene == true)
            {
                RestartScene();
            }

            PauseScene();

            // Nested Panels
            OpenAgentColorCodingPanel();
            OpenSliderPanel();
            OpenDataPanel();
            OpenOutputPanel(); //added
            OpenPerceptionPanel();
            OpenAgentDisplayModePanel();
            OpenInfluenceMapPanel();

            OpenHistoryMapDisplayPanel();
            OpenMapSettingsPanel();

            //data output
            SwitchOnOff_DataPanel();

            OpenAgentDataPanel();
            OpenConvoDataPanel();
            OpenDestDataPanel();
            OpenActionDataPanel();


        }

        private void TaskOn_SetupButtonClick()
        {
            if (_is_setuppanelopen == false)
            {
                _is_setuppanelopen = true;
                _is_displaypanelopen = false;
                _is_behaviorpanelopen = false;
                _is_outputpanelopen = false;
                _is_datapanelopen = false;
            }

            else
            {
                _is_setuppanelopen = false;
            }
        }
        private void SwitchOnOff_SetupPanel()
        {
            if (_is_setuppanelopen == true)
            {
                _setuppanel.SetActive(true);
            }

            if (_is_setuppanelopen == false)
            {
                _setuppanel.SetActive(false);
            }
        }

        private void TaskOn_BehaviorButtonClick()
        {
            if (_is_behaviorpanelopen == false)
            {
                _is_behaviorpanelopen = true;
                _is_setuppanelopen = false;
                _is_displaypanelopen = false;
                _is_outputpanelopen = false;
                _is_datapanelopen = false;
            }

            else
            {
                _is_behaviorpanelopen = false;
            }
        }
        private void SwitchOnOff_BehaviorPanel()
        {
            if (_is_behaviorpanelopen == true)
            {
                _behaviorpanel.SetActive(true);
            }

            if (_is_behaviorpanelopen == false)
            {
                _behaviorpanel.SetActive(false);
            }
        }
        private void TaskOn_DisplayButtonClick()
        {

            if (_is_displaypanelopen == false)
            {
                _is_displaypanelopen = true;
                _is_setuppanelopen = false;
                _is_behaviorpanelopen = false;
                _is_outputpanelopen = false;
                _is_datapanelopen = false;

            }

            else
            {
                _is_displaypanelopen = false;

            }
        }
        private void SwitchOnOff_DisplayPanel()
        {
            if (_is_displaypanelopen == true)
            {
                _displaypanel.SetActive(true);
            }

            if (_is_displaypanelopen == false)
            {
                _displaypanel.SetActive(false);
            }
        }


        private void TaskOn_DataButtonClick()
        {

            if (_is_datapanelopen == false)
            {
                _is_displaypanelopen = false;
                _is_setuppanelopen = false;
                _is_behaviorpanelopen = false;
                _is_outputpanelopen = false;
                _is_datapanelopen = true;

            }

            else
            {
                _is_datapanelopen = false;

            }
        }

        private void SwitchOnOff_DataPanel()
        {
            if (_is_datapanelopen == true)
            {
                _datapanel.SetActive(true);
            }

            if (_is_datapanelopen == false)
            {
                _datapanel.SetActive(false);
            }
        }

        private void TaskOn_OutputButtonClick()
        {

            if (_is_outputpanelopen == false)
            {
                _is_displaypanelopen = false;
                _is_setuppanelopen = false;
                _is_behaviorpanelopen = false;
                _is_outputpanelopen = true;
                _is_datapanelopen = false;

            }

            else
            {
                _is_outputpanelopen = false;

            }
        }

        private void SwitchOnOff_OutputPanel()
        {
            if (_is_outputpanelopen == true)
            {
                _outputpanel.SetActive(true);
            }

            if (_is_outputpanelopen == false)
            {
                _outputpanel.SetActive(false);
            }

        }



        private void StartScene()
        {
            if (_startscene == true)
            {
                _startscene = false;
            }
            else
            {
                _startscene = true;
            }
        }

        private void RestartScene()
        {
            //SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            _context.Build();
            _startscene = false;
        }
        private void Press_PauseButton()
        {
            if (_context.Pause == false)
            {
                _context.Pause = true;
            }

            else
            {
                _context.Pause = false;
            }

        }
        private void PauseScene()
        {
            if (_paused == true)
            {
                //Time.timeScale = 0;
            }
            else
            {
                //Time.timeScale = 1;
            }
        }

        // Nested Panels //////

        private void OpenAgentColorCodingPanel()
        {
            if (_togglemainshowagentcolor.isOn == false)
            {
                _paneltogglecolor.SetActive(false);
            }

            if (_togglemainshowagentcolor.isOn == true)
            {
                _paneltogglecolor.SetActive(true);
            }
        }
        private void OpenSliderPanel()
        {
            if (_togglemainshowslider.isOn == false)
            {
                _paneltoggleslider.SetActive(false);
            }

            if (_togglemainshowslider.isOn == true)
            {
                _paneltoggleslider.SetActive(true);
            }
        }

        private void OpenOutputPanel()
        {
            //          if (_togglemainshowoutput.isOn == false)
            //          {
            //              _paneltoggledata.SetActive(false);
            //        }
            //
            //        if (_togglemainshowoutput.isOn == true)
            //       {
            //           _paneltoggledata.SetActive(true);
            //       }
        }
        private void OpenDataPanel()
        {
            if (_togglemainshowdata.isOn == false)
            {
                _paneltoggledata.SetActive(false);
            }

            if (_togglemainshowdata.isOn == true)
            {
                _paneltoggledata.SetActive(true);
            }

        }
        private void OpenPerceptionPanel()
        {
            if (_togglemainshowperception.isOn == false)
            {
                _panelperception.SetActive(false);
            }

            if (_togglemainshowperception.isOn == true)
            {
                _panelperception.SetActive(true);
            }
        }

        private void OpenAgentDisplayModePanel()
        {
            if (_togglemainshowagentdisplay.isOn == false)
            {
                _panelagentdisplay.SetActive(false);
            }

            if (_togglemainshowagentdisplay.isOn == true)
            {
                _panelagentdisplay.SetActive(true);
            }
        }
        private void OpenInfluenceMapPanel()
        {
            if (_toggleinfluencemap.isOn == false)
            {
                _panelinfluencemap.SetActive(false);
            }

            if (_toggleinfluencemap.isOn == true)
            {
                _panelinfluencemap.SetActive(true);
            }
        }

        public void OpenHistoryMapDisplayPanel()
        {

            if (_toggleinfluencemap.isOn == false || _togglehistory.isOn == false)
            {
                _togglehistorymappanel.isOn = false;
                _panelhistorymap.SetActive(false);
            }

            if (_toggleinfluencemap.isOn == true && _togglehistory.isOn == true)
            {
                _togglehistorymappanel.isOn = true;
                _panelhistorymap.SetActive(true);
            }

            if (_togglehistorymappanel.isOn == false)
            {
                _panelhistorymap.SetActive(false);
            }

            if (_togglehistorymappanel.isOn == true)
            {
                _panelhistorymap.SetActive(true);
            }

        }

        public void OpenMapSettingsPanel()
        {
            if (_toggleinfluencemap.isOn == false)
            {
                _panelmapsettings.SetActive(false);
            }

            if (_toggleinfluencemap.isOn == true)
            {
                _panelmapsettings.SetActive(true);
            }
        }


        /// <summary>
        /// Output Data
        /// </summary>
        private void OpenAgentDataPanel()
        {
            if (_togglemainshowagentdata.isOn == false)
            {
                _panelagentdata.SetActive(false);
            }

            if (_togglemainshowagentdata.isOn == true)
            {
                _panelagentdata.SetActive(true);
            }
        }

        private void OpenConvoDataPanel()
        {
            if (_togglemainshowconvodata.isOn == false)
            {
                _panelconvodata.SetActive(false);
            }

            if (_togglemainshowconvodata.isOn == true)
            {
                _panelconvodata.SetActive(true);
            }
        }

        private void OpenDestDataPanel()
        {
            if (_togglemainshowdestdata.isOn == false)
            {
                _paneldestdata.SetActive(false);
            }

            if (_togglemainshowdestdata.isOn == true)
            {
                _paneldestdata.SetActive(true);
            }
        }

        private void OpenActionDataPanel()
        {
            if (_togglemainshowactiondata.isOn == false)
            {
                _panelactiondata.SetActive(false);
            }

            if (_togglemainshowactiondata.isOn == true)
            {
                _panelactiondata.SetActive(true);
            }
        }
        #endregion

        #region Public Methods
        #endregion

        #region Public Properties

        #endregion
        */
    }
}