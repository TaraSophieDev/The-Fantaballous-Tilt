using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;

public class FinishLevel : MonoBehaviour {
  
  [SerializeField] private TimeManager timeManager;
  [SerializeField] private GameObject NextLevelPrompt;

  private double time;

  private void OnTriggerEnter(Collider other) {
    if (other.gameObject.CompareTag("Player")) {
      NextLevelPrompt.SetActive(true);
      Time.timeScale = 0f;
      //timeManager.StopTimer();
      //time = timeManager.currentTime;
      //print(time);
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