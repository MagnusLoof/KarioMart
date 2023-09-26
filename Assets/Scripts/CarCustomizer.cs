using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarCustomizer : MonoBehaviour
{
    [SerializeField] private List<GameObject> carModels = new List<GameObject>();
    [SerializeField] private int[] indice;
    //[SerializeField] private int index;

    private void Start()
    {
        for (int i = 0; i < indice.Length; i++)
        {
            CarLog(indice[0]);
        }
    }

    public void NextCar(int index)
    {
        indice[index]++;

        if(indice[index] >= carModels.Count)
        {
            indice[index] = 0;
        }

        CarLog(index);
    }
    public void PrevCar(int index)
    {
        indice[index]--;

        if (indice[index] < 0)
        {
            indice[index] = carModels.Count - 1;
        }

        CarLog(index);
    }

    public void CarLog(int index)
    {
        Logger.Log(indice[index].ToString());
        Logger.Log("Current car is " + carModels[indice[index]].ToString());
    }
}
