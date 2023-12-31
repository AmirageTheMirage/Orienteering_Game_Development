using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class Menu_MapModeHandler : MonoBehaviour
{

    public int DropDownValue = 0; //0 = Forest 1, 1 = Forest 2
    public TMP_Dropdown ModeDropDown;
    public GameObject Forest1;
    public GameObject Forest2;
    public GameObject Maze1;
    public GameObject Forest3;
    public GameObject Martinsflue;
    public GameObject SelectDifficultyHideParent;
    private AudioHandler AudioScript;

    // Start is called before the first frame update
    void Start()
    {
        AudioScript = GameObject.Find("FullAudioHandler").GetComponent<AudioHandler>();
        SelectDifficultyHideParent.SetActive(true);
        if (PlayerPrefs.HasKey("MapDropdown_Setting")) //Check for PlayerPref
        {
            DropDownValue = PlayerPrefs.GetInt("MapDropdown_Setting");
            PlayerPrefs.Save();
            ModeDropDown.value = DropDownValue;

        }
        else
        {
            PlayerPrefs.SetInt("MapDropdown_Setting", DropDownValue);
            PlayerPrefs.Save();
            ModeDropDown.value = DropDownValue;


        }
        ModeDropDown.onValueChanged.AddListener(OnDropdownValueChanged);
        ActualizeMap();
    }

    
    private void OnDropdownValueChanged(int value) //Sound
    {
        DropDownValue = value;
        PlayerPrefs.SetInt("MapDropdown_Setting", DropDownValue);
        PlayerPrefs.Save();
        AudioScript.PlaySound("Tick2");
        ActualizeMap();
    }

    public void ActualizeMap() //This is for Selected Map
    {
        if (DropDownValue == 0) // Map 1 (Forest 1)
        {
            Forest1.SetActive(true);
            Forest2.SetActive(false);
            Maze1.SetActive(false);
            Forest3.SetActive(false);
            Martinsflue.SetActive(false);
            SelectDifficultyHideParent.SetActive(true);
        } else if (DropDownValue == 1) // Forest 2
        {
            Forest1.SetActive(false);
            Forest2.SetActive(true);
            Maze1.SetActive(false);
            Forest3.SetActive(false);
            Martinsflue.SetActive(false);
            SelectDifficultyHideParent.SetActive(true);
        } else if (DropDownValue == 2) // Maze
        {
            Forest1.SetActive(false);
            Forest2.SetActive(false);
            Maze1.SetActive(true);
            Forest3.SetActive(false);
            Martinsflue.SetActive(false);
            SelectDifficultyHideParent.SetActive(false);

        } else if (DropDownValue == 3) //Forest 3
        {
            Forest1.SetActive(false);
            Forest2.SetActive(false);
            Maze1.SetActive(false);
            Forest3.SetActive(true);
            Martinsflue.SetActive(false);
            SelectDifficultyHideParent.SetActive(true);
        }
        else if (DropDownValue == 4) //Martinsflue
        {
            Forest1.SetActive(false);
            Forest2.SetActive(false);
            Maze1.SetActive(false);
            Forest3.SetActive(false);
            Martinsflue.SetActive(true);
            SelectDifficultyHideParent.SetActive(true);
        }
    }
}
