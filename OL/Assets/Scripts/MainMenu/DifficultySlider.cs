using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DifficultySlider : MonoBehaviour
{
    public Slider MySlider;
    public int Difficulty;
    public TextMeshProUGUI PreviewText;
    string[] DifficultyText = new string[] { "Easy", "Middle", "Hard" };
    private AudioHandler AudioScript;
    void Start()
    {
        AudioScript = GameObject.Find("FullAudioHandler").GetComponent<AudioHandler>();
        // Difficulty = 1;
        // PlayerPrefs.SetInt("Difficulty_Setting", Difficulty);
        MySlider.onValueChanged.AddListener(OnceValueIsChanged);
        Difficulty = 1;
        if (PlayerPrefs.HasKey("Difficulty_Setting"))
        {
            Difficulty = PlayerPrefs.GetInt("Difficulty_Setting");
            PlayerPrefs.Save();
            MySlider.value = (float)Difficulty;
          //  Debug.Log("You're a veteran aren't you?");
            
        }
        else
        {
            PlayerPrefs.SetInt("Difficulty_Setting", Difficulty);
            PlayerPrefs.Save();
          //  Debug.Log("First Time Playing?");
            
            
        }
       PreviewText.text = DifficultyText[Difficulty - 1];
    }


    private void OnceValueIsChanged(float value)
    {
        AudioScript.ExtraSound();
        Difficulty = Mathf.RoundToInt(value);
        PlayerPrefs.SetInt("Difficulty_Setting", Difficulty);
        PlayerPrefs.Save();
        PreviewText.text = DifficultyText[Difficulty - 1];
    }

    

}
