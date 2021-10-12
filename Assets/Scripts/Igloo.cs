using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Igloo : MonoBehaviour {
  private GameObject ball;
  private GameObject igloo;

  //private LifeManager lifeSystem;
  // [SerializeField] private GameObject ball;
  // [SerializeField] private GameObject spawnPoint;

  private void OnTriggerEnter(Collider other) {
    if (other.gameObject.CompareTag("Player")) {
      ball.transform.position = igloo.transform.position;
    }
  }

  private void Awake() {
    ball = GameObject.FindWithTag("Player");
    igloo = GameObject.FindWithTag("SpawnPoint");
  }
}