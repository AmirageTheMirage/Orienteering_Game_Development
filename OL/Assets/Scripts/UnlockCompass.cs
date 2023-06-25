using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnlockCompass : MonoBehaviour
{

    public GameObject Player;
    public int UnlockNumber;
    public float Range;

    void Update()
    {
        float distance = Vector3.Distance(transform.position, Player.transform.position);

        if (distance < Range)
        {
            //Unlock
            UnlockComp(UnlockNumber);
            Debug.Log("Unlock");
        }
    }




    void UnlockComp(int CompName)
    {
        string currentname = "Compass_" + CompName.ToString();
        PlayerPrefs.SetInt(currentname, 1); //Unlock
        PlayerPrefs.Save();
    }

    
}
