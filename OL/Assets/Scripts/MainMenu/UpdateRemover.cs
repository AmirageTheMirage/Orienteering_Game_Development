using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpdateRemover : MonoBehaviour
{
    public int Updated;
    public string VersionName;
    private string VersionNameCheck;
    public VersionPopUp VersionScript;
    
    void Start()
    {
        Updated = 0;
        if (PlayerPrefs.HasKey("GameVersion")){
            VersionNameCheck = PlayerPrefs.GetString("GameVersion");

        } else
        {
            VersionNameCheck = "";
            PlayerPrefs.SetString("GameVersion", VersionName); //Sets The Gameversion to the Current Version
            PlayerPrefs.Save();
        }

        if (VersionNameCheck == VersionName)
        {
            
            Updated = 1;
        } else
        {
            Updated = 0;
            PlayerPrefs.SetString("GameVersion", VersionName); //Sets The Gameversion to the Current Version
            PlayerPrefs.Save();
            Debug.Log("You just Updated");
        }
        




        if (Updated == 0) //If not yet Updated
        {
            PlayerPrefs.SetInt("ShowVersion", 0);
            PlayerPrefs.Save();
            VersionScript.ReStart();


            //For v.2.9:
            DeleteKey("Achievement_3"); //Easy!
            DeleteKey("Achievement_4"); //Hard Mode!
            DeleteKey("Achievement_6"); //Where Am I?

            
        }
    }
    public void DeleteKey(string Key)
    {
        if (PlayerPrefs.HasKey(Key))
        {
            PlayerPrefs.DeleteKey(Key);
            PlayerPrefs.Save();
            Debug.Log("Deleted PlayerPref: " + Key);
        }
    }
    
}
