using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AssignCompass : MonoBehaviour
{
    public int CompassChosen;
    public GameObject MySelf;

    void Start()
    {
        // PlayerPrefs.SetInt("Compass_Setting", CompassChosen);
        // PlayerPrefs.Save();
        CompassChosen = PlayerPrefs.GetInt("Compass_Setting"); //Get Compass chosen in MainMenu
        Debug.Log(CompassChosen);
        string childName = CompassChosen.ToString(); //Make int to string
        Transform childTransform = MySelf.transform.Find(childName); //Find child named after this str.

        if (childTransform != null) //If any object is found
        {
            GameObject child = childTransform.gameObject;
            child.SetActive(true); //Then set this compass true, others stay hidden
        }
        else
        {
            Debug.LogError("Child object with name " + childName + " not found!"); //If error in decision
        }
    }
}
