using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class FogSetting : MonoBehaviour
{
    public Slider MySlider;
    public int HowMuchFog;
    public TextMeshProUGUI PreviewText;
    string[] HowMuchFogText = new string[] { "No Fog", "Small", "Medium", "High", "Extreme"};
    void Start()
    {

        // HowMuchFog = 1;
        // PlayerPrefs.SetInt("HowMuchFog_Setting", HowMuchFog);
        MySlider.onValueChanged.AddListener(OnceValueIsChanged);
        HowMuchFog = 1;
        if (PlayerPrefs.HasKey("Fog_Setting"))
        {
            HowMuchFog = PlayerPrefs.GetInt("Fog_Setting");
            PlayerPrefs.Save();
            MySlider.value = (float)HowMuchFog;
            //  Debug.Log("You're a veteran aren't you?");

        }
        else
        {
            PlayerPrefs.SetInt("Fog_Setting", HowMuchFog);
            PlayerPrefs.Save();
            //  Debug.Log("First Time Playing?");


        }
        PreviewText.text = HowMuchFogText[HowMuchFog - 1];
    }


    private void OnceValueIsChanged(float value)
    {
        HowMuchFog = Mathf.RoundToInt(value);
        PlayerPrefs.SetInt("Fog_Setting", HowMuchFog);
        PlayerPrefs.Save();
        PreviewText.text = HowMuchFogText[HowMuchFog - 1];

    }



}
