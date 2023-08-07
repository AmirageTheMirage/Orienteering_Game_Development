using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameCode_Make : MonoBehaviour
{
    // Start is called before the first frame update
    public int MapPart;
    public int ModePart;
    public int TimePart;
    public int FogPart;
    public int DifficultyPart;
    public int StartPostPart;
    public int EndPostPart;
    public int OrienteeringXPart;
    public int OrienteeringYPart;
    public int OrienteeringZPart;
    [Space]
    public string Code;
    void Start()
    {
        // So we'll need: (Shopping List hahhhaaaaaa)
        // 1x Coffee, 1x Milk, 1x Maturaarbeit done in under 2'000'000hours (impossible)
        // No but for real:
        // Index of Scene, Map as an Index, Mode as an Index, Time Setting (2 Digits), Fog Setting
        // Map: MainMenu = 0, Forest 1 = 1, Forest 2 = 2, Maze 1 = 3
        // Mode: PostSearch = 1, Orienteering = 2
        // Time Setting: 01 to 24
        // Fog Setting: 1 = No Fog to Max Fog = 5
        MakeNewGameCode();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void MakeNewGameCode()
    {
        //PlayerPrefs.SetInt("UseCode_Setting", 0);
        //PlayerPrefs.SetInt("ModePart_Code", 0); // Implemented
        //PlayerPrefs.SetInt("TimePart_Code", 0);
        //PlayerPrefs.SetInt("FogPart_Code", 0);
        //PlayerPrefs.Save();
        // Get Map:
        
        if (PlayerPrefs.GetInt("UseCode_Setting") == 1)
        {
            Code = PlayerPrefs.GetString("ActualCode_Code"); //Just reuse the old Code

        }
        else
        {
            MapPart = SceneManager.GetActiveScene().buildIndex;
            //Get Mode:
            ModePart = PlayerPrefs.GetInt("ModeDropdown_Setting");
            //Get Time:
            TimePart = PlayerPrefs.GetInt("Time_Setting");
            //IMPORTANT: Make it two digits
            //Get Fog:
            FogPart = PlayerPrefs.GetInt("Fog_Setting");
            //Get Difficulty
            DifficultyPart = PlayerPrefs.GetInt("Difficulty_Setting");
            //Get Start
            StartPostPart = PlayerPrefs.GetInt("StartPost_Code");
            EndPostPart = PlayerPrefs.GetInt("EndPost_Code");
            OrienteeringXPart = PlayerPrefs.GetInt("OrienteeringX_Code");
            OrienteeringYPart = PlayerPrefs.GetInt("OrienteeringY_Code");
            OrienteeringZPart = PlayerPrefs.GetInt("OrienteeringZ_Code");
            string TimePartString = TimePart.ToString();
            if (TimePartString.Length == 1) //Only 1 Digit
            {
                TimePartString = "0" + TimePartString;
            }
            string OrienteeringYPartString = OrienteeringYPart.ToString();
            if (OrienteeringYPartString.Length == 1)
            {
                OrienteeringYPartString = "00" + OrienteeringYPartString;

            } else if (OrienteeringYPartString.Length == 2)
            {
                OrienteeringYPartString = "0" + OrienteeringYPartString;

            }
            if (StartPostPart < 100) //So that if not playing this mode the rest of the code is still working
            {
                StartPostPart = 111;
            }
            if (EndPostPart < 100)
            {
                EndPostPart = 111;
            }
            if (OrienteeringXPart < 100)
            {
                PlayerPrefs.SetInt("OrienteeringX_Code", 111);
                
            }
            
            if (OrienteeringZPart < 100)
            {
                PlayerPrefs.SetInt("OrienteeringZ_Code", 111);
            }


            
            Code = MapPart.ToString() + ModePart.ToString() + TimePartString + FogPart.ToString() + DifficultyPart.ToString() + StartPostPart.ToString() + EndPostPart.ToString() + OrienteeringXPart.ToString() + OrienteeringYPartString + OrienteeringZPart.ToString();
        }

        
        PlayerPrefs.SetString("ActualCode_Code", Code);
        PlayerPrefs.Save();
        Debug.Log(Code);
    }
}