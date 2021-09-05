using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TimeManager : MonoBehaviour {

  public double currentTime;
  private double startingTime = 0.0;

  private bool timerOn = false;

  private TextMeshProUGUI timerText;

  private void StartTimer() {
    // if (timerOn)
    print("timer still on");
    currentTime = Time.timeAsDouble - startingTime;
  }

  public void StopTimer() {
    timerOn = false;
    print("stop time!!!!!!");
  }
  void Start() {
    timerOn = true;
    currentTime = startingTime;
    timerText = GetComponent<TextMeshProUGUI>();
  }
  
  void Update() {
    print(timerOn);
    if (timerOn)
      StartTimer();
    // else if (!timerOn)
      //print("timer off");
    currentTime = Math.Round(currentTime, 2);
    timerText.text = "Time: " + Convert.ToString(currentTime);
  }
}