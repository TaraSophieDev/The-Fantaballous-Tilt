using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CameraFollowObject : MonoBehaviour {
  
  [SerializeField] private GameObject anchor;
  [SerializeField] private GameObject ball;
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
    } else {
      // Select button
      if (Keyboard.current.altKey.wasPressedThisFrame)
        BoolSwitcher();
    }
  }
  void Start()
  {
    BoolSwitcher();
    offset = transform.position - ball.transform.position;
    offset = transform.position - anchor.transform.position;
  }

  // Update is called once per frame
  void Update() {
    HandleInput();

    // TODO: Lerp this
    if (!isBallFollowed) 
      transform.position = anchor.transform.position + offset;
    else
      transform.position = ball.transform.position + offset;
  }
}
