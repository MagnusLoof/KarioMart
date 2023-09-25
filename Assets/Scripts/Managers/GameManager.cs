using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public void Initialize()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
            if(SceneManager.GetActiveScene() == null)
            {
                Load("StartScene");
            }
            return;
        }

        Destroy(gameObject);
    }

    public void Load(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
}
