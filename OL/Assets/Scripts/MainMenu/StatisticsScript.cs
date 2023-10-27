using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

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
    public int PostsFound = 0;
    void Start()
    {
        //Check if Statistics Exist
        CheckPlayerPref("Statistics_EasyPosts");
        CheckPlayerPref("Statistics_MidPosts");
        CheckPlayerPref("Statistics_HardPosts");
        CheckPlayerPref("Statistics_GamesStarted");
        CheckPlayerPref("Statistics_GameCodesPlayed");
        CheckPlayerPref("Statistics_GameCodesCreated");
        CheckPlayerPref("Statistics_OrienteeringPerfect");
        CheckPlayerPref("Statistics_AchievementsCompleted");
        //StatisticsAnswerElement.text = "Hello" + "\n" + "World";






        //Assign PlayerPrefs
        PostsFound = PlayerPrefs.GetInt("Statistics_EasyPosts") + PlayerPrefs.GetInt("Statistics_MidPosts") + PlayerPrefs.GetInt("Statistics_HardPosts"); //Implemented automatically
        EasyPostsFound = PlayerPrefs.GetInt("Statistics_EasyPosts").ToString(); //In
        MidPostsFound  = PlayerPrefs.GetInt("Statistics_MidPosts").ToString(); //In
        HardPostsFound = PlayerPrefs.GetInt("Statistics_HardPosts").ToString(); //In
        GamesStarted = PlayerPrefs.GetInt("Statistics_GamesStarted").ToString(); //In
        GameCodesPlayed = PlayerPrefs.GetInt("Statistics_GameCodesPlayed").ToString(); //In
        GameCodesCreated = PlayerPrefs.GetInt("Statistics_GameCodesCreated").ToString(); //In
        OrienteeringPerfect = PlayerPrefs.GetInt("Statistics_OrienteeringPerfect").ToString(); //In
        AchievementsCompleted = PlayerPrefs.GetInt("Statistics_AchievementsCompleted").ToString();










        //Assign to text Element
        StatisticsAnswerElement.text = PostsFound.ToString() + "\n" + EasyPostsFound + "\n" + MidPostsFound + "\n" + HardPostsFound + "\n" + OrienteeringPerfect + "\n" + GamesStarted + "\n" + GameCodesCreated + "\n" + GameCodesPlayed + "\n" + AchievementsCompleted;
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
}
