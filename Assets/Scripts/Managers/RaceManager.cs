using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class RaceManager : MonoBehaviour
{
    public static RaceManager instance;
    public int lapsToWin = 3;
    public bool raceStarted;
    public List<GameObject> checkpoints = new List<GameObject>();

    [SerializeField] private List<float> raceTotalTime = new List<float>();
    [SerializeField] private TextMeshProUGUI countdownText;
    private List<List<float>> kentLap = new List<List<float>>();
    private float timer = 3;

    private void Start()
    {
        kentLap.Add(new List<float>());
        kentLap.Add(new List<float>());

        if (instance == null)
        {
            instance = this;
            return;

        }
        Destroy(gameObject);
    }

    private void Update()
    {
        if (!raceStarted)
        {
            timer -= Time.deltaTime;
            countdownText.text = string.Format("{0:0.00}", timer);
            if(timer <= 0)
            {
                raceStarted = true;
                countdownText.text = "";
                Logger.Log("Race has started");
            }
        }
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

        RaceWon(carId);
    }

    public void RaceWon(int carId)
    {
        Time.timeScale = 0f;
        MenuManager.instance.Win(carId, raceTotalTime);
    }
}