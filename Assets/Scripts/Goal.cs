using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goal : MonoBehaviour
{
    public List<CarController> passedCars = new List<CarController>();
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            CarController passingCar = other.GetComponent<CarController>();

            if(passingCar.currentCheckpoint == RaceManager.instance.checkpoints.Count)
            {
                Debug.Log("You win!");
            }
        }
    }
}
