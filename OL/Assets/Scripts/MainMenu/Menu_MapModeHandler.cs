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

    // Start is called before the first frame update
    void Start()
    {
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
        ActualizeMap();
    }

    public void ActualizeMap()
    {
        if (DropDownValue == 0)
        {
            Forest1.SetActive(true);
            Forest2.SetActive(false);
            Maze1.SetActive(false);
        } else if (DropDownValue == 1)
        {
            Forest1.SetActive(false);
            Forest2.SetActive(true);
            Maze1.SetActive(false);
        } else
        {
            Forest1.SetActive(false);
            Forest2.SetActive(false);
            Maze1.SetActive(true);
        }
    }
}
