using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class MenuManager : MonoBehaviour
{
    public static MenuManager instance;

    [SerializeField] private GameObject winScreen;
    [SerializeField] private TextMeshProUGUI winScreenText;
    public void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
            return;
        }
        Destroy(gameObject);
    }

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

    public void RestartMap()
    {
        GameManager.instance.Load(SceneManager.GetActiveScene().name);
    }

    public void Win(int carId, List<float> time)
    {
        winScreen.SetActive(true);

        winScreenText.text = "Player " + (carId + 1).ToString() + " wins!";
        for (int i = 0; i < time.Count; i++)
        {
            winScreenText.text += "<br> Lap " + i + ": " + time[i].ToString();
        }
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