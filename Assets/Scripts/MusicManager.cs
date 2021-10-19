using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MusicManager : MonoBehaviour {
  [SerializeField]
  private AudioSource audioSource;
  [SerializeField]
  private AudioClip[] audioClipArray;
  void Start() {
    audioSource = GetComponent<AudioSource>();
    audioSource.loop = true;
  }

  private void playSong(byte audioArray) {
    audioSource.clip = audioClipArray[audioArray];
    audioSource.Play();
  }
  
  private void Awake()
  {
    GameObject[] musicObj = GameObject.FindGameObjectsWithTag("MusicPlayer");

    switch (SceneManager.GetActiveScene().name) {
      case "Level_1": case "Level_2": case "Level_3": case "Level_4": case "Level_5": case "Level_6":
        //play forest music
        break;
      case "Level_7": case "Level_8": case "Level_9": case "Level_10": case "Level_11": case "Level_12":
        //play snow/ice music
        break;
      case "Level_13": case "Level_14": case "Level_15": case "Level_16": case "Level_17": case "Level_18":
        //play desert music
        break;
      default:
        playSong(0);
        break;
    }

    if (SceneManager.GetActiveScene().name == "MainMenu")
      if (musicObj.Length > 1) {
        Destroy(this.gameObject);
      }
    DontDestroyOnLoad(this.gameObject);
  }
}