using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaceManager : MonoBehaviour
{
    public static RaceManager instance;
    public int lapsToWin = 3;

    private List<List<float>> lapTimes = new List<List<float>>();
    private List<List<float>> kentLap = new List<List<float>>();
    [SerializeField] private List<float> raceTotalTime = new List<float>();
    [SerializeField] public List<GameObject> checkpoints = new List<GameObject>();

    private void Start()
    {
        lapTimes.Add(new List<float>());
        lapTimes.Add(new List<float>());
        kentLap.Add(new List<float>());
        kentLap.Add(new List<float>());

        if (instance == null)
        {
            instance = this;
            return;

        }
        Destroy(gameObject);
    }

    public void AddLap(float lapTimeIn, int carId)
    {
        lapTimes[carId].Add(lapTimeIn);
        Logger.Log(lapTimeIn.ToString());
    }

    public void AddKentLap(float lapTimeIn, int carId)
    {
        kentLap[carId].Add(lapTimeIn);
        Logger.Log(lapTimeIn.ToString());
    }

    public void CalculateWinTime(int carId)
    {
        for (int i = 0; i < kentLap[carId].Count; i++)
        {
            Logger.Log("Car: " + carId + " total time: " + kentLap[carId][i].ToString());
        }
        
        kentLap[carId].Reverse();
        Logger.Log("Reversed kentLap");

        for (int i = 0; i < kentLap[carId].Count; i++)
        {
            if(i < kentLap[carId].Count - 1)
            {
                raceTotalTime.Add(kentLap[carId][i] -= kentLap[carId][i + 1]);
            }
            else
            {
                raceTotalTime.Add(kentLap[carId][i]);
            }
        }

        raceTotalTime.Reverse();
        

        /*
        for (int i = kentLap[carId].Count - 1; i > 0; i--)
        {
            //raceTotalTime.Add(kentLap[carId][i] -= kentLap[carId][i - 1]);
            kentLap[carId][i] = kentLap[carId][i - 1];
        }
        for (int i = 0; i < kentLap[carId].Count; i++)
        {
            Logger.Log(kentLap[carId][i].ToString());
        }
        */
    }

    public void RaceWon(int carId)
    {
        for (int i = 0; i < lapTimes[carId].Count; i++)
        {
            Logger.Log(lapTimes[carId][i].ToString());
        }
    }
}