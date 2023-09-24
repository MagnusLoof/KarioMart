using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaceManager : MonoBehaviour
{
    public static RaceManager instance;

    private void Awake()
    {
        instance = this;
    }

    [SerializeField] public List<GameObject> checkpoints = new List<GameObject>();
    [SerializeField] private List<CarController> cars = new List<CarController>();
}