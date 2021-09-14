using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseManager : MonoBehaviour {
  
  void Start() {
  }
  

  void Update() {
    if (this.gameObject.activeSelf == true)
      Time.timeScale = 0;
  }

  public void ResumeGame() {
    Time.timeScale = 1;
    this.gameObject.SetActive(false);
    
  }

  public void RestartLevel() {
    SceneManager.LoadScene(SceneManager.GetActiveScene().name);
  }

  public void ExitToMainMenu() {
    SceneManager.LoadScene(1);
  }
}