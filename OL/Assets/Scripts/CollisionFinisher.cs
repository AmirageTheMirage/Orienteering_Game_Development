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


    public GameObject Fader;
    private float FP = 1f; //FP = FaderPercent
    public bool StartFade = false;
    private int UsingCode = 0;
    
    void Start()
    {
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
   
    void OnCollisionEnter(Collision collision)

    {

        


        if (MyNameAsInt == numberofendposten && alreadyfading == false)
        {
            if (IsMaze == false)
            {
                if (Difficulty == 1)
                {
                    AchievScript.UnlockAchievement(3);
                }
                else if (Difficulty == 3)
                {
                    AchievScript.UnlockAchievement(4);
                }
            }
            alreadyfading = true;
            touching = true;
            Fader.SetActive(true);
            StartFade = true;
            FP = 0f;

        }
        
    }


    void Update()
    {
        if (StartFade == true)
        {
            if (FP < 1f)
            {
                FP = FP + 0.5f * Time.deltaTime;
                Color col = Fader.GetComponent<Image>().color;
                col.a = FP;
                Fader.GetComponent<Image>().color = col;
            } else
            {
                if (AfterFP <= 2f)
                {
                    Loading.SetActive(true);
                    AfterFP = AfterFP + 1f * Time.deltaTime;
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
                        else
                        {
                            SceneManager.LoadScene(3); //Maze 1
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
