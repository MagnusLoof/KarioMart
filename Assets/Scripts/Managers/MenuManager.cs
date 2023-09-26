using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public void ToggleMenu(GameObject menuToToggle)
    {
        menuToToggle.SetActive(!menuToToggle.activeInHierarchy);
        //uiToEnable.SetActive(true);
    }

    public void TogglePause()
    {
        // The buttons that return you to the main menu will also call for TogglePause to make sure that the timeScale gets returned to normal
        if(Time.timeScale == 1.0)
        {
            Time.timeScale = 0.0f;
        }
        else
        {
            Time.timeScale = 1.0f;
        }
    }

    public void ChangeCar(bool direction)
    {

    }

    public void StartGame(string sceneToLoad)
    {
        GameManager.instance.Load(sceneToLoad);
    }

    public void Exit()
    {
#if UNITY_EDITOR
        Logger.Log("Trying to exit play mode");
        UnityEditor.EditorApplication.isPlaying = false;
#endif
        Logger.Log("Trying to exit game");
        Application.Quit();
    }
}