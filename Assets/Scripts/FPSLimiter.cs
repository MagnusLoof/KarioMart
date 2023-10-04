using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class FPSLimiter : MonoBehaviour
{
    [SerializeField] private bool fpsCap = false;
    [SerializeField] private Slider fpsSlider;
    [SerializeField] private TextMeshProUGUI sliderText;
    [SerializeField] private Toggle fpsToggle;

    public void CapFPS()
    {
        fpsCap = fpsToggle.isOn;
        ChangeFpsCap();
    }

    public void ChangeFpsCap()
    {
        sliderText.text = fpsSlider.value.ToString();

        if(fpsCap)
        {
            Application.targetFrameRate = (int)fpsSlider.value;
        }
        else
        {
            Application.targetFrameRate = -1;
        }
    }
}
