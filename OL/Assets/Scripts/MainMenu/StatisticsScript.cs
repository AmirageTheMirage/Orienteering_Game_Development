using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class StatisticsScript : MonoBehaviour
{

    public TextMeshProUGUI StatisticsAnswerElement;
    public string EasyPostsFound = "/";
    public string MidPostsFound = "/";
    public string HardPostsFound = "/";
    public string GamesStarted = "/";
    public string GameCodesPlayed = "/";
    public string GameCodesCreated = "/";
    public string OrienteeringPerfect = "/";
    public string AchievementsCompleted = "/";
    public string OrienteeringGamesPlayed = "/";
    public string FirstVersionPlayed = "/";
    public string CalculatedAvgTimePost = "/";
    public string CalculatedAvgTimeOrient = "/";
    public int TimerPostNumber = 0;
    public int TimerPostTimes = 0;
    public int TimerOrientNumber = 0;
    public int TimerOrientTimes = 0;
    public int PostsFound = 0;
    public float OrienteeringAccuracy = 0f;
    public float OrienteeringAllScoresAdded = 0f;
    public bool RecordStats;
    public Toggle RecordToggle;
    public UpdateRemover VersionScript;
    public void CheckAllPlayerPrefs()
    {
        //Debug.Log(PlayerPrefs.GetInt("Statistics_TimerOrientNumber"));
        CheckPlayerPref("Statistics_EasyPosts");
        CheckPlayerPref("Statistics_MidPosts");
        CheckPlayerPref("Statistics_HardPosts");
        CheckPlayerPref("Statistics_GamesStarted");
        CheckPlayerPref("Statistics_GameCodesPlayed");
        CheckPlayerPref("Statistics_GameCodesCreated");
        CheckPlayerPref("Statistics_OrienteeringPerfect");
        CheckPlayerPref("Statistics_AchievementsCompleted");
        CheckPlayerPref("Statistics_OrienteeringGamesPlayed");
        CheckPlayerPref("Statistics_OrienteeringAddedTogether");
        CheckPlayerPref("Statistics_TimerPostNumber");
        CheckPlayerPref("Statistics_TimerPostTimes");
        CheckPlayerPref("Statistics_TimerOrientNumber");
        CheckPlayerPref("Statistics_TimerOrientTimes");
    }
    void Start()
    {
        //Check if Statistics Exist
        if (PlayerPrefs.HasKey("Statistics_Record"))
        {
            if (PlayerPrefs.GetInt("Statistics_Record") == 0)
            {
                RecordStats = false;
            } else
            {
                RecordStats = true;
            }
            
            Debug.Log("Statistics: Player Pref Statistics_Record exists.");

        }
        else
        {
            RecordStats = true;
            PlayerPrefs.SetInt("Statistics_Record", 1); //Beginning of Game
            PlayerPrefs.Save();
            Debug.Log("Statistics: PlayerPref named Statistics_Record was created.");
        }
        RecordToggle.isOn = RecordStats;


        //Join Version
        if (PlayerPrefs.HasKey("Statistics_FirstVersionPlayed")) //CURRENTLY SCRAPPED / ON HOLD!
        {
            FirstVersionPlayed = PlayerPrefs.GetString("Statistics_FirstVersionPlayed");
        } else
        {
            FirstVersionPlayed = VersionScript.VersionName;
            PlayerPrefs.SetString("Statistics_FirstVersionPlayed", FirstVersionPlayed);
            PlayerPrefs.Save();
        }

        //Check for all PlayerPrefs. Might lag? Have to test

        CheckAllPlayerPrefs();
        //StatisticsAnswerElement.text = "Hello" + "\n" + "World";



       // PlayerPrefs.SetInt("Statistics_OrienteeringGamesPlayed", 0); //FOR DEBUG ONLY


        //Assign PlayerPrefs
        EasyPostsFound = PlayerPrefs.GetInt("Statistics_EasyPosts").ToString(); //In
        MidPostsFound  = PlayerPrefs.GetInt("Statistics_MidPosts").ToString(); //In
        HardPostsFound = PlayerPrefs.GetInt("Statistics_HardPosts").ToString(); //In
        GamesStarted = PlayerPrefs.GetInt("Statistics_GamesStarted").ToString(); //In
        GameCodesPlayed = PlayerPrefs.GetInt("Statistics_GameCodesPlayed").ToString(); //In
        GameCodesCreated = PlayerPrefs.GetInt("Statistics_GameCodesCreated").ToString(); //In
        OrienteeringPerfect = PlayerPrefs.GetInt("Statistics_OrienteeringPerfect").ToString(); //In
        AchievementsCompleted = PlayerPrefs.GetInt("Statistics_AchievementsCompleted").ToString(); //In
        OrienteeringGamesPlayed = PlayerPrefs.GetInt("Statistics_OrienteeringGamesPlayed").ToString(); //In
        OrienteeringAllScoresAdded = PlayerPrefs.GetInt("Statistics_OrienteeringAddedTogether"); //In
        TimerPostNumber = PlayerPrefs.GetInt("Statistics_TimerPostNumber"); //In
        TimerPostTimes = PlayerPrefs.GetInt("Statistics_TimerPostTimes"); //In
        TimerOrientNumber = PlayerPrefs.GetInt("Statistics_TimerOrientNumber"); //In
        TimerOrientTimes = PlayerPrefs.GetInt("Statistics_TimerOrientTimes"); //In
        


        //Calculate Statistics depending on PlayerPrefs
        PostsFound = PlayerPrefs.GetInt("Statistics_EasyPosts") + PlayerPrefs.GetInt("Statistics_MidPosts") + PlayerPrefs.GetInt("Statistics_HardPosts"); //Implemented automatically
        if (PlayerPrefs.GetInt("Statistics_OrienteeringGamesPlayed") == 0)
        {
            OrienteeringAccuracy = 0f;
        }
        else
        {
            OrienteeringAccuracy = (400f - (float)PlayerPrefs.GetInt("Statistics_OrienteeringAddedTogether") / (float)PlayerPrefs.GetInt("Statistics_OrienteeringGamesPlayed")) /4f; //Durchschnitt durch 3
            if (OrienteeringAccuracy < 0f)
            {
                OrienteeringAccuracy = 0f;
            }
        }

        //CalculatedAvgTimePost:
        if (TimerPostNumber == 0 || TimerPostTimes == 0)
        {
            CalculatedAvgTimePost = "0.00s";
        } else
        {
            CalculatedAvgTimePost = (Mathf.Round((float)TimerPostNumber / (float)TimerPostTimes) / 100f).ToString();
            CalculatedAvgTimePost = CalculatedAvgTimePost + "s";
        }
        //CalculatedAvgTimeOrient
        if (TimerOrientNumber == 0 || TimerOrientTimes == 0)
        {
            CalculatedAvgTimeOrient = "0.00s";
        }
        else
        {
            CalculatedAvgTimeOrient = (Mathf.Round((float)TimerOrientNumber / (float)TimerOrientTimes) / 100f).ToString();
            CalculatedAvgTimeOrient = CalculatedAvgTimeOrient + "s";
        }







        //Assign to text Element
        StatisticsAnswerElement.text = GamesStarted + "\n" + PostsFound.ToString() + "\n" + EasyPostsFound + "\n" + MidPostsFound + "\n" + HardPostsFound + "\n" + OrienteeringGamesPlayed + "\n" + OrienteeringPerfect + "\n" + Mathf.RoundToInt(OrienteeringAccuracy).ToString() + "%"  + "\n" + GameCodesCreated + "\n" + GameCodesPlayed + "\n" + AchievementsCompleted + "\n" + CalculatedAvgTimePost + "\n" + CalculatedAvgTimeOrient;
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void CheckPlayerPref(string PlayerPrefName)
    {
        if (PlayerPrefs.HasKey(PlayerPrefName))
        {
            Debug.Log("Statistics: Player Pref " + PlayerPrefName + " exists.");

        } else
        {
            PlayerPrefs.SetInt(PlayerPrefName, 0);
            PlayerPrefs.Save();
            Debug.Log("Statistics: PlayerPref named " + PlayerPrefName + " was created.");
        }
    }


    public void ToggleRecord(bool state) //Simple Toggle
    {
        RecordStats = state;
        if (state == true)
        {
            PlayerPrefs.SetInt("Statistics_Record", 1);
        } else
        {
            PlayerPrefs.SetInt("Statistics_Record", 0);
        }
        PlayerPrefs.Save();
    }
}
