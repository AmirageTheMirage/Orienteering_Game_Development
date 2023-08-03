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
    public bool IsMaze;
   



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
    
    void Start()
    {
        TargetUI.SetActive(true);
        PlayerUI.SetActive(true);
        Fader.SetActive(false);
        Loading.SetActive(false);
        LoadingScreenStuff.SetActive(true);
        FogSettings = PlayerPrefs.GetInt("Fog_Setting");
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
                    GetMapSettings();
                    if (MapSettings == 0)
                    {
                        SceneManager.LoadScene(1); //Forest 1
                    }
                    else if (MapSettings == 1)
                    {
                        SceneManager.LoadScene(2); //Forest 2
                    } else
                    {
                        SceneManager.LoadScene(3); //Maze 1
                    }
                }
            }
        }
    }

    public void CalculateDistance()   
    {
       
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
        if (IsMaze)
        {
            Distance = Distance / 5; //Because Mazes are 100x100 not 500x500
        }
        if (Distance > 3.5f)
        {
            Distance = Distance - 3f; //TOLERANCE for Map not being pixelperfect
        }
        Debug.Log(Distance.ToString());
        DistanceText.text = Mathf.Round(Distance).ToString() + "m";
        if (IsMaze)
        {
            if (Distance * 5 < 10f)
            {
                RatingText.text = "Perfect";
            }
            else if (Distance * 5 < 20f)
            {
                RatingText.text = "Great";
            }
            else if (Distance * 5 < 30f)
            {
                RatingText.text = "Okay";
            }
            else if (Distance * 5 < 50f)
            {
                RatingText.text = "Bad";
            }
            else
            {
                RatingText.text = "Terrible";
            }

        }
        if (Distance < 10f)
        {
            RatingText.text = "Perfect";
        } else if (Distance < 20f)
        {
            RatingText.text = "Great";
        }
        else if (Distance < 30f)
        {
            RatingText.text = "Okay";
        } else if (Distance < 50f)
        {
            RatingText.text = "Bad";
        } else
        {
            RatingText.text = "Terrible";
        }
        if (Distance < 10f)
        {
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
                    } else
                    {
                        AchievementUnlocker.UnlockAchievement(6);
                    }

                }
            }
        }
        if (Distance > 300f)
        {
            AchievementUnlocker.UnlockAchievement(5);
        }
    }
    public void RestartTheLevel()
    {
        Fade = true;
        Fader.SetActive(true);
        FP = 0f;
    }
    public void GetMapSettings()
    {
        MapSettings = PlayerPrefs.GetInt("MapDropdown_Setting");
    }
}
