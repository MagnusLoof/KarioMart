using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckpointController : MonoBehaviour
{
    private List<GameObject> checkpoints = new List<GameObject>();
    public int currentCheckpoint;
    public int lap;

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Checkpoint")
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

        else if(other.tag == "Goal")
        {
            if(currentCheckpoint == RaceManager.instance.checkpoints.Count)
            {
                if(lap < 2)
                {
                    checkpoints.Clear();
                    currentCheckpoint = 0;
                    lap++;
                }
                else
                {
                    Debug.Log("You win");
                }
            }
        }
    }
    public void PassCheckpoint(GameObject checkpointIn)
    {
        currentCheckpoint++;
        checkpoints.Add(checkpointIn);
    }
}
