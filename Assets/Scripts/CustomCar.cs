using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomCarModel : MonoBehaviour
{
    [SerializeField] private int carId;

    private void Start()
    {
        Instantiate(CarCustomizer.instance.carModels[CarCustomizer.instance.indice[carId]], transform);
    }
}