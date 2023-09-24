using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    public List<CarController> passedCars = new List<CarController>();
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            CarController passingCar = other.GetComponent<CarController>();

            if (!passedCars.Contains(passingCar))
            {
                Debug.Log("Added car");
                PassCheckpoint(passingCar);
            }
            if (passedCars.Contains(passingCar))
            {
                Debug.Log("Car already exists");
            }
        }
    }

    public void PassCheckpoint(CarController carIn)
    {
        carIn.currentCheckpoint++;
        passedCars.Add(carIn);
    }
}
