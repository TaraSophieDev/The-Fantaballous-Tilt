using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Ball : MonoBehaviour {
  private GameObject pauseMenu;

  private void ActivatePauseMenu() {
    if (pauseMenu.activeSelf == false)
      pauseMenu.SetActive(true);
    else {
      pauseMenu.SetActive(false);
    }
  }
  
  private void Start() {
    pauseMenu = GameObject.FindWithTag("Menu");
    pauseMenu.SetActive(false);
  }
  
  private void Update() {
    if (Gamepad.current != null && Gamepad.current.startButton.wasPressedThisFrame || Keyboard.current.escapeKey.wasPressedThisFrame)
      ActivatePauseMenu();
  }
}