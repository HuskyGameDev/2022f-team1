using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SpaceBarButtonManager : MonoBehaviour
{
    public int sceneToLoad;

    //Button Functionality for the Employee Button
    public void EmployeeOnPress()
    {
        sceneToLoad = 1;

            SceneManager.LoadScene(sceneToLoad);
    }

    //Button Functionality for the Store Button
    public void StoreOnPress()
    {
        sceneToLoad = 2;

        SceneManager.LoadScene(sceneToLoad);
    }

    //Button Functionality for the Help Button
    public void HelpOnPress()
    {
        print("Help Button Was Pressed");
    }
}
