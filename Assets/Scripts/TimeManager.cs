using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TimeManager : MonoBehaviour {

  private double currentTime;
  private double startingTime = 0.0;

  private TextMeshProUGUI timerText;

  void StartTimer() {
    currentTime += Time.deltaTime;
  }
  void Start() {
    currentTime = startingTime;
    timerText = GetComponent<TextMeshProUGUI>();
  }
  
  void Update() {
    StartTimer();
    currentTime = Math.Round(currentTime, 2);
    timerText.text = Convert.ToString(currentTime);
    print(currentTime);
  }
}