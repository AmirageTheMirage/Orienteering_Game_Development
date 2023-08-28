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
    private GameObject DirectLight;
    private Light SunLightComponent;
    public Color EveningColor;
    public bool ChangeInMainMenu = false;
    string[] TimeSettingText = new string[] { "Night", "Morning",  "Midday", "Afternoon", "Evening", "Night" };
    void Start()
    {
        AudioScript = GameObject.Find("FullAudioHandler").GetComponent<AudioHandler>();
        DirectLight = GameObject.Find("DirectionalLight");
        SunLightComponent = DirectLight.GetComponent<Light>();
        // TimeSetting = 1;
        // PlayerPrefs.SetInt("TimeSetting_Setting", TimeSetting);

        TimeSetting = 12;
        if (PlayerPrefs.HasKey("Time_Setting"))
        {
            TimeSetting = PlayerPrefs.GetInt("Time_Setting");
            
            
          //  Debug.Log("You're a veteran aren't you?");
            
        }
        else
        {
            PlayerPrefs.SetInt("Time_Setting", TimeSetting);
            PlayerPrefs.Save();
          //  Debug.Log("First Time Playing?");
            
            
        }
        Debug.Log("Time Setting: " + TimeSetting);
        if (TimeSetting < 1)
        {
            TimeSetting = 1;
        } else if (TimeSetting > 24)
        {
            TimeSetting = 24;
        }
        MySlider.value = (float)TimeSetting;
        ChangeText(TimeSetting);
        MySlider.onValueChanged.AddListener(OnceValueIsChanged);
        AssignColor();
    }


    private void OnceValueIsChanged(float value)
    {
        AudioScript.ExtraSound();
        TimeSetting = Mathf.RoundToInt(value);
        PlayerPrefs.SetInt("Time_Setting", TimeSetting);
        PlayerPrefs.Save();
        ChangeText(Mathf.RoundToInt(value));
        AssignColor();
        
    }



    private void ChangeText(int Time)
    {
        //PreviewText.text = TimeSettingText[Mathf.RoundToInt(value - 1f)];
        if (Time <= 11)
        {
            PreviewText.text = Time.ToString() + ":00 AM"; //Normal AM
        }
        else if (Time == 24)
        {
            Time = Time - 12;
            PreviewText.text = Time.ToString() + ":00 AM"; //12 AM
        }
        else if (Time == 12)
        {
            PreviewText.text = Time.ToString() + ":00 PM"; //12PM

        }
        else if (Time >= 12)
        {
            Time = Time - 12;
            PreviewText.text = Time.ToString() + ":00 PM";//Normal PM
        }
    }

    private void AssignColor()
    {
        if (ChangeInMainMenu)
        {
            //Debug.Log("AssignColor got called");
            DirectLight.transform.eulerAngles = new Vector3(15f * TimeSetting - 90f, 90f, 0f); //So it's in east
            DirectLight.SetActive(true);
            if (TimeSetting <= 7 || TimeSetting >= 16) //If Evening
            {

                if (TimeSetting <= 5 || TimeSetting >= 19)
                {
                    DirectLight.SetActive(false);
                }
                else
                {

                    SunLightComponent.color = EveningColor;
                }
            }
        }
    }

}
