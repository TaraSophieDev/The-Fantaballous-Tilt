using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlatformController : MonoBehaviour
{
  public GameObject ball_go;
  public Rigidbody ball_rb;

  private Rigidbody rb;
  public float rotation_speed = 5f;

  private float x_rotation, z_rotation, l_trigger, r_trigger;
  public bool ballIsParented = false;


  float xAxis, zAxis, yAxis;


  void ClampRotation(float angle, float minAngle, float maxAngle, float clampAroundAngle = 0) {
    clampAroundAngle += 180;
    angle -= clampAroundAngle;

    angle = WrapAngle(angle);
    angle -= 180;
    angle = Mathf.Clamp(angle, minAngle, maxAngle);

    angle += 180;
    
    transform.rotation = Quaternion.Euler(angle, transform.rotation.eulerAngles.y, transform.rotation.eulerAngles.z + clampAroundAngle);
  }

  float WrapAngle(float angle) {
    while (angle < 0)
      angle += 360;

      return Mathf.Repeat(angle, 360);
  }

  public void MakeParent() {
    if (ballIsParented) {
      ball_go.transform.parent = transform;
      //ball_rb.isKinematic = true;
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
    //ClampRotation(transform.eulerAngles.x, -20, 20);
    //ClampRotation(transform.eulerAngles.z, -20, 20);
    // ball_go.transform.localScale = Vector3.one;

    if (x_rotation > 0){
      ballIsParented = true;
      ball_rb.WakeUp();
      xAxis += rotation_speed * Time.deltaTime;
      //transform.Rotate(rotation_speed, 0, 0, Space.World);
    } else if (x_rotation < 0) {
      ballIsParented = true;
      ball_rb.WakeUp();
      xAxis -= rotation_speed * Time.deltaTime;
      //transform.Rotate(-rotation_speed, 0, 0, Space.World);
    } else {
      ballIsParented = false;
    }

    if (z_rotation > 0) {
      ballIsParented = true;
      ball_rb.WakeUp();
      zAxis += rotation_speed * Time.deltaTime;
      //transform.Rotate(0, 0, rotation_speed, Space.World);
    } else if (z_rotation < 0) {
      ballIsParented = true;
      ball_rb.WakeUp();
      zAxis -= rotation_speed * Time.deltaTime;
      //transform.Rotate(0, 0, -rotation_speed, Space.World);
    } else {
      ballIsParented = false;
    }

    if (l_trigger > 0) {
      ballIsParented = true;
      //ball_rb.isKinematic = true;
      ball_rb.WakeUp();
      //ball_rb.angularDrag = 0;
      yAxis += rotation_speed * Time.deltaTime;
      //transform.Rotate(0, -rotation_speed, 0, Space.World);
    } else if (r_trigger > 0) {
      ballIsParented = true;
      //ball_rb.isKinematic = true;
      ball_rb.WakeUp();
      yAxis -= rotation_speed * Time.deltaTime;
      //transform.Rotate(0, rotation_speed, 0, Space.World);
      //ball_rb.angularDrag = 0;
    } else {
      //ball_rb.isKinematic = false;
      ballIsParented = false;
      //ball_rb.angularDrag = 0.05f;
    }
  }

  void FixedUpdate() {
    Quaternion rotation = Quaternion.identity;
    rotation = Quaternion.Euler(0, -yAxis, 0) * rotation;
    rotation = Quaternion.Euler(xAxis, 0, 0) * rotation;
    rotation = Quaternion.Euler(0, 0, zAxis) * rotation;
    rb.MoveRotation(rotation);
  }
}