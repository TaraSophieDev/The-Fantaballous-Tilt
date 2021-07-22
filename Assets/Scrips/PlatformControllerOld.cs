using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlatformControllerOld : MonoBehaviour
{
  public GameObject ball_go;
  public Rigidbody ball_rb;

  private Rigidbody rb;
  public float rotation_speed = 5f;

  private float x_rotation, z_rotation, l_trigger, r_trigger;
  public bool ballIsParented = false;


  float xAxis, zAxis, yAxis;


  public void MakeParent() {
    if (ballIsParented) {
      ball_go.transform.parent = transform;
    }
    else {
      ball_go.transform.parent = null;
    }
  }

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
    rb = GetComponent<Rigidbody>();
  }

  void Update() {
    MakeParent();
    HandleInput();

    if (x_rotation > 0){
      ballIsParented = true;
      ball_rb.WakeUp();
      xAxis += rotation_speed * Time.deltaTime;
    } else if (x_rotation < 0) {
      ballIsParented = true;
      ball_rb.WakeUp();
      xAxis -= rotation_speed * Time.deltaTime;
    } else {
      ballIsParented = false;
    }

    if (z_rotation > 0) {
      ballIsParented = true;
      ball_rb.WakeUp();
      zAxis += rotation_speed * Time.deltaTime;
    } else if (z_rotation < 0) {
      ballIsParented = true;
      ball_rb.WakeUp();
      zAxis -= rotation_speed * Time.deltaTime;
    } else {
      ballIsParented = false;
    }

    if (l_trigger > 0) {
      ballIsParented = true;
      ball_rb.WakeUp();
      yAxis += rotation_speed * Time.deltaTime;
    } else if (r_trigger > 0) {
      ballIsParented = true;
      ball_rb.WakeUp();
      yAxis -= rotation_speed * Time.deltaTime;
    } else {
      ballIsParented = false;
    }
  }

  void FixedUpdate() {
    Quaternion rotation = Quaternion.identity;
    rotation = Quaternion.Euler(0, -yAxis, 0) * rotation;
    rotation = Quaternion.Euler(xAxis, 0, 0) * rotation;
    rotation = Quaternion.Euler(0, 0, zAxis) * rotation;

    rb.MoveRotation(rotation);
  }

  void LateUpdate() {

    // Clamping in LateUpdate because else it would jitter. Idk why but this here works.
    xAxis = Mathf.Clamp(xAxis, -20, 20);
    zAxis = Mathf.Clamp(zAxis, -20, 20);
  }
}