using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//referenced Christina Creates Games Youtube video: Creating a Toggle Switch System in Unity step by step (toggle button): https://www.youtube.com/watch?v=E9AWlbPGi_4
//ChristinaCreatesGames git repo: https://github.com/Maraakis/ChristinaCreatesGames/blob/main/Toggle%20Switch%20System/ToggleSwitch.cs
public class cs_ToogleSwitchGroupManager : MonoBehaviour
{

 
        [Header("Start Value")]
        [SerializeField] private cs_toggleSwitch initialToggleSwitch;

        [Header("Toggle Options")]
        [SerializeField] private bool allCanBeToggledOff;
        
        private List<cs_toggleSwitch> _toggleSwitches = new List<cs_toggleSwitch>();

        private void Awake()
        {
            cs_toggleSwitch[] toggleSwitches = GetComponentsInChildren<cs_toggleSwitch>();
            foreach (var toggleSwitch in toggleSwitches)
            {
                RegisterToggleButtonToGroup(toggleSwitch);
            }
        }

        private void RegisterToggleButtonToGroup(cs_toggleSwitch toggleSwitch)
        {
            if (_toggleSwitches.Contains(toggleSwitch))
                return;
            
            _toggleSwitches.Add(toggleSwitch);
            
            toggleSwitch.SetupForManager(this);
        }

        private void Start()
        {
            bool areAllToggledOff = true;
            foreach (var button in _toggleSwitches)
            {
                if (!button.currentSliderValue) 
                    continue;
                
                areAllToggledOff = false;
                break;
            }

            if (!areAllToggledOff || allCanBeToggledOff) 
                return;
            
            if (initialToggleSwitch != null)
                initialToggleSwitch.ToggleByGroupManager(true);
            else
                _toggleSwitches[0].ToggleByGroupManager(true);
        }

        public void ToggleGroup(cs_toggleSwitch toggleSwitch)
        {
            if (_toggleSwitches.Count <= 1)
                return;

            if (allCanBeToggledOff && toggleSwitch.currentSliderValue)
            {
                foreach (var button in _toggleSwitches)
                {
                    if (button == null)
                        continue;

                    button.ToggleByGroupManager(false);
                }
            }
            else
            {
                foreach (var button in _toggleSwitches)
                {
                    if (button == null)
                        continue;

                    if (button == toggleSwitch)
                        button.ToggleByGroupManager(true);
                    else
                        button.ToggleByGroupManager(false);
                }
            }
        }
    
}
