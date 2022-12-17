using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour{
    public static bool isGamePaused = false;
    public GameObject pauseMenuUI;
    public GameObject pauseButtonUI;
    private string menuScene = "Menu";

    public void PauseGame(){
        pauseMenuUI.SetActive(true);
        pauseButtonUI.SetActive(false);
        Time.timeScale = 0f;
        isGamePaused = true;
    }

    public void ResumeGame(){
        pauseMenuUI.SetActive(false);
        pauseButtonUI.SetActive(true);

        Time.timeScale = 1f;
        isGamePaused = false;
    }

    public void LoadMenu(){
        SceneManager.LoadScene(menuScene);
        Time.timeScale = 1f;
    }

    public void QuitGame(){
        Debug.Log("Quit");
        Application.Quit();
    }
}