using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hole : MonoBehaviour {
  
  private void OnTriggerEnter(Collider other) {
    if (other.gameObject.CompareTag("Player")) {
      print("HAHA");
    }
  }
  
  void Start() {
  }
  
  void Update() {
  }
}