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
    string[] DifficultyText = new string[] { "Easy", "Middle", "Hard" }; //Names above the slider
    private AudioHandler AudioScript;
    void Start()
    {
        AudioScript = GameObject.Find("FullAudioHandler").GetComponent<AudioHandler>(); //To play Audio
        // Difficulty = 1;
        // PlayerPrefs.SetInt("Difficulty_Setting", Difficulty);
        MySlider.onValueChanged.AddListener(OnceValueIsChanged);
        Difficulty = 1;
        if (PlayerPrefs.HasKey("Difficulty_Setting")) //Difficulty exists
        {
            Difficulty = PlayerPrefs.GetInt("Difficulty_Setting");
            PlayerPrefs.Save();
            MySlider.value = (float)Difficulty;
          //  Debug.Log("You're a veteran aren't you?");
            
        }
        else
        {
            PlayerPrefs.SetInt("Difficulty_Setting", Difficulty); //if first time playing, make the PlayerPref
            PlayerPrefs.Save();
          //  Debug.Log("First Time Playing?");
            
            
        }
       PreviewText.text = DifficultyText[Difficulty - 1]; //-1 because it starts at 0
    }


    private void OnceValueIsChanged(float value)
    {
        AudioScript.ExtraSound(); //Play sound
        Difficulty = Mathf.RoundToInt(value);
        PlayerPrefs.SetInt("Difficulty_Setting", Difficulty); // Update Var
        PlayerPrefs.Save();
        PreviewText.text = DifficultyText[Difficulty - 1];
    }

    

}
