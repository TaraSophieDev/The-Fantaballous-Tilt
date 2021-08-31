using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelSelectManager : MonoBehaviour {

  public void LoadScene(int levelNumber) {
    levelNumber += 1;
    SceneManager.LoadScene(levelNumber);
  }
  
  void Start() {
  }

  void Update() {
  }
}