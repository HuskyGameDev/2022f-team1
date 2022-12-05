using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MenuManager : MonoBehaviour
{
    // Build number of scene to start when start button is pressed
    public int gameStartScene;
    
    public void StartGame()
    {
        gameStartScene = 0;

        SceneManager.LoadScene(gameStartScene);

        BarManager.instance.gameObject.SetActive(true);
    }

    public void QuitGame(){
        Application.Quit();
    }

    public void Options(){}

}
