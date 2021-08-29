using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ShowSliderValue : MonoBehaviour {
  
  private TextMeshProUGUI percentageText;
  void Start() {
    percentageText = GetComponent<TextMeshProUGUI>();
  }

  public void textUpdate(float value) {
    if (value < 256)
      percentageText.text = value + "fps";
    else
      percentageText.text = "unlimited fps";
  }
  void Update() {
  }
}