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
    
    void Start()
    {
        TargetUI.SetActive(true);
        PlayerUI.SetActive(true);
        Fader.SetActive(false);
        Loading.SetActive(false);
        LoadingScreenStuff.SetActive(true);
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
                    else
                    {
                        SceneManager.LoadScene(2); //Forest 2
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
        Debug.Log(Distance.ToString());
        DistanceText.text = Mathf.Round(Distance).ToString() + "m";

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
        if (Distance < 50f)
        {
            AchievementUnlocker.UnlockAchievement(1);
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
