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

  private void RunningTimer() {
    currentTime = Time.timeSinceLevelLoad - startingTime;
  }

  public void StopTimer() {
    print("stop time");
    levelFinished = true;
  }
  void Start() {
    //startingTime = 0.0;
    // timerOn = true;
    // currentTime = startingTime;
    // timerText = GetComponent<TextMeshProUGUI>();
    // pauseMenu = GameObject.FindWithTag("Menu");
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
  }

  void Update() {
    if (!levelFinished) {
      print("not finished");
      if (pauseMenu.activeSelf == true)
        timerOn = false;
      else
        timerOn = true;
    }
    else {
      timerOn = false;
    }
      
    print(timerOn);
    if (timerOn || !levelFinished)
      RunningTimer();
    // else if (!timerOn)
      //print("timer off");
      currentTime = Math.Round(currentTime, 2);
    timerText.text = "Time: " + Convert.ToString(currentTime);
  }
}