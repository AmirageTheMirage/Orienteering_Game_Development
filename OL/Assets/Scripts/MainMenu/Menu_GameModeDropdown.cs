using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Menu_GameModeDropdown : MonoBehaviour
{
    public int DropDownValue = 0;
    public TMP_Dropdown ModeDropDown;
    public GameObject DifficultySlider;
    private AudioHandler AudioScript;
    void Start()
    {
        AudioScript = GameObject.Find("FullAudioHandler").GetComponent<AudioHandler>();
        DifficultySlider.SetActive(true);
        if (PlayerPrefs.HasKey("ModeDropdown_Setting")) //Get Mode, see if it exists
        {
            DropDownValue = PlayerPrefs.GetInt("ModeDropdown_Setting");
            PlayerPrefs.Save();
            ModeDropDown.value = DropDownValue;

        }
        else
        {
            PlayerPrefs.SetInt("ModeDropdown_Setting", DropDownValue);
            PlayerPrefs.Save();
            ModeDropDown.value = DropDownValue;


        }
        ModeDropDown.onValueChanged.AddListener(OnDropdownValueChanged);
        if (DropDownValue == 0)
        {
            DifficultySlider.SetActive(true);
        }
        else
        {
            DifficultySlider.SetActive(false);
        }
    }

    private void OnDropdownValueChanged(int value)
    {
        AudioScript.ExtraSound();
        DropDownValue = value;
        PlayerPrefs.SetInt("ModeDropdown_Setting", DropDownValue);
        PlayerPrefs.Save();
        if (value == 0) //Show Difficulty only when PostAssign Mode
        {
            DifficultySlider.SetActive(true);
        } else
        {
            DifficultySlider.SetActive(false);
        }
    }
    }
