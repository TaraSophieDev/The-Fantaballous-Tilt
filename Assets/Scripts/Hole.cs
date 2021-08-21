using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hole : MonoBehaviour {
  private GameObject ball;
  private GameObject spawnPoint;

  private LifeManager lifeSystem;
  // [SerializeField] private GameObject ball;
  // [SerializeField] private GameObject spawnPoint;

  private void OnTriggerEnter(Collider other) {
    if (other.gameObject.CompareTag("Player")) {
      ball.transform.position = spawnPoint.transform.position;
      lifeSystem.TakeLife();
    }
  }

  void Start() {
    lifeSystem = FindObjectOfType<LifeManager>();
    
    ball = GameObject.FindWithTag("Player");
    spawnPoint = GameObject.FindWithTag("SpawnPoint");
  }
}