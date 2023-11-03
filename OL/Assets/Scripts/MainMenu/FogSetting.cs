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
    string[] HowMuchFogText = new string[] { "No Fog", "Small", "Medium", "High", "Extreme"}; //Texts to it
    private AudioHandler AudioScript;
    void Start()
    {
        AudioScript = GameObject.Find("FullAudioHandler").GetComponent<AudioHandler>(); //Get Audio Script
        // HowMuchFog = 1;
        // PlayerPrefs.SetInt("HowMuchFog_Setting", HowMuchFog);
        MySlider.onValueChanged.AddListener(OnceValueIsChanged); //Non-Dynamic float
        HowMuchFog = 1;
        if (PlayerPrefs.HasKey("Fog_Setting"))
        {
            HowMuchFog = PlayerPrefs.GetInt("Fog_Setting");
            PlayerPrefs.Save();
            MySlider.value = (float)HowMuchFog;
            //  Debug.Log("You're a veteran aren't you?");

        }
        else //Non-existent
        {
            PlayerPrefs.SetInt("Fog_Setting", HowMuchFog);
            PlayerPrefs.Save();
            //  Debug.Log("First Time Playing?");


        }
        PreviewText.text = HowMuchFogText[HowMuchFog - 1];
    }


    private void OnceValueIsChanged(float value) //Then change float and play sound
    {
        AudioScript.ExtraSound();
        HowMuchFog = Mathf.RoundToInt(value);
        PlayerPrefs.SetInt("Fog_Setting", HowMuchFog);
        PlayerPrefs.Save();
        PreviewText.text = HowMuchFogText[HowMuchFog - 1];

    }



}
