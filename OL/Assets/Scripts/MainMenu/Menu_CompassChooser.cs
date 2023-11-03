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
    public GameObject Compass4;
    public List<int> Unlocked = new List<int>();
    private AudioHandler AudioScript;



    void Update()
    {

    }
    public void Reset()
    {
        CompassChosen = 1;
        PlayerPrefs.SetInt("Compass_Setting", CompassChosen); //When reset, set 1st Compass to chosen
        PlayerPrefs.SetInt("Compass_1", 1);
        PlayerPrefs.SetInt("Compass_2", 0);
        PlayerPrefs.SetInt("Compass_3", 0);
        PlayerPrefs.SetInt("Compass_4", 0);
        PlayerPrefs.Save();
        ReStart();
    }
    void Start()
    {
        AudioScript = GameObject.Find("FullAudioHandler").GetComponent<AudioHandler>();
        
        //PlayerPrefs.SetInt("Compass_4", 1);
        //PlayerPrefs.Save();
        ReStart();

    }
    void ReStart()
    {
        Unlocked.Clear();
        //Debug.Log(Unlocked[0]);
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


        for (int i = 1; i <= 4; i++) //Fetch from PlayerPrefs, Change the 4 if I add more compasses
        {
            string currentstringname = "Compass_" + i.ToString();
            if (PlayerPrefs.HasKey(currentstringname))
            {
                Debug.Log("PlaceHolder_Compass");

            }
            else
            {
                Debug.Log("PlayerPref Compass_" + i.ToString() + " is missing, making a new one.");
                PlayerPrefs.SetInt(currentstringname, 0); //If the Compass Setting is missing, make a new Setting
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
            } else if (i == 4)
            {
                currentCompass = Compass4;
            } else
            {
                Debug.Log("There is no instance of i = " + i);
            }

            if (currentnumber == 0)
            {
                Transform lockedTransform = currentCompass.transform.Find("Locked");
                if (lockedTransform != null)
                {
                    lockedTransform.gameObject.SetActive(true); //Show Locked Sign if the Compass is not yet Unlocked
                }
                else
                {
                    Debug.Log("Wenn de Error chunnt isch scheisse, weu denne findet er 'Locked' ned. Gnau gno vom GameObject Compass_" + i.ToString());
                }
            }

        }





        
       // Debug.Log(Unlocked[2].ToString()); // => 1
       // Debug.Log(PlayerPrefs.GetInt("Compass_3")); // => 0, means its a Problem of the unlocked assignment.



        if (PlayerPrefs.HasKey("Compass_Setting")) //So in case the player loads with a compass that isnt unlocked, then automatically go back to Compass Number 1
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
            AudioScript.PlaySound("Select3");
            Debug.Log("Compass " + Comp + " is unlocked!");
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
        } else if (Comp == 4)
        {
            Highlighter.transform.position = new Vector3(Compass4.transform.position.x, Compass4.transform.position.y, Compass4.transform.position.z);
            
        }
    }
}
