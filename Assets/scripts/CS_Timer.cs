using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using JetBrains.Annotations;

public class CS_Timer : MonoBehaviour
{
    [SerializeField]
    private Board Game;

    [Header("Timer")]
    [SerializeField]
    private TextMeshProUGUI timerText;
    [Tooltip("Should a countdown time limit be enforced")]
    public bool timerEnabled;
    [Tooltip("Time limit in seconds")]
    public int timeLimit;
    [Tooltip("On correct guess, should a new word be found and time be added? (This overrides timerEnabled boolean)")]
    public bool infiniteMode;
    [Tooltip("If infinite mode is enabled, how much time should be added on correct guess in seconds")]
    public float correctGuessTimeReward;

    public float timer;
    private bool isTimerRunning;

    // Update is called once per frame
    void Update()
    {
        if(isTimerRunning)
            RunTimer();
    }

    public void ResetTimer()
    {
        timer = 0;
    }

    public void StartTimer()
    {
        isTimerRunning = true;
    }

    public void StopTimer()
    {
        isTimerRunning = false;
    }

    public void AddTime(float time)
    {
        timer -= time;
    }

    public void PauseTime(float pauseDuration)
    {

    }

    //added public function to enable/disable timer text --cehinds 20 Nov 2024
    public void toggleTimerMode(bool timerToggle)
    {
        if (timerToggle == true)
        {
            timerText.gameObject.SetActive(true);
            Debug.Log("Setting timer visibility set to: " + timerToggle);
        }
        else if (timerToggle == false)
        {
            timerText.gameObject.SetActive(false);
            Debug.Log("Setting timer visibility set to: " + timerToggle);

        }
        
    }

    public void RunTimer()
    {
        TimeSpan time;
        // increment timer
        timer += Time.deltaTime;

            
        // check if time limit is over
        if (timerEnabled)
        {
            if (timer >= timeLimit)
                Game.GameOver();
            time = TimeSpan.FromSeconds(timeLimit - timer);
            timerText.text = time.ToString(@"mm\:ss");

            if (time.TotalSeconds < 60 && timerText.color != Color.red)
            {
                    timerText.color = Color.red;
            }
            else if (timerText.color != Color.white && time.TotalSeconds > 60)
            {
                timerText.color = Color.white;
            }
        }
        // if a time limit is not enforced (stopwatch mode)
        else
        {
            time = TimeSpan.FromSeconds(timer);
        }
        timerText.text = time.ToString(@"mm\:ss");
    }
}
