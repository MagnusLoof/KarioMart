using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
            SceneManager.sceneLoaded += OnSceneLoaded;

            return;
        }

        Destroy(gameObject);
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode sceneMode)
    {
        Logger.Log("Loaded " + scene.name);
    }

    public void Load(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
}
