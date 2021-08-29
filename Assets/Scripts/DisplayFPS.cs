using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DisplayFPS : MonoBehaviour {
  private TextMeshProUGUI fpsText;
  private float deltaTime;
  void Start() {
    fpsText = GetComponent<TextMeshProUGUI>();
  }

  void Update() {
    deltaTime += (Time.deltaTime - deltaTime) * 0.1f;
    float fps = 1.0f / deltaTime;
    fpsText.text = Math.Round(fps) + " fps";
  }
}