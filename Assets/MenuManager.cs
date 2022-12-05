using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MenuManager : MonoBehaviour
{
    // Build number of scene to start when start button is pressed
    public int gameStartScene;

    public static MenuManager instance;

    // Start is called before the first frame update
    void Start()
    {
        //This is how it's done.

        if (MenuManager.instance == null){
            MenuManager.instance = this; 
            DontDestroyOnLoad(this);
        }
        //Menu manager must be true on startup.
        gameObject.SetActive(true);
        
    }
    
    public void StartGame()
    {
        gameStartScene = 0;

        SceneManager.LoadScene(gameStartScene);

        BarManager.instance.gameObject.SetActive(true);
        CustomerManager.instance.gameObject.SetActive(true);
        VariableStorage.instance.gameObject.SetActive(true);
        SpaceBarButtonManager.instance.gameObject.SetActive(true);
    }

    public void QuitGame(){
        Application.Quit();
    }

    public void Options(){}

}
