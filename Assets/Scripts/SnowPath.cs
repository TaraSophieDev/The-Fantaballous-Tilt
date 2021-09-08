using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnowPath : MonoBehaviour {

    private GameObject ball;
    private Rigidbody ballRigidbody;

    private void Awake() {
        ball = GameObject.FindWithTag("Player");
        ballRigidbody = ball.GetComponentInChildren<Rigidbody>();
    }

    private void OnTriggerEnter(Collider other) {
        if (other.gameObject.CompareTag("Player")) {
            ballRigidbody.drag = 5;
        }
    }

    private void OnTriggerExit(Collider other) {
        if (other.gameObject.CompareTag("Player")) {
            ballRigidbody.drag = 0;
        }
    }

    void Start() {
        
    }

    void Update() {
        
    }
}
