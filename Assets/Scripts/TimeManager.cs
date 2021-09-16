using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TimeManager : MonoBehaviour {

  private GameObject pauseMenu;

  public double currentTime;
  private double startingTime;

  private bool timerOn = false;
  private bool levelFinished = false;

  private TextMeshProUGUI timerText;
  private TimeSpan timespan;

  private void RunningTimer() {
    currentTime = Time.timeSinceLevelLoad - startingTime;
    timespan = TimeSpan.FromSeconds(currentTime);
    string timePlayingString = "Time: " + timespan.ToString("mm':'ss'.'ff");
    timerText.text = timePlayingString;
  }

  public void StopTimer() {
    print("stop time");
    levelFinished = true;
  }

  private void ResetValues() {
    levelFinished = false;
    startingTime = 0.0;
    currentTime = 0.0;
    timerOn = true;
    currentTime = startingTime;
  }
  
  private void Awake() {
    timerText = GetComponent<TextMeshProUGUI>();
    pauseMenu = GameObject.FindWithTag("Menu");
    ResetValues();
    timerText.text = "Time: 00:00.00";
  }

  void Update() {
    if (!levelFinished) {
      if (pauseMenu.activeSelf == true)
        timerOn = false;
      else
        timerOn = true;
    }
    else {
      timerOn = false;
    }
    
    if (timerOn || !levelFinished)
      RunningTimer();
    // else if (!timerOn)
      //print("timer off");
    // currentTime = Math.Round(currentTime, 2);
    // timerText.text = "Time: " + Convert.ToString(currentTime);
  }
}