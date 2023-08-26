using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VersionPopUp : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject VersionChangeObject;
    public GameObject MainMenu;
    public int ShowVersion;
    public bool JustShowVersionPopUp = false;
    void Start()
    {
        ReStart();
    }
    
    public void ReStart()
    {
        if (JustShowVersionPopUp)
        {
            MainMenu.SetActive(false);
            VersionChangeObject.SetActive(true);
        } else
        {
            if (PlayerPrefs.HasKey("ShowVersion"))
            {
                ShowVersion = PlayerPrefs.GetInt("ShowVersion");
            }
            else
            {
                PlayerPrefs.SetInt("ShowVersion", 0);
                PlayerPrefs.Save();
                ShowVersion = 0;
            }

            if (ShowVersion == 0)
            {
                MainMenu.SetActive(false);
                VersionChangeObject.SetActive(true);
            }
            else
            {
                VersionChangeObject.SetActive(false);
            }
        }
        
    }

    public void CloseVersionChange()
    {
        VersionChangeObject.SetActive(false);
        MainMenu.SetActive(true);
        PlayerPrefs.SetInt("ShowVersion", 1);
        PlayerPrefs.Save();
        ShowVersion = 1;
    }


    public void ShowVersions()
    {
        MainMenu.SetActive(false);
        VersionChangeObject.SetActive(true);
    }
}
