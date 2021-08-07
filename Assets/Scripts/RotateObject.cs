using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateObject : MonoBehaviour {
  private float yAxis;
  private Rigidbody rb;

  public int rotSpeed = 5;

  // Start is called before the first frame update
  void Start() {
    rb = GetComponent<Rigidbody>();
  }

  // Update is called once per frame
  void Update() {
    yAxis += rotSpeed * Time.deltaTime;
  }

  void FixedUpdate() {
    Quaternion rotation = Quaternion.identity;
    rotation = Quaternion.Euler(0, -yAxis, 0) * rotation;
    rb.MoveRotation(rotation);
  }
}