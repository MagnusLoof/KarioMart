using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckpointController : MonoBehaviour
{
    public int currentCheckpoint;
    public int lap = 1;
    public int carId;

    private List<GameObject> checkpoints = new List<GameObject>();
    private float lapTimer;
    private bool hasWon;

#if UNITY_EDITOR
    public bool instantWin;
#endif

    private void Update()
    {
        lapTimer += Time.deltaTime;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Checkpoint"))
        {
            GameObject passedCheckpoint = other.gameObject;

            if (!checkpoints.Contains(passedCheckpoint))
            {
                PassCheckpoint(passedCheckpoint);
            }
            if (checkpoints.Contains(passedCheckpoint))
            {
                Debug.Log("Checkpoint already exists");
            }
        }

        else if(other.CompareTag("Goal"))
        {
            if(currentCheckpoint == RaceManager.instance.checkpoints.Count)
            {
                RaceManager.instance.AddLap(lapTimer, carId);

                if (lap < RaceManager.instance.lapsToWin)
                {
                    checkpoints.Clear();
                    currentCheckpoint = 0;
                    lap++;
                    Logger.Log(gameObject.name + " is on lap " + lap.ToString());
                }
                else if(!hasWon)
                {
                    hasWon = true;
                    Logger.Log("You win");
                    RaceManager.instance.CalculateWinTime(carId);
                    Time.timeScale = 0.0f;
                }
            }

#if UNITY_EDITOR
            if (instantWin)
            {
                Time.timeScale = 0.0f;
            }
#endif
        }
    }

    public void PassCheckpoint(GameObject checkpointIn)
    {
        currentCheckpoint++;
        checkpoints.Add(checkpointIn);
    }
}