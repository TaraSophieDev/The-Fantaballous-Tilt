using System.Collections;
using System.Collections.Generic;
using System.Security.Policy;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UIElements;

public class CameraFollowObject : MonoBehaviour {
  
  [SerializeField] private GameObject anchor;
  [SerializeField] private float zoom = 1f;
  [Range(0.01f, 1f)] private float followSpeed = 0.1f;

  private GameObject ball;
  private Vector3 offset;

  public bool isBallFollowed = false;
  // Start is called before the first frame update

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
}
