using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CollisionFinisher : MonoBehaviour
{


    [SerializeField] PostAssign IHave;
    public bool touching = false;
    public int numberofendposten = 0;
    public int MyNameAsInt = 0;
    private bool alreadyfading = false;
    private float AfterFP = 0f;
    public GameObject Loading;
    private int MapSettings;
    private int Difficulty;
    public AchievementHandler AchievScript;
    public IsMapMaze IsMapMazeScript;
    private bool IsMaze;
    private AudioHandler AudioScript;

    public GameObject Fader;
    private float FP = 1f; //FP = FaderPercent
    public bool StartFade = false;
    private int UsingCode = 0;

    public float Speed = 2f;
    public bool ShowLoading = true;
    public int CompassChosen;
    public TimerScript TimeScript;
    void Start()
    {
        CompassChosen = PlayerPrefs.GetInt("Compass_Setting");
        AudioScript = GameObject.Find("FullAudioHandler").GetComponent<AudioHandler>(); //Get Audio Script
        
        IsMaze = IsMapMazeScript.IsMaze;
        // Debug.Log(IsMaze);
        if (PlayerPrefs.GetInt("UseCode_Setting") == 1)
        {
            Difficulty = PlayerPrefs.GetInt("DifficultyPart_Code");
        }
        else
        {
            Difficulty = PlayerPrefs.GetInt("Difficulty_Setting");
        }
        MyNameAsInt = int.Parse(gameObject.name);
        numberofendposten = IHave.endposten;
        StartFade = false;
        
    }
   
    void OnCollisionEnter(Collision collision) //OnCollision (new Type)

    {

        


        if (MyNameAsInt == numberofendposten && alreadyfading == false && AchievScript.FramesInScene > 19)
        {
            TimeScript.TimerRunning = false;
            if (AchievScript.SceneryInt == 1 || AchievScript.SceneryInt == 2) //Mastery Progress
            {
                AchievScript.Mastery(AchievScript.SceneryInt);
                Debug.Log("Sent out Mastery Request for " + AchievScript.SceneryInt);
            }
            //if (IsMaze == false)
            //{
            //    if (Difficulty == 1)
            //    {
            //        AchievScript.UnlockAchievement(3);
            //    }
            //    else if (Difficulty == 3)
            //    {
            //        AchievScript.UnlockAchievement(4); //Deleted ones
            //    }
            //}

            if (IsMaze == false )
            {
                if (Difficulty == 3 && CompassChosen == 0)
                {
                    AchievScript.UnlockAchievement(13); //Why would you not use a Compass... ?
                    
                }
            }
            alreadyfading = true;
            touching = true;
            Fader.SetActive(true);
            
            AudioScript.PlaySound("Select2");
            FP = 0f;
            //STATISTICS:
            if (PlayerPrefs.GetInt("Statistics_Record") == 1) //Do Statistics for Easy, Mid, and hard posts
            {
                if (IsMaze)
                {
                    Difficulty = 3;
                }
                if (Difficulty == 1) //Easy
                {
                    int StatisticVariable = PlayerPrefs.GetInt("Statistics_EasyPosts");
                    StatisticVariable++;
                    PlayerPrefs.SetInt("Statistics_EasyPosts", StatisticVariable);
                    PlayerPrefs.Save();
                }
                else if (Difficulty == 2)
                {
                    int StatisticVariable = PlayerPrefs.GetInt("Statistics_MidPosts");
                    StatisticVariable++;
                    PlayerPrefs.SetInt("Statistics_MidPosts", StatisticVariable);
                    PlayerPrefs.Save();
                }
                else if (Difficulty == 3)
                {
                    int StatisticVariable = PlayerPrefs.GetInt("Statistics_HardPosts");
                    StatisticVariable++;
                    PlayerPrefs.SetInt("Statistics_HardPosts", StatisticVariable);
                    PlayerPrefs.Save();
                }
            }
            StartCoroutine(DelayEnding());
            

        }
        
    }

    public IEnumerator DelayEnding()
    {
        yield return new WaitForSeconds(2);
        StartFade = true;
        TimeScript.HideTextElement();

    }
    void Update()
    {
        if (StartFade == true)
        {

            if (FP < 1f)
            {
                FP = FP + 0.5f * Speed * Time.deltaTime;
                Color col = Fader.GetComponent<Image>().color;
                col.a = FP;
                Fader.GetComponent<Image>().color = col;
            } else
            {
                if (AfterFP <= 2f)
                {
                    if (ShowLoading == true)
                    {
                        Loading.SetActive(true);
                    }
                    AfterFP = AfterFP + 1f * Speed * Time.deltaTime;
                }
                else
                {
                    UsingCode = PlayerPrefs.GetInt("UseCode_Setting");
                    if (UsingCode == 1)
                    {

                        SceneManager.LoadScene(PlayerPrefs.GetInt("MapPart_Code")); //If using Code, open the Scene the Code wants to open

                    }
                    else
                    {
                        GetMapSettings();
                        if (MapSettings == 0)
                        {
                            SceneManager.LoadScene(1); //Forest 1
                        }
                        else if (MapSettings == 1)
                        {
                            SceneManager.LoadScene(2); //Forest 2
                        }
                        else if (MapSettings == 2)
                        {
                            SceneManager.LoadScene(3); //Maze 1
                        } else if (MapSettings == 3)
                        {
                            SceneManager.LoadScene(5);
                        }
                        else if (MapSettings == 4) //Martinsflue
                        {
                            SceneManager.LoadScene(6);
                        }
                    }
                }

            }
        }
    }

    public void GetMapSettings()
    {
        MapSettings = PlayerPrefs.GetInt("MapDropdown_Setting");
    }
}
