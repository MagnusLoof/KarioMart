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

    private List<List<float>> lap = new List<List<float>>();
    private float timer = 3;

    private void Start()
    {
        // Hardcoding the addition of two list is definetly not the best solution
        // For loop adding a list for each car  be better for an adjustable quantity
        lap.Add(new List<float>());
        lap.Add(new List<float>());

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

    public void AddLap(float lapTimeIn, int carId)
    {
        lap[carId].Add(lapTimeIn);
        Logger.Log(lapTimeIn.ToString());
    }

    // Every lap after the first one will have all the previous laptimes included
    // So I reverse the lists of laptimes for the winning carId
    // To calculate the time for the 5th lap I just need to subtract the 4th lap
    // Example: 5th lap includes all laps, whereas 4th lap has all laps except the 5th
    // So when we do 5th lap -= 4th lap we are left with the time that only the 5th lap took
    public void CalculateWinTime(int carId)
    {
        for (int i = 0; i < lap[carId].Count; i++)
        {
            Logger.Log("Car: " + carId + " total time: " + lap[carId][i].ToString());
        }
        
        lap[carId].Reverse();
        Logger.Log("Reversed lap");

        for (int i = 0; i < lap[carId].Count; i++)
        {
            if(i < lap[carId].Count - 1)
            {
                raceTotalTime.Add(lap[carId][i] -= lap[carId][i + 1]);
            }
            else
            {
                raceTotalTime.Add(lap[carId][i]);
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