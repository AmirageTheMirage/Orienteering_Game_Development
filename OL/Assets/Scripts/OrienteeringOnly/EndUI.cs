using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class EndUI : MonoBehaviour
{
    public GameObject TargetUI;
    public GameObject PlayerUI;
    //public GameObject 
    public float Distance;
    public float Factor;
    public TextMeshProUGUI RatingText;
    public TextMeshProUGUI DistanceText;
    public GameObject Fader;
    public GameObject Loading;
    public GameObject LoadingScreenStuff;
    public AchievementHandler AchievementUnlocker;
    public IsMapMaze IsMapMazeScript;
    public float MazeCorrection = 15f;
    private AudioHandler AudioScript;



    private bool IsMaze;
    private float FP = 1f; //FP = FaderPercent
    private float AfterFP = 0f;
    private bool Fade = false;
    private float PlayerX;
    private float PlayerY;
    private float TargetX;
    private float TargetY;
    private float XDiff;
    private float YDiff;
    private int MapSettings;
    private int FogSettings;
    private int UsingCode = 0;
    public bool LoadingBool = false;
    public TimerScript TimeScript;
    //public AchievementHandler AchievementUnlocker;
    void Start()
    {
        TimeScript.TimerRunning = false;
        UsingCode = PlayerPrefs.GetInt("UseCode_Setting");
        Debug.Log("Using Code: " + UsingCode);
        AudioScript = GameObject.Find("FullAudioHandler").GetComponent<AudioHandler>();
        IsMaze = IsMapMazeScript.IsMaze;
        TargetUI.SetActive(true);
        PlayerUI.SetActive(true);
        Fader.SetActive(false);
        if (LoadingBool)
        {
            Loading.SetActive(true);
        } else
        {
            Loading.SetActive(false);
        }
        LoadingScreenStuff.SetActive(true);
        
        if (PlayerPrefs.GetInt("UseCode_Setting") == 1)
        {
            FogSettings = PlayerPrefs.GetInt("FogPart_Code");
        }
        else
        {
            FogSettings = PlayerPrefs.GetInt("Fog_Setting");
        }
        CalculateDistance();
        // Debug.Log(ScreenX.ToString());

        //ScreenWidth 1000 = Factor 1
        //Screen Width 2000 = Tolerance Factor 2
    }

    // Update is called once per frame
    void Update()
    {
        if (Fade == true)
        {
            if (FP < 1f)
            {
                FP = FP + 0.5f * Time.deltaTime;
                Color col = Fader.GetComponent<Image>().color;
                col.a = FP;
                Fader.GetComponent<Image>().color = col;
            }
            else
            {
                if (AfterFP <= 2f)
                {
                    Loading.SetActive(true);
                    AfterFP = AfterFP + 1f * Time.deltaTime;
                }
                else
                {
                    
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
                        } else
                        {
                            SceneManager.LoadScene(5); //Scene 4 is TutorialScene, this here is Forest 3
                        }
                    }
                }
            }
        }
    }

    public void CalculateDistance()   
    {
        AudioScript.PlaySound("Select2");
        Factor = (float)Screen.width / 1000f; //Ex. Screen Size of 2000 => Factor 2
        Debug.Log(Factor.ToString());
        PlayerX = PlayerUI.transform.position.x;
        PlayerY = PlayerUI.transform.position.y;
        TargetX = TargetUI.transform.position.x;
        TargetY = TargetUI.transform.position.y;
        XDiff = PlayerX - TargetX;
        YDiff = PlayerY - TargetY;
        XDiff = Mathf.Abs(XDiff);
        Debug.Log(XDiff.ToString());
        YDiff = Mathf.Abs(YDiff);
        Distance = XDiff * XDiff + YDiff * YDiff;
        Distance = Mathf.Sqrt(Distance);
        Distance = Distance / Factor; //Bigger Screen = Longer Distance = Has to be canceled out
        Debug.Log("RawScreenDistance = " + Distance);
        if (IsMaze)
        {
            Distance = Distance / MazeCorrection; //Because Mazes are 100x100 not 500x500 + Map is much smaller:
            //Map: 100x100 instead of 500x500 = Factor 5 Map alone
            // Map on screen is bigger than the others, also Factor 5, means 5*5 = 25, but I still only did /10 bc why not
        }
        else
        {
            if (Distance > 3.5f)
            {
                Distance = Distance - 3f; //TOLERANCE for Map not being pixelperfect, except the Maze
            }
        }
        Debug.Log(Distance.ToString());
        DistanceText.text = Mathf.Round(Distance).ToString() + "m";
        if (IsMaze)
        {
            Debug.Log("MazeCorrection * Distance = " + Distance);
            if (Distance * MazeCorrection / 2 < 10f) //Meaning if MazeCorrection = 15, Perfect is around 2m
            {
                RatingText.text = "Perfect";
                

            }
            else if (Distance * MazeCorrection / 2 < 20f)
            {
                RatingText.text = "Great";
            }
            else if (Distance * MazeCorrection / 2 < 30f)
            {
                RatingText.text = "Okay";
            }
            else if (Distance * MazeCorrection / 2 < 50f)
            {
                RatingText.text = "Bad";
            }
            else
            {
                RatingText.text = "Terrible";
            }

        } else {
            if (Distance < 10f)
            {
                RatingText.text = "Perfect";
                if (UsingCode == 0)
                {
                    if (AchievementUnlocker.SceneryInt == 5) //Mastery Progress in Forest 3
                    {
                        Debug.Log("Sent Mastery Request for: " + AchievementUnlocker.SceneryInt);
                        AchievementUnlocker.Mastery(3);
                    }
                }
            }
            else if (Distance < 20f)
            {
                RatingText.text = "Great";
            }
            else if (Distance < 30f)
            {
                RatingText.text = "Okay";
            }
            else if (Distance < 50f)
            {
                RatingText.text = "Bad";
            }
            else
            {
                RatingText.text = "Terrible";
            }
            if (UsingCode == 0)
            {
                //STATISTICS
                if (PlayerPrefs.GetInt("Statistics_Record") == 1)
                {
                    int StatisticOrienteeringPlayed = PlayerPrefs.GetInt("Statistics_OrienteeringGamesPlayed");
                    StatisticOrienteeringPlayed++;
                    PlayerPrefs.SetInt("Statistics_OrienteeringGamesPlayed", StatisticOrienteeringPlayed);
                    PlayerPrefs.Save();

                    int StatisticOrienteeringAdded = PlayerPrefs.GetInt("Statistics_OrienteeringAddedTogether");
                    StatisticOrienteeringAdded = StatisticOrienteeringAdded + Mathf.RoundToInt(Distance);
                    PlayerPrefs.SetInt("Statistics_OrienteeringAddedTogether", StatisticOrienteeringAdded);
                    PlayerPrefs.Save();
                }
                if (Distance < 10f)
            {
                    //STATISTICS
                    if (PlayerPrefs.GetInt("Statistics_Record") == 1)
                    {
                        int StatisticPerfectResultsMade = PlayerPrefs.GetInt("Statistics_OrienteeringPerfect");
                        StatisticPerfectResultsMade++;
                        PlayerPrefs.SetInt("Statistics_OrienteeringPerfect", StatisticPerfectResultsMade);
                        PlayerPrefs.Save();
                    }

                
                    if (PlayerPrefs.GetInt("Achievement_1") == 0)
                    {
                        AchievementUnlocker.UnlockAchievement(1);
                    }
                    else
                    {
                        if (FogSettings == 5)
                        {
                            if (Distance < 1.5f)
                            {
                                AchievementUnlocker.UnlockAchievement(7);
                            }
                            //else
                            //{
                            //    AchievementUnlocker.UnlockAchievement(6);
                            //}

                        }
                    }
                
            } else if (Distance > 300f)
            {
                AchievementUnlocker.UnlockAchievement(5);
            }
            }
        }
    }
    public void RestartTheLevel()
    {
        AudioScript.PlaySound("Select1");
        TimeScript.HideTextElement();
        Fade = true;
        Fader.SetActive(true);
        FP = 0f;
    }
    public void GetMapSettings()
    {
        MapSettings = PlayerPrefs.GetInt("MapDropdown_Setting");
    }
}
