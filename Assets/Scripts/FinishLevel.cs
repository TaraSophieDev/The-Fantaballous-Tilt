using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinishLevel : MonoBehaviour {
  private void OnTriggerEnter(Collider other) {
    if (other.gameObject.CompareTag("Player")) {
      SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
  }

  // Start is called before the first frame update
  void Start() {
  }

  // Update is called once per frame
  void Update() {
  }
}