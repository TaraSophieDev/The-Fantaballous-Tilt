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

  private TextMeshProUGUI timerText;

  private void StartTimer() {
    currentTime = Time.timeSinceLevelLoad - startingTime;
  }

  public void StopTimer() {
    timerOn = false;
  }
  void Start() {
    //startingTime = 0.0;
    // timerOn = true;
    // currentTime = startingTime;
    // timerText = GetComponent<TextMeshProUGUI>();
    // pauseMenu = GameObject.FindWithTag("Menu");
  }

  private void ResetValues() {
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
    if (pauseMenu.activeSelf == true)
      timerOn = false;
    else
      timerOn = true;
      
    print(timerOn);
    if (timerOn)
      StartTimer();
    // else if (!timerOn)
      //print("timer off");
      currentTime = Math.Round(currentTime, 2);
    timerText.text = "Time: " + Convert.ToString(currentTime);
  }
}