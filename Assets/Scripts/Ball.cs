using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Ball : MonoBehaviour {
  private GameObject pauseMenu;
  [SerializeField] private GameObject nextLevelPrompt;

  private void ActivatePauseMenu() {
    if (pauseMenu.activeSelf == false) {
      pauseMenu.SetActive(true);
      Time.timeScale = 0f;
    }
    else {
      pauseMenu.SetActive(false);
      Time.timeScale = 1f;
    }
  }
  
  private void Start() {
    pauseMenu = GameObject.FindWithTag("Menu");
    pauseMenu.SetActive(false);
  }
  
  private void Update() {
    if (nextLevelPrompt.activeSelf == false)
      if (Gamepad.current != null && Gamepad.current.startButton.wasPressedThisFrame || Keyboard.current.escapeKey.wasPressedThisFrame)
        ActivatePauseMenu();
  }
}