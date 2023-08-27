using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TimeSlider : MonoBehaviour
{
    public Slider MySlider;
    public int TimeSetting;
    public TextMeshProUGUI PreviewText;
    private AudioHandler AudioScript;
    string[] TimeSettingText = new string[] { "Night", "Morning",  "Midday", "Afternoon", "Evening", "Night" };
    void Start()
    {
        AudioScript = GameObject.Find("FullAudioHandler").GetComponent<AudioHandler>();
        // TimeSetting = 1;
        // PlayerPrefs.SetInt("TimeSetting_Setting", TimeSetting);
        MySlider.onValueChanged.AddListener(OnceValueIsChanged);
        TimeSetting = 1;
        if (PlayerPrefs.HasKey("Time_Setting"))
        {
            TimeSetting = PlayerPrefs.GetInt("Time_Setting");
            PlayerPrefs.Save();
            MySlider.value = (float)TimeSetting;
          //  Debug.Log("You're a veteran aren't you?");
            
        }
        else
        {
            PlayerPrefs.SetInt("Time_Setting", TimeSetting);
            PlayerPrefs.Save();
          //  Debug.Log("First Time Playing?");
            
            
        }
       PreviewText.text = TimeSettingText[TimeSetting - 1];
    }


    private void OnceValueIsChanged(float value)
    {
        AudioScript.ExtraSound();
        TimeSetting = Mathf.RoundToInt(value);
        PlayerPrefs.SetInt("Time_Setting", TimeSetting);
        PlayerPrefs.Save();
        PreviewText.text = TimeSettingText[Mathf.RoundToInt(value / 4f - 1f)];
        
    }

    

}
