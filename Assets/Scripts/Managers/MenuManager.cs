using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{

    //public static MenuManager instance;

    /*
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);

            return;
        }

        Destroy(gameObject);
    }
    */

    public void ToggleMenu(GameObject menuToToggle)
    {
        menuToToggle.SetActive(!menuToToggle.activeInHierarchy);
        //uiToEnable.SetActive(true);
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
