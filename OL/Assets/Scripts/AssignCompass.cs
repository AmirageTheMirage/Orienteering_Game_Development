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
        CompassChosen = PlayerPrefs.GetInt("Compass_Setting");
        Debug.Log(CompassChosen);
        string childName = CompassChosen.ToString();
        Transform childTransform = MySelf.transform.Find(childName);

        if (childTransform != null)
        {
            GameObject child = childTransform.gameObject;
            child.SetActive(true);
        }
        else
        {
            Debug.LogError("Child object with name " + childName + " not found!");
        }
    }
}
