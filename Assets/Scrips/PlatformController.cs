using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlatformController : MonoBehaviour
{
  public Transform originOverride;
  Vector3 m_offset;
  public Camera playerCamera;
  public float cameraDistance = 10f;
  public float cameraHeight = 10f;
  public float maximumBallSpeed = 10f;
  public float ballGravity = 1f;
  public float angleLimit = 45f;
  public Rigidbody ball_rb;

  public float rotation_speed = 5f;

  private float y_rotation, x_rotation, z_rotation;

  Quaternion worldRotator;

  public void HandleInput() {
    // Gamepad
    if (Gamepad.current != null) {
      y_rotation += Gamepad.current.leftStick.y.ReadValue() * 30.0f *Time.deltaTime;
      x_rotation += Gamepad.current.leftStick.x.ReadValue() * 30.0f * Time.deltaTime;
    } 
    else {
      // left and right rotation
      if (Keyboard.current.aKey.IsPressed())
        y_rotation = Mathf.Clamp(y_rotation - 1 * rotation_speed * Time.deltaTime, -angleLimit, angleLimit);
      if (Keyboard.current.dKey.IsPressed())
        y_rotation = Mathf.Clamp(y_rotation + 1 * rotation_speed * Time.deltaTime, -angleLimit, angleLimit);

      if (Keyboard.current.wKey.IsPressed())
        x_rotation = Mathf.Clamp(x_rotation + 1 * rotation_speed * Time.deltaTime, -angleLimit, angleLimit * 0.5f);
      if (Keyboard.current.sKey.IsPressed())
        x_rotation = Mathf.Clamp(x_rotation - 1 * rotation_speed * Time.deltaTime, -angleLimit, angleLimit*0.5f);

      if(Keyboard.current.qKey.IsPressed())
        z_rotation = z_rotation + 1 * rotation_speed * Time.deltaTime;
      if (Keyboard.current.eKey.IsPressed())
        z_rotation = z_rotation - 1 * rotation_speed * Time.deltaTime;
    }
  }


  void Start() {
    CalculateRotation();
  }

  private void Update(){
    HandleInput();
  }

  void FixedUpdate() {
    CalculateRotation();

    ball_rb.velocity += Vector3.ProjectOnPlane(Vector3.Lerp(-playerCamera.transform.up, playerCamera.transform.forward, (x_rotation + angleLimit) / (angleLimit*0.5f + angleLimit)), Vector3.up) * ballGravity;
    ball_rb.velocity = Vector3.ClampMagnitude(ball_rb.velocity, maximumBallSpeed);
  }

  public void CalculateRotation() {
    if (originOverride != null)
      m_offset = originOverride.transform.position;
    else
      m_offset = Vector3.zero;

      playerCamera.transform.position = m_offset + ((Quaternion.Euler(x_rotation, z_rotation, 0f) * new Vector3(0f,cameraHeight, cameraDistance)));
      playerCamera.transform.rotation = Quaternion.LookRotation(m_offset-playerCamera.transform.position) * Quaternion.Euler(0f, 0f, y_rotation);
  }

  //t = (c - a / (b-a))
}