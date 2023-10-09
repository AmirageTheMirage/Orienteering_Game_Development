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
    public GameObject SelectDifficultyHideParent;
    private AudioHandler AudioScript;

    // Start is called before the first frame update
    void Start()
    {
        AudioScript = GameObject.Find("FullAudioHandler").GetComponent<AudioHandler>();
        SelectDifficultyHideParent.SetActive(true);
        if (PlayerPrefs.HasKey("MapDropdown_Setting"))
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

    // Update is called once per frame
    private void OnDropdownValueChanged(int value)
    {
        DropDownValue = value;
        PlayerPrefs.SetInt("MapDropdown_Setting", DropDownValue);
        PlayerPrefs.Save();
        AudioScript.PlaySound("Tick2");
        ActualizeMap();
    }

    public void ActualizeMap()
    {
        if (DropDownValue == 0) // Map 1 (Forest 1)
        {
            Forest1.SetActive(true);
            Forest2.SetActive(false);
            Maze1.SetActive(false);
            Forest3.SetActive(false);
            SelectDifficultyHideParent.SetActive(true);
        } else if (DropDownValue == 1) // Forest 2
        {
            Forest1.SetActive(false);
            Forest2.SetActive(true);
            Maze1.SetActive(false);
            Forest3.SetActive(false);
            SelectDifficultyHideParent.SetActive(true);
        } else if (DropDownValue == 2) // Maze
        {
            Forest1.SetActive(false);
            Forest2.SetActive(false);
            Maze1.SetActive(true);
            Forest3.SetActive(false);
            SelectDifficultyHideParent.SetActive(false);

        } else
        {
            Forest1.SetActive(false);
            Forest2.SetActive(false);
            Maze1.SetActive(false);
            Forest3.SetActive(true);
            SelectDifficultyHideParent.SetActive(true);
        }
    }
}
