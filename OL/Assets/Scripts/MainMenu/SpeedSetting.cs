using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SpeedSetting : MonoBehaviour
{
    public Slider MySlider;
    public int SpeedVar;
    public int ActualSpeed;
    public TextMeshProUGUI PreviewText;
    string[] SpeedVarText = new string[] { "Slow", "Normal", "Fast", "Faster", "Very Fast"}; //Texts to it
    private AudioHandler AudioScript;
    void Start()
    {
        AudioScript = GameObject.Find("FullAudioHandler").GetComponent<AudioHandler>(); //Get Audio Script
        // SpeedVar = 1;
        // PlayerPrefs.SetInt("SpeedVar_Setting", SpeedVar);
        MySlider.onValueChanged.AddListener(OnceValueIsChanged); //Non-Dynamic float
        SpeedVar = 2;
        ActualSpeed = 12;
        //SPEED: 10 = Slow, 12 = Normal, 14 = Fast, 16 = Faster, 19 = Very Fast
        if (PlayerPrefs.HasKey("Speed_Setting"))
        {
            ActualSpeed = PlayerPrefs.GetInt("Speed_Setting");
            PlayerPrefs.Save();
            if (ActualSpeed <= 10)
            {
                SpeedVar = 1;
            }
            else if (ActualSpeed == 12)
            {
                SpeedVar = 2;
            }
            else if (ActualSpeed == 14)
            {
                SpeedVar = 3;
            }
            else if (ActualSpeed == 16)
            {
                SpeedVar = 4;
            }
            else if (ActualSpeed == 19)
            {
                SpeedVar = 5;
            }
            MySlider.value = (float)SpeedVar;
            //  Debug.Log("You're a veteran aren't you?");

        }
        else //Non-existent
        {
            PlayerPrefs.SetInt("Speed_Setting", ActualSpeed);
            PlayerPrefs.Save();
            //  Debug.Log("First Time Playing?");


        }
        PreviewText.text = SpeedVarText[SpeedVar - 1];
    }


    private void OnceValueIsChanged(float value) //Then change float and play sound
    {
        AudioScript.ExtraSound();
        SpeedVar = Mathf.RoundToInt(value);
        if (SpeedVar <= 1)
        {
            ActualSpeed = 10;
        } else if (SpeedVar == 2)
        {
            ActualSpeed = 12;
        }
        else if (SpeedVar == 3)
        {
            ActualSpeed = 14;
        }
        else if (SpeedVar == 4)
        {
            ActualSpeed = 16;
        }
        else if (SpeedVar == 5)
        {
            ActualSpeed = 19;
        }
        PlayerPrefs.SetInt("Speed_Setting", ActualSpeed);
        PlayerPrefs.Save();
        PreviewText.text = SpeedVarText[SpeedVar - 1];
        Debug.Log(ActualSpeed);
        Debug.Log(SpeedVar);
    }



}
