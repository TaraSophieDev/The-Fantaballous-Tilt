using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlatformController : MonoBehaviour {
  [SerializeField] private GameObject ball_go;
  [SerializeField] private Rigidbody ball_rb;
  
  [SerializeField] private float rotation_speed = 25f;

  private Accelerometer accelerometer;
  private Rigidbody rb;

  private float counter = 0;
  private float x_rotation, z_rotation, targetYRotation;
  private bool l_trigger, r_trigger;
  
  private bool ballIsParented = false;


  float xAxis, zAxis, yAxis;

  private void Awake() {
    Time.timeScale = 1f;
  }

  public float Countdown(float timeToCountDown = 1f) {
    counter -= Time.deltaTime / timeToCountDown;
    return counter;
  }
  public void MakeParent() {
    if (ballIsParented) {
      ball_go.transform.parent = transform;
      ball_rb.constraints = RigidbodyConstraints.FreezeAll;
    }
    else {
      ball_go.transform.parent = null;
      ball_rb.constraints = RigidbodyConstraints.None;
    }
  }

  public void HandleInput() {
    x_rotation = z_rotation = 0.0f;
    
    // Gamepad
    if (Gamepad.current != null) {
      x_rotation = Gamepad.current.leftStick.x.ReadValue() * 30.0f;
      z_rotation = Gamepad.current.leftStick.y.ReadValue() * 30.0f;
      l_trigger = Gamepad.current.leftTrigger.wasPressedThisFrame;
      r_trigger = Gamepad.current.rightTrigger.wasPressedThisFrame;
    } else {
      // Keyboard
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
        l_trigger = true;
      else if (Keyboard.current.eKey.IsPressed())
        r_trigger = true;
      else
        l_trigger = r_trigger = false;
    }
  }


  void Start() {
    rb = GetComponent<Rigidbody>();
    accelerometer = Accelerometer.current;
  }

  void Update() {
    Countdown();
    MakeParent();
    HandleInput();

    if (x_rotation > 0){
      //ballIsParented = true;
      ball_rb.WakeUp();
      xAxis += rotation_speed * Time.deltaTime;
    } else if (x_rotation < 0) {
      //ballIsParented = true;
      ball_rb.WakeUp();
      xAxis -= rotation_speed * Time.deltaTime;
    } else {
      //ballIsParented = false;
    }

    if (z_rotation > 0) {
      //ballIsParented = true;
      ball_rb.WakeUp();
      zAxis += rotation_speed * Time.deltaTime;
    } else if (z_rotation < 0) {
      //ballIsParented = true;
      ball_rb.WakeUp();
      zAxis -= rotation_speed * Time.deltaTime;
    } else {
      //ballIsParented = false;
    }
    
    // if ((rb.angularVelocity.y > 0.75) || (rb.angularVelocity.y > -0.75)) {
    //   ballIsParented = true;
    // }
    // else {
    //   ballIsParented = false;
    // }
    if (counter > 0.2f)
      ballIsParented = true;
    else
      ballIsParented = false;

    if (counter < 0.5f) {
      if (l_trigger == true) {
        counter = 1;
        //ballIsParented = true;
        ball_rb.WakeUp();
        targetYRotation += 45;
      } else if (r_trigger == true) {
        counter = 1;
        //ballIsParented = true;
        ball_rb.WakeUp();
        targetYRotation -= 45;
        //yAxis -= 1;
      } else {
        //ballIsParented = false;
      }
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
    yAxis = Mathf.LerpAngle(yAxis, targetYRotation, Time.deltaTime * 2f);
  }

  // private void OnGUI() {
  //   if (false) {
  //     GUI.Box(new Rect(50, 0, 150, 100), "Gyroscope");
  //     GUI.Label(new Rect(50, 20, 150, 100), "g_z = ");
  //     GUI.Label(new Rect(50, 40, 150, 100), "g_x = ");
  //   }
  // }
}