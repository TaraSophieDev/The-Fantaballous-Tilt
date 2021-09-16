using System;
using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class Intro : MonoBehaviour {

  public int time = 0;

  private void LoadNextScene() {
    SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
  }
  
  void Start() {
    StartCoroutine(WaitUntilIntroFinished());
  }

  private void Update() {
    if (Gamepad.current != null) {
      if (Gamepad.current.aButton.isPressed)
        LoadNextScene();
    }
    if (Keyboard.current.spaceKey.isPressed)
      LoadNextScene();
  }

  IEnumerator WaitUntilIntroFinished() {
    yield return new WaitForSeconds(time);

    LoadNextScene();
  }
}