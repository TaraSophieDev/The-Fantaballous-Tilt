using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Intro : MonoBehaviour {

  public int time = 0;
  void Start() {
    StartCoroutine(WaitUntilIntroFinished());
  }

  IEnumerator WaitUntilIntroFinished() {
    yield return new WaitForSeconds(time);

    SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
  }
}