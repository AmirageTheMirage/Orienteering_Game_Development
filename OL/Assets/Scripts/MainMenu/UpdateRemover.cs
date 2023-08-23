using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpdateRemover : MonoBehaviour
{
    
    void Start()
    {
        DeleteKey("Achievement_3"); //Easy!
        DeleteKey("Achievement_4"); //Hard Mode!
        DeleteKey("Achievement_6"); //Where Am I?
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
