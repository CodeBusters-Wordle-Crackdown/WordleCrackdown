using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;

//referenced Christina Creates Games Youtube video: Creating a Toggle Switch System in Unity step by step (toggle button): https://www.youtube.com/watch?v=E9AWlbPGi_4
public class cs_toggleSwitch : MonoBehaviour, IPointerClickHandler
{
   [Header("Slider Configuration")]
   [SerializeField, Range(0,1f)] private float sliderValue;
   public bool currentSliderValue
   {
    get;
    private set;

   }
   private bool _prevValue;
   private Slider _slider;

   [Header("Animation")]
   [SerializeField, Range(0, 1f)] private float animationDuration = 0.5f;
   [SerializeField] private AnimationCurve slideEase = AnimationCurve.EaseInOut(timeStart:0, valueStart: 0, timeEnd: 1, valueEnd: 1);
   

   private Coroutine _animateSliderCoroutine;

   [Header("Events")]
   [SerializeField] private UnityEvent onToggleOn;
   [SerializeField] private UnityEvent onToggleOff;

   private cs_ToogleSwitchGroupManager _toggleSwitchGroupManager;

   protected Action transitionEffect;
   protected virtual void  onValidate()
   {
    SetupToggleComponents();

    _slider.value= sliderValue;
    Debug.Log(message:"slider validated. slider value "+ sliderValue, context:this);
   }

   private void SetupToggleComponents()
   {
    if(_slider is null)
    {
        Debug.Log(message:" No slider active. ", context:this);
        return;
    }

    SetupSliderComponents();

   }

   private void SetupSliderComponents()
   {
    Debug.Log(message:"Initializing slider components...", context:this);
    _slider = GetComponent<Slider>();
    if (_slider==null)
    {
        Debug.LogError(message: "No slider found!", context:this);

        return;
    }
    Debug.Log(message:"slider.interactable initialized to false", context:this);

    _slider.interactable=false;
    var sliderColors = _slider.colors;
    sliderColors.disabledColor = Color.white;
    _slider.colors = sliderColors;
    _slider.transition = Selectable.Transition.None;


    
   }

   public void SetupForManager(cs_ToogleSwitchGroupManager manager)
   {
    _toggleSwitchGroupManager = manager;


   }

   protected virtual void Awake()
   {
    SetupSliderComponents();
   }

   public void OnPointerClick(PointerEventData eventData)
   {
    Toggle();
   }

   private void Toggle()
   {
    if(_toggleSwitchGroupManager !=null)
    {
        _toggleSwitchGroupManager.ToggleGroup(this);
    }
    else
    {
        SetStateAndStartAnimation(!currentSliderValue);
    }
    
   }

   public void ToggleByGroupManager(bool valueToSetTo)
   {
    SetStateAndStartAnimation(valueToSetTo);
   }

   private void SetStateAndStartAnimation(bool state)
   {
    _prevValue = currentSliderValue;
    currentSliderValue = state;

    if(_prevValue!=currentSliderValue)
    {
        if(currentSliderValue)
        {
            onToggleOn?.Invoke();
        }
        else
        {
            onToggleOff?.Invoke();
        }
        
    }

    if(_animateSliderCoroutine!=null)
    {
        StopCoroutine(_animateSliderCoroutine);
    }
    _animateSliderCoroutine=StartCoroutine(AnimateSlider());

   }

   private IEnumerator AnimateSlider()
   {
    float startValue = _slider.value;
    float endValue = currentSliderValue?1:0;

    float time = 0f;
    if(animationDuration>0)
    {
        while(time < animationDuration)
        {
            time+=Time.deltaTime;

            float lerpFactor = slideEase.Evaluate(time /animationDuration);
            _slider.value = sliderValue= Mathf.Lerp(startValue,endValue, lerpFactor);

            transitionEffect?.Invoke();
            yield return null;
        }
    }


   }
}
