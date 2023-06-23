using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Menu_CompassChooser : MonoBehaviour
{
    public int CompassChosen = 1;
    public GameObject Highlighter;
    public GameObject Compass1;
    public GameObject Compass2;
    public GameObject Compass3;

    void Start()
    {
        if (PlayerPrefs.HasKey("Compass_Setting"))
        {
            CompassChosen = PlayerPrefs.GetInt("Compass_Setting");
            PlayerPrefs.Save();
        }
        else
        {
            PlayerPrefs.SetInt("Compass_Setting", CompassChosen);
            PlayerPrefs.Save();
        }

    }
        public void ChooseComp(int Comp)

    {
        CompassChosen = Comp;
        PlayerPrefs.SetInt("Compass_Setting", CompassChosen);
        PlayerPrefs.Save();
        Debug.Log(CompassChosen);
        if (Comp == 1)
        {
            Highlighter.transform.position = new Vector3(Compass1.transform.position.x, Compass1.transform.position.y, Compass1.transform.position.z);
        } else if (Comp == 2)
        {
            Highlighter.transform.position = new Vector3(Compass2.transform.position.x, Compass2.transform.position.y, Compass2.transform.position.z);
        } else if (Comp == 3)
        {
            Highlighter.transform.position = new Vector3(Compass3.transform.position.x, Compass3.transform.position.y, Compass3.transform.position.z);
        }
        

    }

}
