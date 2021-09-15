using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextLevelPromptManager : MonoBehaviour {

  public void GoToNextLevel() {
    SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
  }
  
  public void RestartLevel() {
    SceneManager.LoadScene(SceneManager.GetActiveScene().name);
  }
  
  public void GoToMainMenu() {
    SceneManager.LoadScene(1);
  }
}
