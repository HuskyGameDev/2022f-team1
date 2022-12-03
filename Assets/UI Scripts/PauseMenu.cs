using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{

    public static bool GameIsPaused = false;

    public GameObject pauseMenuUI;
    public GameObject optionMenuUI;
    public GameObject helpMenuUI;
    public GameObject nameInputField;
    public GameObject changeNameButton;


    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (GameIsPaused)
            {
                Resume();
            }        else
            {
                Pause();
            }
        }

    }

    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        optionMenuUI.SetActive(false); 
        helpMenuUI.SetActive(false);
        nameInputField.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
    }

    public void Pause()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
    }

    public void LoadOptions()
    {
        optionMenuUI.SetActive(true);
        pauseMenuUI.SetActive(false);
    }

    public void OptionsReturn()
    {
        pauseMenuUI.SetActive(true);
        optionMenuUI.SetActive(false);
    }

    public void LoadHelp()
    {
        helpMenuUI.SetActive(true);
        optionMenuUI.SetActive(false);
    }

    public void HelpReturn()
    {
        optionMenuUI.SetActive(true);
        helpMenuUI.SetActive(false);
    }

    public void LoadMenu()
    {
        Time.timeScale = 1f;
        GameIsPaused = false;
        SceneManager.LoadScene("MainMenu");
    }

    public void LoadTextChanger()
    {
        nameInputField.SetActive(true);
        changeNameButton.SetActive(false);
    }

    public void CloseTextChanger()
    {
        changeNameButton.SetActive(true);
        nameInputField.SetActive(false);
    }

    public void QuitGame()
    {
        Debug.Log("Quitting Game...");
        Application.Quit();
    }
}
