using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;
public class CarCustomizer : MonoBehaviour
{
    public static CarCustomizer instance;

    [SerializeField] public List<GameObject> carModels = new List<GameObject>();
    [SerializeField] public List<Sprite> carSprites = new List<Sprite>();
    [SerializeField] private List<Image> carImages = new List<Image>();
    [SerializeField] private List<TextMeshProUGUI> carModelNames = new List<TextMeshProUGUI>();

    [SerializeField] public int[] indice;

    private void Start()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
            return;
        }

        Destroy(gameObject);

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
        ChangeCar(index);
        CarLog(index);
    }
    public void PrevCar(int index)
    {
        indice[index]--;

        if (indice[index] < 0)
        {
            indice[index] = carModels.Count - 1;
        }
        ChangeCar(index);
        CarLog(index);
    }

    public void ChangeCar(int index)
    {
        carImages[index].sprite = carSprites[indice[index]];
        carModelNames[index].text = carSprites[indice[index]].name;
    }

    public void CarLog(int index)
    {
        Logger.Log(indice[index].ToString());
        Logger.Log("Current car is " + carModels[indice[index]].ToString());
    }
}
