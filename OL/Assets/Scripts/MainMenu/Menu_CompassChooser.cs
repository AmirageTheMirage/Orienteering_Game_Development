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
    public List<int> Unlocked = new List<int>();



    void Update()
    {

    }
    public void Reset()
    {
        CompassChosen = 1;
        PlayerPrefs.SetInt("Compass_Setting", CompassChosen);
        PlayerPrefs.SetInt("Compass_1", 1);
        PlayerPrefs.SetInt("Compass_2", 0);
        PlayerPrefs.SetInt("Compass_3", 0);
        PlayerPrefs.Save();
        ReStart();
    }
    void Start()
    {
        ReStart();
    }
    void ReStart()
    {
        PlayerPrefs.SetInt("Compass_1", 1);
        PlayerPrefs.Save();


        //THIS IS FOR EDITING ONLY:
        //PlayerPrefs.SetInt("Compass_1", 1);
        //PlayerPrefs.Save();
        //PlayerPrefs.SetInt("Compass_2", 0);
        //PlayerPrefs.Save();
        //PlayerPrefs.SetInt("Compass_3", 0);
        //PlayerPrefs.Save();
        //END



        //First Compass = AlwaysUnlocked


        for (int i = 1; i <= 3; i++) //Fetch from PlayerPrefs
        {
            string currentstringname = "Compass_" + i.ToString();
            if (PlayerPrefs.HasKey(currentstringname))
            {
                Debug.Log("PlaceHolder_Compass");

            }
            else
            {
                Debug.Log("PlayerPref Compass_" + i.ToString() + " is missing, making a new one.");
                PlayerPrefs.SetInt(currentstringname, 0);
                PlayerPrefs.Save();

            }
            Unlocked.Add(PlayerPrefs.GetInt(currentstringname));
            int currentnumber = PlayerPrefs.GetInt(currentstringname);

            GameObject currentCompass = null;
            if (i == 1)
            {
                currentCompass = Compass1;
            }
            else if (i == 2)
            {
                currentCompass = Compass2;
            }
            else if (i == 3)
            {
                currentCompass = Compass3;
            }

            if (currentnumber == 0)
            {
                Transform lockedTransform = currentCompass.transform.Find("Locked");
                if (lockedTransform != null)
                {
                    lockedTransform.gameObject.SetActive(true);
                }
                else
                {
                    Debug.Log("Wenn de Error chunnt isch scheisse, weu denne findet er 'Locked' ned. Gnau gno vom GameObject Compass_" + i.ToString());
                }
            }

        }









        if (PlayerPrefs.HasKey("Compass_Setting"))
        {

            CompassChosen = PlayerPrefs.GetInt("Compass_Setting");
            if (Unlocked[CompassChosen - 1] == 0) // If It's equipped but isn't unlocked
            {
                CompassChosen = 1;
                PlayerPrefs.SetInt("Compass_Setting", CompassChosen);
                PlayerPrefs.Save();

            }
        }
        else
        {
            PlayerPrefs.SetInt("Compass_Setting", CompassChosen); //By Default its gonna be 1
            PlayerPrefs.Save();
        }


        AssignHighlighter(CompassChosen);
    }

    public void ChooseComp(int Comp)
    {
        int CompMinusOne = Comp - 1;
        if (Unlocked[CompMinusOne] == 1) {
            CompassChosen = Comp;
            PlayerPrefs.SetInt("Compass_Setting", CompassChosen);
            PlayerPrefs.Save();
            Debug.Log(CompassChosen);
            AssignHighlighter(Comp);
        }
    }


    public void AssignHighlighter(int Comp)
    {
        if (Comp == 1)
        {
            Highlighter.transform.position = new Vector3(Compass1.transform.position.x, Compass1.transform.position.y, Compass1.transform.position.z);
        }
        else if (Comp == 2)
        {
            Highlighter.transform.position = new Vector3(Compass2.transform.position.x, Compass2.transform.position.y, Compass2.transform.position.z);
        }
        else if (Comp == 3)
        {
            Highlighter.transform.position = new Vector3(Compass3.transform.position.x, Compass3.transform.position.y, Compass3.transform.position.z);
        }
    }
}
