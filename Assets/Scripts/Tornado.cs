using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tornado : MonoBehaviour {
  private GameObject ball;
  private Rigidbody ballRigidbody;
  private Rigidbody tornadoRigidbody;
  private GameObject spawnPoint;

  private float objectDistance;
  private Vector3 direction;
  
  //[SerializeField] private float pullStrength = 0.5f;
  [SerializeField] private int pullDistance = 10;

  private void OnTriggerEnter(Collider other) {
    if (other.gameObject.CompareTag("Player")) {
      //ball.transform.position = spawnPoint.transform.position;
    }
  }
  
  private void Awake() {
    ball = GameObject.FindWithTag("Player");
    spawnPoint = GameObject.FindWithTag("SpawnPoint");

    tornadoRigidbody = this.GetComponent<Rigidbody>();
    ballRigidbody = ball.GetComponent<Rigidbody>();
  }

  private void PullBallToTornado(float distance) {
    //ballRigidbody.AddForce((transform.position - ball.transform.position) * pullStrength * Time.fixedDeltaTime, ForceMode.Force);
    float forceMagnitude = (ballRigidbody.mass * tornadoRigidbody.mass) / (distance * distance);
    Vector3 force = direction.normalized * forceMagnitude;
    
    ballRigidbody.AddForce(force);
  }

  // private void PushBallAway(float distance) {
  //   ballRigidbody.AddForce((transform.position + ball.transform.position) * pullStrength * 10 * Time.fixedDeltaTime, ForceMode.Impulse);
  // }


  private void FixedUpdate() {
    direction = transform.position - ball.transform.position;
    objectDistance = Vector3.Distance(transform.position, ball.transform.position);
  }

  void Update() {
    if (objectDistance < pullDistance)
      PullBallToTornado(objectDistance);
  }
}