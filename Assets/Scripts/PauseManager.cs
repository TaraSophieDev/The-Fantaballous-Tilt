using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseManager : MonoBehaviour {
  void Start() {
  }

  void Update() {
  }

  public void ResumeGame() {
    
  }

  public void RestartLevel() {
    SceneManager.LoadScene(SceneManager.GetActiveScene().name);
  }
  
  public void OpenOptionsMenu() {
    
  }
  
  public void ExitToMainMenu() {
    SceneManager.LoadScene(1);
  }
}