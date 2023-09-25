using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InitScript
{
    [RuntimeInitializeOnLoadMethod]
    private static void InitGame()
    {
        var gameObject = new GameObject();
        gameObject.name = "GameManager";
        var gameManager = gameObject.AddComponent<GameManager>();
        gameManager.Initialize();
    }
}