using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;
using UnityEditor;
using SpatialSlur;
using System.Collections;
using System.Collections.Generic;
using ABPS;

namespace ABPS
{

    public class UIDisplay : MonoBehaviour
    {
        /*
        #region Member Variables

        private GameObject _contextObj;
        private Context _context;
        private Environment _environment;
        private EnvironmentData _environmentdata;

        private TimeSpeed _timespeed;


        // For Display
        private Toggle _toggledepartment;
        private Toggle _toggleteam;
        private Toggle _togglerank;
        private Toggle _toggleaction;
        private Toggle _toggleselected;


        private Toggle _togglesocial;
        private Toggle _toggleenergy;
        private Toggle _togglemotivation;
        private Toggle _toggleshowallsliders;

        private Toggle _toggledatapoints;
        private Toggle _toggledatapointstime;
        private Toggle _toggledatapointsaction;
        private Toggle _toggleactioncount;

        private Toggle _togglevisibleobject;
        private Toggle _togglevisibleneighbour;
        private Toggle _togglefriends;
        private Toggle _toggledisplayconvos;


        private Toggle _togglesimplemodel;
        private Toggle _toggleriggedmodel;
        private Toggle _toggleagentcam;

        private Toggle _toggleagentinfluence;
        private Toggle _togglezones;
        private Toggle _togglehistory;
        private Toggle _toggledefault;

        private Slider _sliderDecay;
        private Text _decaytext;


        private Toggle _togglehistorymappanel;
        private GameObject _panelhistorymap;
        private GameObject _panelmapsettings;

        private Toggle _togglegriddisplay;
        private Slider _slidergridheight;
        private Text _gridheighttext;


        private Toggle _togglehistoryall;
        private Toggle _togglehistorystanding;
        private Toggle _togglehistorywalking;
        private Toggle _togglehistoryconversation;
        private Toggle _togglehistorysitting;
        private Toggle _togglehistorymeeting;
        //
        HistoryMapDisplay _historymapdisplay;
        InfluenceMapDisplay _occupancymapdisplay;

        // For Setup
        private Slider _occupancyslider;
        private Text OccupancyText;
        private InputField _maxnumberagent;
        private Text _maxnumberagenttext;
        private Slider _maxnumberagentslider;

        private Toggle _togglespawntypehome;
        private Toggle _togglespawntypespawnsource;
        private Toggle _togglespawntypeboth;
        private Slider _spawnrate;
        private Text _spawnratetext;
        private Slider _spawnsourceperc;
        private Text _spawnsourceperctext;

        private InputField _numberagentrank;
        private InputField _numberofdepartment;
        private InputField _numberofteam;
        private Text _occupancypercentage;

        private Slider _overallsocialslider;
        private Text _overallsocialvaluetext;
        private Slider _overallmotivationslider;
        private Text _overallmotivationvaluetext;
        private Slider _overallrangeslider;
        private Text _overallrangevaluetext;

        //private Slider _timespeedslider;




        //OUTPUT STUFF/////////////////////////////////////////////////////////////////////////////////
        //Output Panel /////////////////////////////////////////////////
        private ProgressBar _environmentActionsPerc_Idle;
        private ProgressBar _environmentActionsPerc_Walking;
        private ProgressBar _environmentActionsPerc_Conversation;
        private ProgressBar _environmentActionsPerc_WorkingAlone;
        private ProgressBar _environmentActionsPerc_ScheduledMeeting;
        private ProgressBar _environmentActionsPerc_WorkingCollab;
        private ProgressBar _environmentActionsPerc_EatDrink;
        private ProgressBar _environmentActionsPerc_WC;
        private ProgressBar _environmentActionsPerc_ExtBreak;

        private Slider _environmentConversations_TotalNum;
        private Slider _environmentConversations_TotalNumLong;
        private Slider _environmentConversations_TotalNumShort;

        private RadialSlider _environmentConversations_TotalConvDuration;
        private RadialSlider _environmentConversations_TotalMeetingDuration;
        private RadialSlider _environmentConversations_AvgConvDuration;
        private RadialSlider _environmentConversations_AvgMeetingDuration;
        private RadialSlider _environmentConversations_TotalFormalMeetingDuration;
        private RadialSlider _environmentConversations_TotalDeskMeetingDuration;

        private Slider _environmentConversations_TotalNumSameType;
        private Slider _environmentConversations_TotalNumDiffType;

        //actions
        private Text _envAction1Time;
        private Text _envAction2Time;
        private Text _envAction3Time;
        private Text _envAction4Time;
        private Text _envAction5Time;
        private Text _envAction6Time;
        private Text _envAction7Time;
        private Text _envAction8Time;
        private Text _envAction9Time;
        private Text _envAction10Time;

        private Text _envAction1Perc;
        private Text _envAction2Perc;
        private Text _envAction3Perc;
        private Text _envAction4Perc;
        private Text _envAction5Perc;
        private Text _envAction6Perc;
        private Text _envAction7Perc;
        private Text _envAction8Perc;
        private Text _envAction9Perc;
        private Text _envAction10Perc;

        private Text _agCurrentAction;
        private Text _agCurrentSubAction;

        private Text _agAction1Time;
        private Text _agAction2Time;
        private Text _agAction3Time;
        private Text _agAction4Time;
        private Text _agAction5Time;
        private Text _agAction6Time;
        private Text _agAction7Time;
        private Text _agAction8Time;
        private Text _agAction9Time;
        private Text _agAction10Time;

        private Text _agAction1Perc;
        private Text _agAction2Perc;
        private Text _agAction3Perc;
        private Text _agAction4Perc;
        private Text _agAction5Perc;
        private Text _agAction6Perc;
        private Text _agAction7Perc;
        private Text _agAction8Perc;
        private Text _agAction9Perc;
        private Text _agAction10Perc;

        //agents

        private Text _agcount;
        private Text _agtypecount;
        private Text _agtype1;
        private Text _agtype2;
        private Text _teamcount;
        private Text _depcount;

        //destinations
        private Text _destcount;
        private Text _destprivatecount;
        private Text _destpubliccount;
        private Text _destleastoccupied;
        private Text _destleastoccupiedtime;
        private Text _destmostoccupied;
        private Text _destmostoccupiedtime;

        //conversations
        private Text _convocount;
        private Text _currentconvocount;
        private Text _convotime;
        private Text _avgconvotime;


        //OUTPUT STUFFF/////////////////////////////////////////////////////////////////////////////////


        private Text _agentcount;
        private GameObject _zonesobj;

        #endregion

        #region Constructors

        private void Awake()
        {
            _contextObj = GameObject.Find("Context");

            if (_contextObj == null)
            {
                Debug.Log("Epic Fail - No game object named- Context -");
            }



            _environment = _contextObj.GetComponent<Context>().Environment;
            _context = _contextObj.GetComponent<Context>();

            if (_context == null)
            {
                Debug.Log("Epic Fail - No game object with Context component attached");
            }

            _environmentdata = _context.EnvironmentData;

            _maxnumberagent = GameObject.Find("MaxAgentsInputField").GetComponent<InputField>();
            //_maxnumberagentslider = GameObject.Find("MaxAgentsSlider").GetComponent<Slider>();
            //_maxnumberagent.onValueChanged.AddListener(delegate { AddAgents(); }); //check efficiency!!!!!
            //_maxnumberagentslider.onValueChanged.AddListener(delegate { AddAgents(); }); //check efficiency!!!!!
            //_maxnumberagenttext = GameObject.Find("MaxAgents#Text").GetComponent<Text>();
            //_maxnumberagenttext.text = Convert.ToString(_maxnumberagentslider.value);

            //_timespeed = gameObject.transform.parent.GetComponent<TimeSpeed>();

        }

        // Use this for initialization
        private void Start()
        {

            //OUTPUT STUFFF/////////////////////////////////////////////////////////////////////////////////
            //output panel /////////////////////////////////////////////////
            
            _environmentActionsPerc_Idle = GameObject.Find("Radial PB Filled_Idle").GetComponent<ProgressBar>();
            _environmentActionsPerc_Walking = GameObject.Find("Radial PB Filled_Walking").GetComponent<ProgressBar>();
            _environmentActionsPerc_Conversation = GameObject.Find("Radial PB Filled_Conversation").GetComponent<ProgressBar>();
            _environmentActionsPerc_WorkingAlone = GameObject.Find("Radial PB Filled_DeskWork").GetComponent<ProgressBar>();
            _environmentActionsPerc_ScheduledMeeting = GameObject.Find("Radial PB Filled_Meeting").GetComponent<ProgressBar>();
            _environmentActionsPerc_WorkingCollab = GameObject.Find("Radial PB Filled_CollabWork").GetComponent<ProgressBar>();
            _environmentActionsPerc_EatDrink = GameObject.Find("Radial PB Filled_EatDrink").GetComponent<ProgressBar>();
            _environmentActionsPerc_WC = GameObject.Find("Radial PB Filled_WC").GetComponent<ProgressBar>();
            _environmentActionsPerc_ExtBreak = GameObject.Find("Radial PB Filled_ExternalBreak").GetComponent<ProgressBar>();

            _environmentConversations_TotalNum = GameObject.Find("Slider Gradient_TotNumConvos").GetComponent<Slider>();
            _environmentConversations_TotalNumLong = GameObject.Find("Slider Gradient_TotNumLongConvos").GetComponent<Slider>();
            _environmentConversations_TotalNumShort = GameObject.Find("Slider Gradient_TotNumShortConvos").GetComponent<Slider>();

            _environmentConversations_TotalConvDuration = GameObject.Find("Radial Gradient_TotConvosDuration").GetComponent<RadialSlider>();
            _environmentConversations_TotalMeetingDuration = GameObject.Find("Radial Gradient_TotMeetingsDuration").GetComponent<RadialSlider>();
            _environmentConversations_AvgConvDuration = GameObject.Find("Radial Gradient_AvgConvosDuration").GetComponent<RadialSlider>();
            _environmentConversations_AvgMeetingDuration = GameObject.Find("Radial Gradient_AvgMeetingsDuration").GetComponent<RadialSlider>();
            _environmentConversations_TotalFormalMeetingDuration = GameObject.Find("Radial Gradient_TotFormalMeetingsDuration").GetComponent<RadialSlider>();
            _environmentConversations_TotalDeskMeetingDuration = GameObject.Find("Radial Gradient_TotDeskMeetingsDuration").GetComponent<RadialSlider>();

            _environmentConversations_TotalNumSameType = GameObject.Find("Slider Gradient_TotNumConvosSameType").GetComponent<Slider>();
            _environmentConversations_TotalNumDiffType = GameObject.Find("Slider Gradient_TotNumConvosOtherType").GetComponent<Slider>();
            



            _envAction1Time = GameObject.Find("Action1_Text").GetComponent<Text>();
            _envAction2Time = GameObject.Find("Action2_Text").GetComponent<Text>();
            _envAction3Time = GameObject.Find("Action3_Text").GetComponent<Text>();
            _envAction4Time = GameObject.Find("Action4_Text").GetComponent<Text>();
            _envAction5Time = GameObject.Find("Action5_Text").GetComponent<Text>();
            _envAction6Time = GameObject.Find("Action6_Text").GetComponent<Text>();
            _envAction7Time = GameObject.Find("Action7_Text").GetComponent<Text>();
            _envAction8Time = GameObject.Find("Action8_Text").GetComponent<Text>();
            _envAction9Time = GameObject.Find("Action9_Text").GetComponent<Text>();
            _envAction10Time = GameObject.Find("Action10_Text").GetComponent<Text>();

            _envAction1Perc = GameObject.Find("Action1%_Text").GetComponent<Text>();
            _envAction2Perc = GameObject.Find("Action2%_Text").GetComponent<Text>();
            _envAction3Perc = GameObject.Find("Action3%_Text").GetComponent<Text>();
            _envAction4Perc = GameObject.Find("Action4%_Text").GetComponent<Text>();
            _envAction5Perc = GameObject.Find("Action5%_Text").GetComponent<Text>();
            _envAction6Perc = GameObject.Find("Action6%_Text").GetComponent<Text>();
            _envAction7Perc = GameObject.Find("Action7%_Text").GetComponent<Text>();
            _envAction8Perc = GameObject.Find("Action8%_Text").GetComponent<Text>();
            _envAction9Perc = GameObject.Find("Action9%_Text").GetComponent<Text>();
            _envAction10Perc = GameObject.Find("Action10%_Text").GetComponent<Text>();

            _agCurrentAction = GameObject.Find("CurrentAction_Text").GetComponent<Text>();
            _agCurrentSubAction = GameObject.Find("CurrentSubAction_Text").GetComponent<Text>();

            _agAction1Time = GameObject.Find("AgentAction1_Text").GetComponent<Text>();
            _agAction2Time = GameObject.Find("AgentAction2_Text").GetComponent<Text>();
            _agAction3Time = GameObject.Find("AgentAction3_Text").GetComponent<Text>();
            _agAction4Time = GameObject.Find("AgentAction4_Text").GetComponent<Text>();
            _agAction5Time = GameObject.Find("AgentAction5_Text").GetComponent<Text>();
            _agAction6Time = GameObject.Find("AgentAction6_Text").GetComponent<Text>();
            _agAction7Time = GameObject.Find("AgentAction7_Text").GetComponent<Text>();
            _agAction8Time = GameObject.Find("AgentAction8_Text").GetComponent<Text>();
            _agAction9Time = GameObject.Find("AgentAction9_Text").GetComponent<Text>();
            _agAction10Time = GameObject.Find("AgentAction10_Text").GetComponent<Text>();

            _agAction1Perc = GameObject.Find("AgentAction1%_Text").GetComponent<Text>();
            _agAction2Perc = GameObject.Find("AgentAction2%_Text").GetComponent<Text>();
            _agAction3Perc = GameObject.Find("AgentAction3%_Text").GetComponent<Text>();
            _agAction4Perc = GameObject.Find("AgentAction4%_Text").GetComponent<Text>();
            _agAction5Perc = GameObject.Find("AgentAction5%_Text").GetComponent<Text>();
            _agAction6Perc = GameObject.Find("AgentAction6%_Text").GetComponent<Text>();
            _agAction7Perc = GameObject.Find("AgentAction7%_Text").GetComponent<Text>();
            _agAction8Perc = GameObject.Find("AgentAction8%_Text").GetComponent<Text>();
            _agAction9Perc = GameObject.Find("AgentAction9%_Text").GetComponent<Text>();
            _agAction10Perc = GameObject.Find("AgentAction10%_Text").GetComponent<Text>();

            _agcount = GameObject.Find("AgentQuantity_Text").GetComponent<Text>();
            _agtypecount = GameObject.Find("AgentTypesQuantity_Text").GetComponent<Text>();
            _agtype1 = GameObject.Find("AgentTypesPerc1_Text").GetComponent<Text>();
            _agtype2 = GameObject.Find("AgentTypesPerc2_Text").GetComponent<Text>();
            _teamcount = GameObject.Find("AgentTeams_Text").GetComponent<Text>();
            _depcount = GameObject.Find("AgentDeps_Text").GetComponent<Text>();

            _destcount = GameObject.Find("DestQuantity_Text").GetComponent<Text>();
            _destprivatecount = GameObject.Find("DestPrivateQuantity_Text").GetComponent<Text>();
            _destpubliccount = GameObject.Find("DestPublicQuantity_Text").GetComponent<Text>();
            _destleastoccupied = GameObject.Find("DestLeastOccupied_Text").GetComponent<Text>();
            _destleastoccupiedtime = GameObject.Find("DestLeastOccupiedTime_Text").GetComponent<Text>();
            _destmostoccupied = GameObject.Find("DestMostOccupied_Text").GetComponent<Text>();
            _destmostoccupiedtime = GameObject.Find("DestMostOccupiedTime_Text").GetComponent<Text>();

            _convocount = GameObject.Find("ConvoQuantity_Text").GetComponent<Text>();
            _currentconvocount = GameObject.Find("CurrentConvoQuantity_Text").GetComponent<Text>();
            _convotime = GameObject.Find("TotalConvoTime_Text").GetComponent<Text>();
            _avgconvotime = GameObject.Find("AvgConvoTimeAgent_Text").GetComponent<Text>();

            //OUTPUT STUFFF/////////////////////////////////////////////////////////////////////////////////


            if (GameObject.Find("AGENTCOUNT_TEXT"))
            {
                _agentcount = GameObject.Find("AGENTCOUNT_TEXT").GetComponent<Text>();
            }

            if (GameObject.Find("Zones"))
            {
                _zonesobj = GameObject.Find("Zones");
            }



            // For Display Panel 
            // Grab Toggle in the scene
            _toggledepartment = GameObject.Find("Toggle_Department").GetComponent<Toggle>();
            _toggleteam = GameObject.Find("Toggle_Team").GetComponent<Toggle>();
            _togglerank = GameObject.Find("Toggle_Rank").GetComponent<Toggle>();
            _toggleaction = GameObject.Find("Toggle_Action").GetComponent<Toggle>();
            _toggleselected = GameObject.Find("Toggle_Selected").GetComponent<Toggle>();


            _togglesocial = GameObject.Find("Toggle_SocialSlider").GetComponent<Toggle>();
            _toggleenergy = GameObject.Find("Toggle_EnergySlider").GetComponent<Toggle>();
            _togglemotivation = GameObject.Find("Toggle_MotivationSlider").GetComponent<Toggle>();
            _toggleshowallsliders = GameObject.Find("Toggle_ShowAllSlider").GetComponent<Toggle>();

            _toggledatapoints = GameObject.Find("Toggle_DataPoints").GetComponent<Toggle>();
            _toggledatapointsaction = GameObject.Find("Toggle_DataPointsAction").GetComponent<Toggle>();
            _toggledatapointstime = GameObject.Find("Toggle_DataPointsTime").GetComponent<Toggle>();
            _toggleactioncount = GameObject.Find("Toggle_ActionCount").GetComponent<Toggle>();

            _togglevisibleobject = GameObject.Find("Toggle_VisibleObjects").GetComponent<Toggle>();
            _togglevisibleneighbour = GameObject.Find("Toggle_VisibleNeighbours").GetComponent<Toggle>();
            _togglefriends = GameObject.Find("Toggle_Friends").GetComponent<Toggle>();
            _toggledisplayconvos = GameObject.Find("Toggle_DisplayConversations").GetComponent<Toggle>();



            _togglesimplemodel = GameObject.Find("Toggle_SimpleAgentDisplay").GetComponent<Toggle>();
            _toggleriggedmodel = GameObject.Find("Toggle_RiggedAgentDisplay").GetComponent<Toggle>();
            _togglesimplemodel.onValueChanged.AddListener(delegate { UpdateAgentDisplay(); }); //check efficiency!!!!!
            _toggleriggedmodel.onValueChanged.AddListener(delegate { UpdateAgentDisplay(); }); //check efficiency!!!!!

            _toggleagentcam = GameObject.Find("Toggle_AgentCam").GetComponent<Toggle>();
            _toggleagentcam.onValueChanged.AddListener(delegate { ToggleCameraDisplay(); }); //check efficiency!!!!!


            _sliderDecay = GameObject.Find("DecaySlider").GetComponent<Slider>();
            _decaytext = GameObject.Find("DecayText02").GetComponent<Text>();

            // For Setup Panel
            _occupancyslider = GameObject.Find("OccupancySlider").GetComponent<Slider>();
            _contextObj.GetComponent<Context>().Occupancy = (float)(_occupancyslider.value / 100);
            //occupancy = (float)(_occupancyslider.value / 100);
            _occupancypercentage = GameObject.Find("OccupancyText").GetComponent<Text>();
            //_occupancypercentage.text = _occupancyslider.value.ToString();
            _occupancypercentage.text = Convert.ToString(_occupancyslider.value);
            //_maxnumberagent = GameObject.Find("MaxAgentsInputField").GetComponent<InputField>();
            _numberagentrank = GameObject.Find("AgentRankInputField").GetComponent<InputField>();

            ////SPAWN STUFF
            _togglespawntypehome = GameObject.Find("Toggle_Home").GetComponent<Toggle>();
            _togglespawntypespawnsource = GameObject.Find("Toggle_SpawnSource").GetComponent<Toggle>();
            _togglespawntypeboth = GameObject.Find("Toggle_Both").GetComponent<Toggle>();
            _spawnrate = GameObject.Find("SpawnRateSlider").GetComponent<Slider>();
            _spawnsourceperc = GameObject.Find("SpawnSourcePercSlider").GetComponent<Slider>();
            _spawnratetext = GameObject.Find("SpawnRate#Text").GetComponent<Text>();
            _spawnsourceperctext = GameObject.Find("SpawnSourcePerc#Text").GetComponent<Text>();

            //set default to spawnsources
            _togglespawntypespawnsource.isOn = true;

            _numberofdepartment = GameObject.Find("AgentDepartmentInputField").GetComponent<InputField>();
            _numberofteam = GameObject.Find("AgentTeamInputField").GetComponent<InputField>();

            _overallsocialslider = GameObject.Find("OverallSocialSlider").GetComponent<Slider>();
            _overallsocialvaluetext = GameObject.Find("OverallSociaPercText").GetComponent<Text>();
            _overallmotivationslider = GameObject.Find("OverallMotivationSlider").GetComponent<Slider>();
            _overallmotivationvaluetext = GameObject.Find("OverallMotivationPercText").GetComponent<Text>();
            _overallrangeslider = GameObject.Find("OverallRangeSlider").GetComponent<Slider>();
            _overallrangevaluetext = GameObject.Find("OverallRange%Text").GetComponent<Text>();

            //_timespeedslider = GameObject.Find("TimeSpeedSlider").GetComponent<Slider>();
            //_overallrangeslider.onValueChanged.AddListener(delegate { TimeSpeed(); }); //check efficiency!!!!!

            _overallsocialslider.onValueChanged.AddListener(delegate { ChangeGlobalSocial(); }); //check efficiency!!!!!
            _overallmotivationslider.onValueChanged.AddListener(delegate { ChangeGlobalMotivation(); }); //check efficiency!!!!!
            _overallrangeslider.onValueChanged.AddListener(delegate { ChangeGlobalRange(); }); //check efficiency!!!!!

            _toggleagentinfluence = GameObject.Find("Toggle_AgentInfluenceMap").GetComponent<Toggle>();
            _togglezones = GameObject.Find("Toggle_Zones").GetComponent<Toggle>();
            _toggledefault = GameObject.Find("Toggle_Default").GetComponent<Toggle>();
            //Debug.Log(_toggledefault);
            _togglehistory = GameObject.Find("Toggle_HistoryMap").GetComponent<Toggle>();

            _togglehistorymappanel = GameObject.Find("Main_Toggle_HistoryMap").GetComponent<Toggle>();
            _panelhistorymap = GameObject.Find("Panel_Toggle_HistoryMap");
            _panelmapsettings = GameObject.Find("Panel_MapSettings");

            _togglegriddisplay = GameObject.Find("ToggleGridDisplay").GetComponent<Toggle>();
            _slidergridheight = GameObject.Find("GridHeightSlider").GetComponent<Slider>();
            _gridheighttext = GameObject.Find("GridHeightText02").GetComponent<Text>();


            _togglehistoryall = GameObject.Find("ToggleHistory_All").GetComponent<Toggle>();
            _togglehistorystanding = GameObject.Find("ToggleHistory_Standing").GetComponent<Toggle>();
            _togglehistorywalking = GameObject.Find("ToggleHistory_Walking").GetComponent<Toggle>();
            _togglehistoryconversation = GameObject.Find("ToggleHistory_Conversation").GetComponent<Toggle>();
            _togglehistorysitting = GameObject.Find("ToggleHistory_Sitting").GetComponent<Toggle>();
            _togglehistorymeeting = GameObject.Find("ToggleHistory_Meeting").GetComponent<Toggle>();
        }

        #endregion

        #region Private Methods
        // Update is called once per frame
        private void Update()
        {
            if (_contextObj.GetComponent<Context>().IsStarted == true && _environment.IsSetup == true)
            {
                DisplayAgentColor();

                DisplaySliders();

                DisplayActionCount();
                DisplayVisibleObject();
                DisplayVisibleNeighbour();
                DisplayFriends();
                DisplayConversations();

                DisplayData();

                _occupancypercentage.text = _occupancyslider.value.ToString();
                _overallrangevaluetext.text = Convert.ToString(_overallrangeslider.value);
                _overallsocialvaluetext.text = Convert.ToString(_overallsocialslider.value);
                InfluenceMapToggle(_toggleagentinfluence, _togglezones, _togglehistory, _toggledefault);
                ChangeHistoryDisplay();
                ChangeDecayValue();
                GridDisplayToggle();
                ChangeDisplayGridHeight();
                AddAgents();

                //OUTPUT STUFFF/////////////////////////////////////////////////////////////////////////////////
                UpdateActionPercentages();
                UpdateConversationData();

                UpdateActionData();
                UpdateAgentData();
                UpdateDestData();
                UpdateConvoData();

                //OUTPUT STUFFF/////////////////////////////////////////////////////////////////////////////////
            }

            //OpenHistoryMapDisplayPanel();
            UpdateInputField();

            if (_agentcount != null)
            {
                _agentcount.text = _environmentdata.AgentQuantity.ToString();
            }

        }


        //OUTPUT STUFFF/////////////////////////////////////////////////////////////////////////////////

        private void UpdateActionData()
        {
            if (_environmentdata != null)
            {
                int min;
                int sec;

                if (_environment.Agents.Count > 0)
                {
                    _agCurrentAction.text = _environment.Agents[0].CurrentAction.Name;
                    _agCurrentSubAction.text = _environment.Agents[0].CurrentAction.SubActions[_environment.Agents[0].CurrentAction.CurrentSubActionIndex].Type.ToString();

                }

                if (_environmentdata.ActionTimes.Count >= Enum.GetNames(typeof(ACTION_TYPE)).Length)
                {

                    ConvertMinSec(Mathf.RoundToInt(_environmentdata.ActionTimes[1]), out min, out sec);
                    _envAction1Time.text = min.ToString() + "m " + sec.ToString() + "s";

                    ConvertMinSec(Mathf.RoundToInt(_environmentdata.ActionTimes[2]), out min, out sec);
                    _envAction2Time.text = min.ToString() + "m " + sec.ToString() + "s";

                    ConvertMinSec(Mathf.RoundToInt(_environmentdata.ActionTimes[3]), out min, out sec);
                    _envAction3Time.text = min.ToString() + "m " + sec.ToString() + "s";

                    ConvertMinSec(Mathf.RoundToInt(_environmentdata.ActionTimes[4]), out min, out sec);
                    _envAction4Time.text = min.ToString() + "m " + sec.ToString() + "s";

                    ConvertMinSec(Mathf.RoundToInt(_environmentdata.ActionTimes[5]), out min, out sec);
                    _envAction5Time.text = min.ToString() + "m " + sec.ToString() + "s";

                    ConvertMinSec(Mathf.RoundToInt(_environmentdata.ActionTimes[6]), out min, out sec);
                    _envAction6Time.text = min.ToString() + "m " + sec.ToString() + "s";

                    ConvertMinSec(Mathf.RoundToInt(_environmentdata.ActionTimes[7]), out min, out sec);
                    _envAction7Time.text = min.ToString() + "m " + sec.ToString() + "s";

                    ConvertMinSec(Mathf.RoundToInt(_environmentdata.ActionTimes[8]), out min, out sec);
                    _envAction8Time.text = min.ToString() + "m " + sec.ToString() + "s";

                    ConvertMinSec(Mathf.RoundToInt(_environmentdata.ActionTimes[9]), out min, out sec);
                    _envAction9Time.text = min.ToString() + "m " + sec.ToString() + "s";

                    ConvertMinSec(Mathf.RoundToInt(_environmentdata.ActionTimes[10]), out min, out sec);
                    _envAction10Time.text = min.ToString() + "m " + sec.ToString() + "s";

                }

                if (_environmentdata.ActionPercentages.Count >= Enum.GetNames(typeof(ACTION_TYPE)).Length)
                {
                    _envAction1Perc.text = Mathf.RoundToInt(_environmentdata.ActionPercentages[1] * 100).ToString() + "%";
                    _envAction2Perc.text = Mathf.RoundToInt(_environmentdata.ActionPercentages[2] * 100).ToString() + "%";
                    _envAction3Perc.text = Mathf.RoundToInt(_environmentdata.ActionPercentages[3] * 100).ToString() + "%";
                    _envAction4Perc.text = Mathf.RoundToInt(_environmentdata.ActionPercentages[4] * 100).ToString() + "%";
                    _envAction5Perc.text = Mathf.RoundToInt(_environmentdata.ActionPercentages[5] * 100).ToString() + "%";
                    _envAction6Perc.text = Mathf.RoundToInt(_environmentdata.ActionPercentages[6] * 100).ToString() + "%";
                    _envAction7Perc.text = Mathf.RoundToInt(_environmentdata.ActionPercentages[7] * 100).ToString() + "%";
                    _envAction8Perc.text = Mathf.RoundToInt(_environmentdata.ActionPercentages[8] * 100).ToString() + "%";
                    _envAction9Perc.text = Mathf.RoundToInt(_environmentdata.ActionPercentages[9] * 100).ToString() + "%";
                    _envAction10Perc.text = Mathf.RoundToInt(_environmentdata.ActionPercentages[10] * 100).ToString() + "%";
                }

                if (_environmentdata.Agent0ActionTimes.Count >= Enum.GetNames(typeof(ACTION_TYPE)).Length)
                {

                    ConvertMinSec(Mathf.RoundToInt(_environmentdata.Agent0ActionTimes[1]), out min, out sec);
                    _agAction1Time.text = min.ToString() + "m " + sec.ToString() + "s";

                    ConvertMinSec(Mathf.RoundToInt(_environmentdata.Agent0ActionTimes[2]), out min, out sec);
                    _agAction2Time.text = min.ToString() + "m " + sec.ToString() + "s";

                    ConvertMinSec(Mathf.RoundToInt(_environmentdata.Agent0ActionTimes[3]), out min, out sec);
                    _agAction3Time.text = min.ToString() + "m " + sec.ToString() + "s";

                    ConvertMinSec(Mathf.RoundToInt(_environmentdata.Agent0ActionTimes[4]), out min, out sec);
                    _agAction4Time.text = min.ToString() + "m " + sec.ToString() + "s";

                    ConvertMinSec(Mathf.RoundToInt(_environmentdata.Agent0ActionTimes[5]), out min, out sec);
                    _agAction5Time.text = min.ToString() + "m " + sec.ToString() + "s";

                    ConvertMinSec(Mathf.RoundToInt(_environmentdata.Agent0ActionTimes[6]), out min, out sec);
                    _agAction6Time.text = min.ToString() + "m " + sec.ToString() + "s";

                    ConvertMinSec(Mathf.RoundToInt(_environmentdata.Agent0ActionTimes[7]), out min, out sec);
                    _agAction7Time.text = min.ToString() + "m " + sec.ToString() + "s";

                    ConvertMinSec(Mathf.RoundToInt(_environmentdata.Agent0ActionTimes[8]), out min, out sec);
                    _agAction8Time.text = min.ToString() + "m " + sec.ToString() + "s";

                    ConvertMinSec(Mathf.RoundToInt(_environmentdata.Agent0ActionTimes[9]), out min, out sec);
                    _agAction9Time.text = min.ToString() + "m " + sec.ToString() + "s";

                    ConvertMinSec(Mathf.RoundToInt(_environmentdata.Agent0ActionTimes[10]), out min, out sec);
                    _agAction10Time.text = min.ToString() + "m " + sec.ToString() + "s";
                }


                if (_environmentdata.Agent0ActionPercentages.Count >= Enum.GetNames(typeof(ACTION_TYPE)).Length)
                {
                    _agAction1Perc.text = Mathf.RoundToInt(_environmentdata.Agent0ActionPercentages[1] * 100).ToString() + "%";
                    _agAction2Perc.text = Mathf.RoundToInt(_environmentdata.Agent0ActionPercentages[2] * 100).ToString() + "%";
                    _agAction3Perc.text = Mathf.RoundToInt(_environmentdata.Agent0ActionPercentages[3] * 100).ToString() + "%";
                    _agAction4Perc.text = Mathf.RoundToInt(_environmentdata.Agent0ActionPercentages[4] * 100).ToString() + "%";
                    _agAction5Perc.text = Mathf.RoundToInt(_environmentdata.Agent0ActionPercentages[5] * 100).ToString() + "%";
                    _agAction6Perc.text = Mathf.RoundToInt(_environmentdata.Agent0ActionPercentages[6] * 100).ToString() + "%";
                    _agAction7Perc.text = Mathf.RoundToInt(_environmentdata.Agent0ActionPercentages[7] * 100).ToString() + "%";
                    _agAction8Perc.text = Mathf.RoundToInt(_environmentdata.Agent0ActionPercentages[8] * 100).ToString() + "%";
                    _agAction9Perc.text = Mathf.RoundToInt(_environmentdata.Agent0ActionPercentages[9] * 100).ToString() + "%";
                    _agAction10Perc.text = Mathf.RoundToInt(_environmentdata.Agent0ActionPercentages[10] * 100).ToString() + "%";
                }

            }
        }

        private void UpdateConvoData()
        {
            if (_environmentdata != null)
            {
                int min;
                int sec;

                _convocount.text = Mathf.RoundToInt(_environmentdata.ConversationsQuantity).ToString();
                _currentconvocount.text = Mathf.RoundToInt(_environmentdata.CurrentConversationsQuantity).ToString();

                ConvertMinSec(Mathf.RoundToInt(_environmentdata.TotalConversationTime), out min, out sec);
                _convotime.text = min.ToString() + "m " + sec.ToString() + "s";

                ConvertMinSec(Mathf.RoundToInt(_environmentdata.AvgAgentConversationTime), out min, out sec);
                _avgconvotime.text = min.ToString() + "m " + sec.ToString() + "s";
            }
        }

        private void UpdateDestData()
        {
            if (_environmentdata != null)
            {
                int min;
                int sec;

                _destcount.text = _environmentdata.DestinationsQuantity.ToString();
                _destprivatecount.text = _environmentdata.PrivateDesksQuantity.ToString();
                _destpubliccount.text = _environmentdata.PublicDestinationsQuantity.ToString();
                _destleastoccupied.text = _environmentdata.LeastOccupiedDestination.Name;

                ConvertMinSec(Mathf.RoundToInt(_environmentdata.LeastOccupiedDestination.UnoccupiedTime), out min, out sec);
                _destleastoccupiedtime.text = min.ToString() + "m " + sec.ToString() + "s";
                _destmostoccupied.text = _environmentdata.MostOccupiedDestination.Name;

                ConvertMinSec(Mathf.RoundToInt(_environmentdata.MostOccupiedDestination.UnoccupiedTime), out min, out sec);
                _destmostoccupiedtime.text = min.ToString() + "m " + sec.ToString() + "s";
            }
        }

        private void UpdateAgentData()
        {
            if (_environmentdata != null)
            {
                int min;
                int sec;

                _agcount.text = _environmentdata.AgentQuantity.ToString();
                _agtypecount.text = _environmentdata.AgentTypesQuantity.ToString();
                if (_environmentdata.AgentTypesPercentages.Count > 0) //fixme
                {
                    _agtype1.text = _environmentdata.AgentTypesPercentages[0].ToString();
                    _agtype2.text = _environmentdata.AgentTypesPercentages[1].ToString();
                }

                _teamcount.text = _environmentdata.TeamQuantity.ToString();
                _depcount.text = _environmentdata.DepartmentQuantity.ToString();
            }
        }
        private void UpdateActionPercentages()
        {
            if (_environmentdata != null)
            {
                if (_environmentdata.ActionPercentages.Count >= Enum.GetNames(typeof(ACTION_TYPE)).Length)
                {
                    _environmentActionsPerc_Idle.currentPercent = _environmentdata.ActionPercentages[1] * 100;
                    _environmentActionsPerc_Walking.currentPercent = _environmentdata.ActionPercentages[2] * 100;
                    _environmentActionsPerc_Conversation.currentPercent = _environmentdata.ActionPercentages[3] * 100;
                    _environmentActionsPerc_WorkingAlone.currentPercent = _environmentdata.ActionPercentages[4] * 100;
                    _environmentActionsPerc_ScheduledMeeting.currentPercent = _environmentdata.ActionPercentages[5] * 100;
                    _environmentActionsPerc_WorkingCollab.currentPercent = _environmentdata.ActionPercentages[6] * 100;
                    _environmentActionsPerc_EatDrink.currentPercent = _environmentdata.ActionPercentages[7] * 100;
                    _environmentActionsPerc_WC.currentPercent = _environmentdata.ActionPercentages[8] * 100;
                    _environmentActionsPerc_ExtBreak.currentPercent = _environmentdata.ActionPercentages[9] * 100;
                }
            }
        }


        private void UpdateConversationData()
        {
            if (_environmentdata != null)
            {
                _environmentConversations_TotalNum.value = _environmentdata.ConversationsQuantity;
            }
        }


        //OUTPUT STUFFF/////////////////////////////////////////////////////////////////////////////////

        private void TimeSpeed()
        {

        }


        private void InfluenceMapToggle(Toggle toggleAgentInfluence, Toggle toggleZones, Toggle toggleHistory, Toggle toggleDefault)
        {
            if (toggleAgentInfluence.isOn == true)
            {
                _zonesobj.SetActive(false);

                _environment.CurrentOccupancyMapController.gameObject.SetActive(true);
                _environment.CurrentOccupancyMapController.Update();
                _environment.ZonesMapController.gameObject.SetActive(false);
                _environment.HistoryMapController.gameObject.SetActive(false);

            }

            if (toggleZones.isOn == true)
            {
                _zonesobj.SetActive(false);

                _environment.CurrentOccupancyMapController.gameObject.SetActive(false);
                _environment.ZonesMapController.gameObject.SetActive(true);
                _environment.HistoryMapController.gameObject.SetActive(false);

            }

            if (toggleHistory.isOn == true)
            {
                _zonesobj.SetActive(false);

                _environment.CurrentOccupancyMapController.gameObject.SetActive(false);
                _environment.ZonesMapController.gameObject.SetActive(false);
                _environment.HistoryMapController.gameObject.SetActive(true);
                _environment.HistoryMapController.Update();


            }

            if (toggleDefault.isOn == true)
            {
                _zonesobj.SetActive(true);

                _environment.CurrentOccupancyMapController.gameObject.SetActive(false);
                _environment.ZonesMapController.gameObject.SetActive(false);
                _environment.HistoryMapController.gameObject.SetActive(false);
            }



        }

        private void SpawnTypeToggle()
        {
            if (_togglespawntypehome.isOn == true)
            {
                _context.SpawnType = SPAWNTYPE.HomeDesk;
            }

            if (_togglespawntypespawnsource.isOn == true)
            {
                _context.SpawnType = SPAWNTYPE.SpawnSources;
            }

            if (_togglespawntypeboth.isOn == true)
            {
                _context.SpawnType = SPAWNTYPE.Both;
            }
        }

        private void GridDisplayToggle()
        {
            if (_occupancymapdisplay == null)
            {
                _occupancymapdisplay = (InfluenceMapDisplay)_environment.CurrentOccupancyMapController.Display;
            }

            if (_historymapdisplay == null)
            {
                _historymapdisplay = (HistoryMapDisplay)_environment.HistoryMapController.Display;
            }

            if (_togglegriddisplay.isOn == true && _toggleagentinfluence.isOn == true)
            {
                _occupancymapdisplay.NodesGrid.SetActive(true);
                _historymapdisplay.NodesGrid.SetActive(false);
            }

            if (_togglegriddisplay.isOn == true && _togglehistory.isOn == true)
            {
                _occupancymapdisplay.NodesGrid.SetActive(false);
                _historymapdisplay.NodesGrid.SetActive(true);
            }

            if (_togglegriddisplay.isOn == false || _togglehistory.isOn == false)
            {
                if (_historymapdisplay.NodesGrid.activeInHierarchy == true)
                {
                    _historymapdisplay.NodesGrid.SetActive(false);
                }
            }

            if (_togglegriddisplay.isOn == false || _toggleagentinfluence.isOn == false)
            {
                if (_occupancymapdisplay.NodesGrid.activeInHierarchy == true)
                {
                    _occupancymapdisplay.NodesGrid.SetActive(false);
                }
            }

        }

        private void DisplayAgentColor()
        {
            //loop through list of agents
            foreach (IAgent agent in _environment.Agents)
            {
                //pull out each agent 
                Agent tempagent = (Agent)agent;

                //check which toggles have been pressed and change the variables inside each agent accordingly
                if (_toggleselected.isOn == true && tempagent.AgentId == 0)
                {
                    tempagent.ColorSelected = true;
                    for (int i = 0; i < tempagent.SkinnedMeshRenderers.Count; i++)
                    {
                        SkinnedMeshRenderer renderer = tempagent.SkinnedMeshRenderers[i];
                        renderer.sharedMaterial = tempagent.Materials[6];
                    }

                    continue;
                }

                if (_toggleselected.isOn == false && tempagent.AgentId == 0)
                {
                    tempagent.ColorSelected = false;
                }


                if (_toggledepartment.isOn == true)
                {
                    tempagent.ColorByDepartment = true;
                    tempagent.ColorByTeam = false;
                    tempagent.ColorByRank = false;
                    tempagent.ColorByAction = false;

                    for (int i = 0; i < tempagent.SkinnedMeshRenderers.Count; i++)
                    {
                        SkinnedMeshRenderer renderer = tempagent.SkinnedMeshRenderers[i];
                        renderer.sharedMaterial = tempagent.Materials[6];
                    }
                }

                if (_toggleteam.isOn == true)
                {
                    tempagent.ColorByTeam = true;
                    tempagent.ColorByDepartment = false;
                    tempagent.ColorByRank = false;
                    tempagent.ColorByAction = false;

                    for (int i = 0; i < tempagent.SkinnedMeshRenderers.Count; i++)
                    {
                        SkinnedMeshRenderer renderer = tempagent.SkinnedMeshRenderers[i];
                        renderer.sharedMaterial = tempagent.Materials[6];
                    }
                }

                if (_togglerank.isOn == true)
                {
                    tempagent.ColorByTeam = false;
                    tempagent.ColorByDepartment = false;
                    tempagent.ColorByRank = true;
                    tempagent.ColorByAction = false;

                    for (int i = 0; i < tempagent.SkinnedMeshRenderers.Count; i++)
                    {
                        SkinnedMeshRenderer renderer = tempagent.SkinnedMeshRenderers[i];
                        renderer.sharedMaterial = tempagent.Materials[6];
                    }
                }

                if (_toggleaction.isOn == true)
                {
                    tempagent.ColorByTeam = false;
                    tempagent.ColorByDepartment = false;
                    tempagent.ColorByRank = false;
                    tempagent.ColorByAction = true;


                    for (int i = 0; i < tempagent.SkinnedMeshRenderers.Count; i++)
                    {
                        SkinnedMeshRenderer renderer = tempagent.SkinnedMeshRenderers[i];
                        renderer.sharedMaterial = tempagent.Materials[6];
                    }
                }

                if (_toggledepartment.isOn == false && _toggleteam.isOn == false && _togglerank.isOn == false && _toggleaction.isOn == false)
                {
                    tempagent.ColorByRank = false;
                    tempagent.ColorByDepartment = false;
                    tempagent.ColorByTeam = false;
                    tempagent.ColorByAction = false;

                    for (int i = 0; i < tempagent.SkinnedMeshRenderers.Count; i++)
                    {
                        SkinnedMeshRenderer renderer = tempagent.SkinnedMeshRenderers[i];
                        renderer.sharedMaterial = tempagent.Materials[i];
                        tempagent.MatPropBlock.Clear();
                        renderer.SetPropertyBlock(tempagent.MatPropBlock);
                        MeshRenderer simplemeshrenderer = tempagent.SimpleMeshRenderer;
                        MaterialPropertyBlock props = new MaterialPropertyBlock();
                        props.SetColor("_Color", Color.black);
                        simplemeshrenderer.SetPropertyBlock(props);
                    }
                }
            }


        }

        private void UpdateAgentDisplay()
        {
            if (_togglesimplemodel.isOn == true)
            {
                _environment.AgentDisplayMode = AGENTDISPLAYMODE.Simple;
            }

            if (_toggleriggedmodel.isOn == true)
            {
                _environment.AgentDisplayMode = AGENTDISPLAYMODE.Rigged;
            }

        }

        private void ToggleCameraDisplay()
        {
            _environment.ToggleCamera();
        }

        private void DisplaySliders()
        {
            foreach (IAgent agent in _environment.Agents)
            {
                Agent tempagent = (Agent)agent;

                if (_togglesocial != null)
                {
                    if (_togglesocial.isOn == true)
                    {

                        tempagent.ViewUI = true;
                        tempagent.UIObj.SetActive(true);
                        tempagent.GetComponent<Agent>().SocialBar.gameObject.SetActive(true);
                        tempagent.GetComponent<Agent>().SocialText.gameObject.SetActive(true);


                    }

                    if (_togglesocial.isOn == false)
                    {
                        tempagent.GetComponent<Agent>().SocialBar.gameObject.SetActive(false);
                        tempagent.GetComponent<Agent>().SocialText.gameObject.SetActive(false);
                    }
                }

                if (_togglesocial == null)
                {
                    Debug.Log(" There is no toggle social slider");
                }

                if (_togglemotivation != null)
                {
                    if (_togglemotivation.isOn == true)
                    {
                        tempagent.ViewUI = true;
                        tempagent.UIObj.SetActive(true);
                        tempagent.MotivationBar.gameObject.SetActive(true);
                        tempagent.MotivationText.gameObject.SetActive(true);
                    }

                    if (_togglemotivation.isOn == false)
                    {
                        tempagent.MotivationBar.gameObject.SetActive(false);
                        tempagent.MotivationText.gameObject.SetActive(false);
                    }
                }

                if (_togglemotivation == null)
                {
                    Debug.Log(" There is no toggle Movivation Slider");
                }

                if (_toggleenergy != null)
                {
                    if (_toggleenergy.isOn == true)
                    {
                        tempagent.ViewUI = true;
                        tempagent.UIObj.SetActive(true);
                        tempagent.EnergyBar.gameObject.SetActive(true);
                        tempagent.EnergyText.gameObject.SetActive(true);

                    }

                    if (_toggleenergy.isOn == false)
                    {
                        tempagent.EnergyBar.gameObject.SetActive(false);
                        tempagent.EnergyText.gameObject.SetActive(false);
                    }
                }

                if (_toggleenergy == null)
                {
                    Debug.Log(" There is no toggle Energy ");
                }

                if (_toggleshowallsliders != null)
                {
                    if (_toggleshowallsliders.isOn == true)
                    {
                        tempagent.ViewUI = true;
                        tempagent.UIObj.SetActive(true);

                        tempagent.GetComponent<Agent>().SocialBar.gameObject.SetActive(true);
                        tempagent.GetComponent<Agent>().SocialText.gameObject.SetActive(true);

                        tempagent.MotivationBar.gameObject.SetActive(true);
                        tempagent.MotivationText.gameObject.SetActive(true);

                        tempagent.EnergyBar.gameObject.SetActive(true);
                        tempagent.EnergyText.gameObject.SetActive(true);


                    }
                }

                if (_toggleshowallsliders == null)
                {
                    Debug.Log(" There is no toggle All Slider ");
                }
            }
        }

        private void DisplayData()
        {
            foreach (IAgent agent in _environment.Agents)
            {
                //pull out each agent 
                Agent tempagent = (Agent)agent;

                if (_toggledatapoints.isOn == true)
                {
                    _environment.CurrentCamera.gameObject.GetComponent<LineDraw>().DataPointDisplayMode = DATAPOINTDISPLAYMODE.Color;

                }

                if (_toggledatapointstime.isOn == true)
                {
                    _environment.CurrentCamera.gameObject.GetComponent<LineDraw>().DataPointDisplayMode = DATAPOINTDISPLAYMODE.Time;
                }

                if (_toggledatapointsaction.isOn == true)
                {
                    _environment.CurrentCamera.gameObject.GetComponent<LineDraw>().DataPointDisplayMode = DATAPOINTDISPLAYMODE.Action;
                }

                if (_toggledatapoints.isOn == false && _toggledatapointstime.isOn == false && _toggledatapointsaction.isOn == false)
                {
                    _environment.CurrentCamera.gameObject.GetComponent<LineDraw>().DataPointDisplayMode = DATAPOINTDISPLAYMODE.None;
                }
            }
        }

        private void DisplayDataOld()
        {
            foreach (IAgent agent in _environment.Agents)
            {
                //pull out each agent 
                Agent tempagent = (Agent)agent;

                if (_toggledatapoints.isOn == true)
                {
                    tempagent.DataPointVizMode = 0;
                }
                if (_toggledatapointstime.isOn == true)
                {
                    tempagent.DataPointVizMode = 1;
                }
                if (_toggledatapointsaction.isOn == true)
                {
                    tempagent.DataPointVizMode = 2;
                }
                if (_toggledatapoints.isOn == false && _toggledatapointstime.isOn == false && _toggledatapointsaction.isOn == false)
                {
                    tempagent.DataPointVizMode = 3;

                }
            }
        }

        private void DisplayActionCount()
        {
            foreach (IAgent agent in _environment.Agents)
            {
                //pull out each agent 
                Agent tempagent = (Agent)agent;

                if (_toggleactioncount.isOn == true)
                {
                    tempagent.UIActionsObj.SetActive(true);
                }

                if (_toggleactioncount.isOn == false)
                {
                    tempagent.UIActionsObj.SetActive(false);
                }
            }
        }

        private void DisplayVisibleObject()
        {
            foreach (IAgent agent in _environment.Agents)
            {
                //pull out each agent 
                Agent tempagent = (Agent)agent;

                if (_togglevisibleobject.isOn == true)
                {
                    tempagent.ViewVisibleDestinations = true;
                }

                else
                {
                    tempagent.ViewVisibleDestinations = false;
                }
            }
        }

        private void DisplayVisibleNeighbour()
        {
            foreach (IAgent agent in _environment.Agents)
            {
                //pull out each agent 
                Agent tempagent = (Agent)agent;
                if (_togglevisibleneighbour.isOn == true)
                {
                    tempagent.ViewVisibleAgents = true;
                }

                else
                {
                    tempagent.ViewVisibleAgents = false;
                }

            }
        }

        private void DisplayFriends()
        {
            foreach (IAgent agent in _environment.Agents)
            {
                //pull out each agent 
                Agent tempagent = (Agent)agent;

                if (_togglefriends.isOn == true)
                {
                    tempagent.ViewFriends = true;
                }

                else
                {
                    tempagent.ViewFriends = false;
                }
            }
        }

        private void DisplayConversations()
        {


            if (_toggledisplayconvos.isOn == true)
            {
                _environment.DisplayConversations = true;
            }

            else
            {
                _environment.DisplayConversations = false;
            }
        }


        private void UpdateInputField()
        {
            _context.TotalNumberOfRank = Convert.ToInt32(_numberagentrank.text);
            _context.TotalNumberOfDepartment = Convert.ToInt32(_numberofdepartment.text);
            _context.TotalNumberOfTeam = Convert.ToInt32(_numberofteam.text);
            _context.MaxAgents = Convert.ToInt32(_maxnumberagent.text);
            //_context.MaxAgents = Convert.ToInt32(_maxnumberagentslider.value);
            //_maxnumberagenttext.text = Convert.ToString(_maxnumberagentslider.value);

            _context.Occupancy = _occupancyslider.value / 100;
            _context.GlobalMotivation = _overallmotivationslider.value / 100;
            _context.GlobalSocial = _overallsocialslider.value / 100;
            _overallsocialvaluetext.text = Convert.ToString(_overallsocialslider.value);
            _overallmotivationvaluetext.text = Convert.ToString(_overallmotivationslider.value);
            _overallrangevaluetext.text = Convert.ToString(_overallrangeslider.value);

            SpawnTypeToggle();
            _context.SpawnRate = (float)Convert.ToDouble(_spawnrate.value);
            _spawnratetext.text = Convert.ToString(_spawnrate.value);

            _context.SpawnSourcePercentage = (int)(Convert.ToDouble(_spawnsourceperc.value) / 100);
            _spawnsourceperctext.text = Convert.ToString((int)(Convert.ToDouble(_spawnsourceperc.value)));

        }

        private void AddAgents()
        {
            if (Convert.ToInt32(_maxnumberagent.text) > _environment.Agents.Count)
            {
                _context.MaxAgents = Convert.ToInt32(_maxnumberagent.text);
            }

        }

        private void ChangeGlobalSocial()
        {
            _overallsocialvaluetext.text = Convert.ToString(_overallsocialslider.value);
            if (_overallsocialslider.value / 100 != _environment.GlobalSocial)
            {
                _environment.GlobalSocial = _overallsocialslider.value / 100;
            }
        }

        private void ChangeGlobalMotivation()
        {
            _overallmotivationvaluetext.text = Convert.ToString(_overallmotivationslider.value);
            if (_overallmotivationslider.value / 100 != _environment.GlobalMotivation)
            {
                _environment.GlobalMotivation = _overallmotivationslider.value / 100;
            }
        }

        private void ChangeGlobalRange()
        {
            _overallrangevaluetext.text = Convert.ToString(_overallrangeslider.value);
            if (_overallrangeslider.value / 100 != _environment.GlobalAgentRangeF)
            {
                _environment.GlobalAgentRange = (double)_overallrangeslider.value;
                Debug.Log("updaterange");

                foreach (Agent agent in _environment.Agents)
                {
                    agent.Range = _environment.GlobalAgentRange;
                }
            }
        }

        public void OpenHistoryMapDisplayPanel()
        {
            if (_togglehistory.isOn == false)
            {
                _togglehistorymappanel.isOn = false;
                _panelhistorymap.SetActive(false);
            }

            if (_togglehistory.isOn == true)
            {
                _togglehistorymappanel.isOn = true;
                _panelhistorymap.SetActive(true);
            }
        }

        public void OpenMapSettingsPanel()
        {
            if (_togglehistory.isOn == false)
            {
                _togglehistorymappanel.isOn = false;
                _panelhistorymap.SetActive(false);
            }

            if (_togglehistory.isOn == true)
            {
                _togglehistorymappanel.isOn = true;
                _panelhistorymap.SetActive(true);
            }
        }

        public void ChangeDecayValue()
        {
            _decaytext.text = Convert.ToString(_sliderDecay.value);
            _environment.CurrentOccupancyMapController.Decay = _sliderDecay.value / 100;
            _environment.ZonesMapController.Decay = _sliderDecay.value / 100;
            _environment.HistoryMapController.Decay = _sliderDecay.value / 100;
        }

        public void ChangeDisplayGridHeight()
        {
            if (_occupancymapdisplay == null)
            {
                _occupancymapdisplay = (InfluenceMapDisplay)_environment.CurrentOccupancyMapController.Display;
            }

            if (_historymapdisplay == null)
            {
                _historymapdisplay = (HistoryMapDisplay)_environment.HistoryMapController.Display;
            }

            _occupancymapdisplay.GridHeight = _slidergridheight.value;
            _historymapdisplay.GridHeight = _slidergridheight.value;
            _gridheighttext.text = Convert.ToString(_slidergridheight.value);
        }

        public void ChangeHistoryDisplay()
        {
            if (_historymapdisplay == null)
            {
                _historymapdisplay = (HistoryMapDisplay)_environment.HistoryMapController.Display;
            }

            foreach (IAgent agent in _environment.Agents)
            {
                Agent tempagent = (Agent)agent;

                if (_togglehistoryall.isOn == true)
                {
                    _historymapdisplay.DisplayMode = HistoryMapDisplayMode.All;
                }

                if (_togglehistorystanding.isOn == true)
                {
                    _historymapdisplay.DisplayMode = HistoryMapDisplayMode.Idle;
                }

                if (_togglehistorywalking.isOn == true)
                {
                    _historymapdisplay.DisplayMode = HistoryMapDisplayMode.Walking;
                }

                if (_togglehistoryconversation.isOn == true)
                {
                    _historymapdisplay.DisplayMode = HistoryMapDisplayMode.Conversation;
                }

                if (_togglehistorysitting.isOn == true)
                {
                    _historymapdisplay.DisplayMode = HistoryMapDisplayMode.Working_Alone;
                }

                if (_togglehistorymeeting.isOn == true)
                {
                    _historymapdisplay.DisplayMode = HistoryMapDisplayMode.Meeting;
                }
            }

        }

        private void ConvertMinSec(float seconds, out int min, out int sec)
        {
            float num = seconds / 60f;

            long whole = (long)num;
            float frac = num - whole;
            frac = frac * 60f;
            long secondsonly = (long)frac;
            min = (int)whole;
            sec = (int)secondsonly;
        }

        private void ConvertMinSec(int secondsint, out int min, out int sec)
        {
            float seconds = (float)secondsint;
            float num = seconds / 60f;

            long whole = (long)num;
            float frac = num - whole;
            frac = frac * 60f;
            long secondsonly = (long)frac;
            min = (int)whole;
            sec = (int)secondsonly;
        }

        #endregion

        #region Public Methods
        #endregion

        #region Public Properties

        #endregion
        */
    }

}