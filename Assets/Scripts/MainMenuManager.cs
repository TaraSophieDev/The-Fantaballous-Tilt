using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using System.Linq;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour {

  [Serializable]
  public class MenuLayer {
    public string Name;
    public GameObject UI;
    public GameObject firstSelectedGO;
  }
  
  [SerializeField] private MenuLayer[] m_MenuLayers;

  [SerializeField] private EventSystem eventSystem;
  
  // [SerializeField] private GameObject MainMenu;
  // [SerializeField] private GameObject LevelSelectMenu;
  // [SerializeField] private GameObject CreditsMenu;
  // [SerializeField] private GameObject OptionsMenu;
  public void CloseGame() {
    Application.Quit();
  }

  private void Start() {
    //MainMenu.transform.GetComponentInChildren<Button>().gameObject
  }

  // public void GoToNextLevel() {
  //   SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
  // }
  //
  // public void RestartLevel() {
  //   SceneManager.LoadScene(SceneManager.GetActiveScene().name);
  // }
  //
  // public void GoToMainMenu() {
  //   SceneManager.LoadScene(1);
  // }
  // Thanks a lot Jam <3
  public void SwitchLayer(string layerName) {
    foreach (var layer in m_MenuLayers) {
      layer.UI.SetActive(false);
    }
    
    MenuLayer menuLayer = m_MenuLayers.ToList().Find(x => x.Name == layerName);
    menuLayer.UI.SetActive(true);
    eventSystem.SetSelectedGameObject(menuLayer.firstSelectedGO);
  }
}