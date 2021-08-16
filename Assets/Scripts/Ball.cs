using System.Collections;
using System.Collections.Generic;
using TMPro;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Ball : MonoBehaviour {
  public int lifePoints = 5;

  public TextMeshProUGUI healthNumberText;

  public int getLifePoints() {
    return lifePoints;
  }
  
  public void removeLifePoint() {
    lifePoints -= 1;
  }
  
  public void Die() {
    if (lifePoints == 0)
      SceneManager.LoadScene(1);
    //switch to death scene/viewport idk
  }

  void Start() {
    healthNumberText = FindObjectOfType<TextMeshProUGUI>();
  }


  void Update() {
    healthNumberText.text = $"x{lifePoints}";
  }
}