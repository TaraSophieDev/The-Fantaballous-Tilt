using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlatformController : MonoBehaviour
{
  public GameObject ball_go;
  public Rigidbody ball_rb;
  public float rotation_speed = 5f;

  private float x_rotation, z_rotation, l_trigger, r_trigger;
  private bool ballIsParented;


  public void HandleInput() {
    x_rotation = z_rotation = l_trigger = r_trigger = 0.0f;

    // Gamepad
    if (Gamepad.current != null) {
      x_rotation = Gamepad.current.leftStick.x.ReadValue() * 30.0f;
      z_rotation = Gamepad.current.leftStick.y.ReadValue() * 30.0f;
      l_trigger = Gamepad.current.leftTrigger.ReadValue() * 30.0f;
      r_trigger = Gamepad.current.rightTrigger.ReadValue() * 30.0f;
    } else {
      // left and right rotation
      if (Keyboard.current.aKey.IsPressed())
        x_rotation -= 1;
      if (Keyboard.current.dKey.IsPressed())
        x_rotation += 1;

      // forwards and backwards rotation
      if (Keyboard.current.wKey.IsPressed())
        z_rotation += 1;
      if (Keyboard.current.sKey.IsPressed())
        z_rotation -= 1;

      // Y axis rotation
      if (Keyboard.current.qKey.IsPressed())
        l_trigger += 1;
      if (Keyboard.current.eKey.IsPressed())
        r_trigger += 1;
    }
  }


  void Start() {
    //platform = transform.GetChild(0);
    rotation_speed *= Time.deltaTime;
  }

  void Update() {
    HandleInput();
    // ball_go.transform.localScale = Vector3.one;

    if (x_rotation > 0){
      ball_go.transform.parent = transform;
      ball_rb.WakeUp();
      transform.Rotate(rotation_speed, 0, 0, Space.World);
    } else if (x_rotation < 0) {
      ball_go.transform.parent = transform;
      ball_rb.WakeUp();
      transform.Rotate(-rotation_speed, 0, 0, Space.World);
    } else {
      ball_go.transform.parent = null;
    }

    if (z_rotation > 0) {
      ball_go.transform.parent = transform;
      ball_rb.WakeUp();
      transform.Rotate(0, 0, rotation_speed, Space.World);
    } else if (z_rotation < 0) {
      ball_go.transform.parent = transform;
      ball_rb.WakeUp();
      transform.Rotate(0, 0, -rotation_speed, Space.World);
    } else {
      ball_go.transform.parent = null;
    }

    if (l_trigger > 0) {
      ball_go.transform.parent = transform;
      //ball_rb.isKinematic = true;
      ball_rb.WakeUp();
      //ball_rb.angularDrag = 0;
      transform.Rotate(0, -rotation_speed, 0, Space.World);
    } else if (r_trigger > 0) {
      ball_go.transform.parent = transform;
      //ball_rb.isKinematic = true;
      ball_rb.WakeUp();
      transform.Rotate(0, rotation_speed, 0, Space.World);
      //ball_rb.angularDrag = 0;
    } else {
      //ball_rb.isKinematic = false;
      ball_go.transform.parent = null;
      //ball_rb.angularDrag = 0.05f;
    }
  }
}