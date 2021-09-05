using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;

public class FinishLevel : MonoBehaviour {
  
  [SerializeField] private TimeManager timeManager;

  private double time;

  private void OnTriggerEnter(Collider other) {
    if (other.gameObject.CompareTag("Player")) {
      timeManager.StopTimer();
      time = timeManager.currentTime;
      print(time);
      //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
  }

  // Start is called before the first frame update
  void Start() {
    //timeManager = GameObject.FindWithTag("Timer");
  }

  // Update is called once per frame
  void Update() {
  }
}