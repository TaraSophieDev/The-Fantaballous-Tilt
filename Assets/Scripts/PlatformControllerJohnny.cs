using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlatformControllerJohnny : MonoBehaviour
{
  public Transform originOverride;
  Vector3 m_Offset;
  public Camera playerCamera;
  public float cameraDistance = 10f;
  public float cameraHeight = 10f;
  public float maximumBallSpeed = 10f;
  public float ballGravity = 1f;
  public float angleLimit = 45f;
  public Rigidbody ballRb;

  public float rotation_speed = 5f;

  private float y_rotation, x_rotation, z_rotation, l_trigger, r_trigger;

  Quaternion worldRotator;

  private void HandleInput() {
    // Gamepad
    if (Gamepad.current != null) {
      // x_rotation = Gamepad.current.leftStick.x.ReadValue() * 30.0f;
      // z_rotation = Gamepad.current.leftStick.y.ReadValue() * 30.0f;
      // l_trigger = Gamepad.current.leftTrigger.ReadValue() * 30.0f;
      // r_trigger = Gamepad.current.rightTrigger.ReadValue() * 30.0f;
      
      y_rotation += Gamepad.current.leftStick.x.ReadValue() * 30.0f *Time.deltaTime;
      x_rotation += Gamepad.current.leftStick.y.ReadValue() * 30.0f * Time.deltaTime;
    } 
    else {
      // // left and right rotation
      // if (Keyboard.current.aKey.IsPressed())
      //   x_rotation -= 1;
      // if (Keyboard.current.dKey.IsPressed())
      //   x_rotation += 1;
      //
      // // forwards and backwards rotation
      // if (Keyboard.current.wKey.IsPressed())
      //   z_rotation += 1;
      // if (Keyboard.current.sKey.IsPressed())
      //   z_rotation -= 1;
      //
      // // Y axis rotation
      // if (Keyboard.current.qKey.IsPressed())
      //   l_trigger += 1;
      // if (Keyboard.current.eKey.IsPressed())
      //   r_trigger += 1;
      
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

    ballRb.velocity += Vector3.ProjectOnPlane(Vector3.Lerp(-playerCamera.transform.up, playerCamera.transform.forward, (x_rotation + angleLimit) / (angleLimit*0.5f + angleLimit)), Vector3.up) * ballGravity;
    ballRb.velocity = Vector3.ClampMagnitude(ballRb.velocity, maximumBallSpeed);
  }

  public void CalculateRotation() {
    if (originOverride != null) {
      m_Offset = originOverride.transform.position;
    }
    else {
      m_Offset = Vector3.zero;
    }

    playerCamera.transform.position = m_Offset + ((Quaternion.Euler(x_rotation, z_rotation, 0f) * new Vector3(0f,cameraHeight, cameraDistance)));
    playerCamera.transform.rotation = Quaternion.LookRotation(m_Offset-playerCamera.transform.position) * Quaternion.Euler(0f, 0f, y_rotation);
  }

  //t = (c - a / (b-a))
}