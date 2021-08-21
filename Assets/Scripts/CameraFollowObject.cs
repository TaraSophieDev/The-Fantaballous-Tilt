using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Policy;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UIElements;
using UnityEngine.Windows.WebCam;

public class CameraFollowObject : MonoBehaviour {
  
  [SerializeField] private GameObject anchor;
  [SerializeField] private float zoom = 1f;
  [Range(0.01f, 1f)] private float followSpeed = 0.1f;

  private GameObject ball;
  private Vector3 offset;
  private RaycastHit hit;
  private MeshRenderer hiddenMR;

  public bool isBallFollowed = false;
  // Start is called before the first frame update

  private void RaycastBall() {
    if (Physics.Raycast(transform.position, (ball.transform.position - transform.position), out hit, Mathf.Infinity, ~(1<<2))) {
      print(hit.transform.tag);
      if (hit.transform.CompareTag("Player")) {
        print("check");
        if (hiddenMR) {
          hiddenMR.enabled = true;
          hiddenMR = null;
        }
      }
      else {
        //Only works when object has a rigidbody kinematic
        if (hit.transform.TryGetComponent(out MeshRenderer disableMR)) {
          if (disableMR != hiddenMR) {
            if (hiddenMR)
              hiddenMR.enabled = true;
            hiddenMR = disableMR;
            hiddenMR.enabled = false;
          }
        }
      }
    }
  }
  
  void BoolSwitcher() {
    if (isBallFollowed)
      isBallFollowed = false;
    else
      isBallFollowed = true;
  }
  

  void HandleInput() {
    if (Gamepad.current != null) {
      if(Gamepad.current.selectButton.wasPressedThisFrame)
        BoolSwitcher();

      if (Gamepad.current.rightStick.up.ReadValue() > 0.0f)
        zoom -= 0.01f;
      else if (Gamepad.current.rightStick.down.ReadValue() > 0.0f)
        zoom += 0.01f;
      
    } else {
      // Select button
      if (Keyboard.current.altKey.wasPressedThisFrame)
        BoolSwitcher();

      if (Keyboard.current.upArrowKey.isPressed)
        zoom -= 0.01f;
      else if (Keyboard.current.downArrowKey.isPressed)
        zoom += 0.01f;
    }
  }
  void Start() {
    ball = GameObject.FindWithTag("Player");
    
    BoolSwitcher();
    offset = transform.position - ball.transform.position;
    offset = transform.position - anchor.transform.position;
  }

  // Update is called once per frame
  void FixedUpdate() {
    HandleInput();

    //Limit Zoom
    zoom = Mathf.Clamp(zoom, 0.1f, 1);

    // TODO: Lerp this
    if (!isBallFollowed) 
      transform.position += ((anchor.transform.position + offset * zoom) - transform.position) * followSpeed;
    else
      transform.position += ((ball.transform.position + offset * zoom) - transform.position) * followSpeed;
  }

  private void Update() {
    RaycastBall();
  }

  // private void OnDrawGizmos() {
  //   Gizmos.color = Color.red;
  //   Gizmos.DrawLine(transform.position, ball.transform.position);
  //   
  // }
}
