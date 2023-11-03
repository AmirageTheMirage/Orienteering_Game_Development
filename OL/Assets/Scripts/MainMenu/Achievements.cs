using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Achievements : MonoBehaviour
{


    // ACHIEVEMENTS
    // 1: Pinpointed
    // 2: Ball (FindBeachBall)
    // 3: Easy! (Win in EasyMode)
    // 4: Win in Hard Mode
    // 5: Too Hard (300m+ Distance Orienteering)
    // 6: Where am I (Fog on Max + Perfect Result)
    // 7: FogMaster (Fog on Max + <1m Result)
    // 8: How did we... (Glitch off the Map)
    //public int Achievement_1 = 0;
    //public int Achievement_2 = 0;
    //public int Achievement_3 = 0;
    //public int Achievement_4 = 0;
    //public int Achievement_5 = 0;
    //public int Achievement_6 = 0;
    //public int Achievement_7 = 0;
    //public int Achievement_8 = 0;

    //public GameObject Check_1;
    //public GameObject Check_2;
    //public GameObject Check_3;
    //public GameObject Check_4;
    //public GameObject Check_5;
    //public GameObject Check_6;
    //public GameObject Check_7;
    //public GameObject Check_8;
    public int NumbersOfAchievements;
    public int NumberOfMasteries;
    List<int> Unlocked = new List<int>();
    public GameObject ContentObjectOfScrollBar;
    private AudioHandler AudioScript;
    void Start()
    {
        AudioScript = GameObject.Find("FullAudioHandler").GetComponent<AudioHandler>(); //Get Audio Script so Sounds can be played via Script
        ReStart();
    }
    void ReStart()
    {


        //MASTERIES

        for (int i = 1; i <= NumberOfMasteries; i++)
        {
            string MasteryProgressName = "MasteryUnlockProgress_" + i.ToString(); //For PlayerPrefs later
            string MasteryObjectName = "Mastery" + i.ToString();
            Transform MasteryObject = ContentObjectOfScrollBar.transform.Find(MasteryObjectName);
            
            
            
            if (MasteryObject != null)
            {
                GameObject ActualMasteryObject = ContentObjectOfScrollBar.transform.Find(MasteryObjectName).gameObject; //Find GameObject
                Slider UnlockProgressSliderObject = ActualMasteryObject.transform.Find("UnlockProgressSlider")?.GetComponent<Slider>();
                GameObject UnlockProgressSliderGameObject = MasteryObject.gameObject; //So that it doesnt refer to the SLIDER but to the GAMEOBJECT
                GameObject CheckMarkObjectMastery = UnlockProgressSliderGameObject.transform.Find("CheckMarkShadow").gameObject;
                TMP_Text UnlockProgressSliderObjectText = ActualMasteryObject.transform.Find("ProgressText")?.GetComponent<TMP_Text>();
                if (PlayerPrefs.HasKey(MasteryProgressName) == false)
                {

                    PlayerPrefs.SetInt(MasteryProgressName, 0); //Set Int to 0 if it doesn't exist
                    PlayerPrefs.Save();
                    Debug.Log("Created: " + MasteryProgressName);



                }

                //Define Visuals
                float Progress = (float)PlayerPrefs.GetInt(MasteryProgressName);
                UnlockProgressSliderObject.value = Progress;
                UnlockProgressSliderObjectText.text = Progress.ToString() + "/10";
                if (PlayerPrefs.GetInt(MasteryProgressName) == 10)
                {
                    CheckMarkObjectMastery.SetActive(true);
                } else
                {
                    CheckMarkObjectMastery.SetActive(false);
                }

            }
            else
            {
                Debug.Log("The following Mastery is missing: Mastery " + i); //Yea that's bad
            }






        }

        //if (PlayerPrefs.GetInt("MasteryUnlockProgress_1") == 10)
        //{
        //    PlayerPrefs.SetInt("Achievement_9", 1);
        //}
        //if (PlayerPrefs.GetInt("MasteryUnlockProgress_2") == 10)
        //{
        //    PlayerPrefs.SetInt("Achievement_10", 1);
        //}
        //if (PlayerPrefs.GetInt("MasteryUnlockProgress_3") == 10)
        //{
        //    PlayerPrefs.SetInt("Achievement_11", 1);
        //}







        //ACHIEVEMENTS





        for (int i = 1; i <= NumbersOfAchievements; i++)
        {
            string AchievementName = "Achievement_" + i.ToString();
            Transform AchievementObjectTransform = ContentObjectOfScrollBar.transform.Find(i.ToString());
            if (AchievementObjectTransform != null) {
                GameObject AchievementObject = ContentObjectOfScrollBar.transform.Find(i.ToString()).gameObject;
                GameObject CheckMarkObject = AchievementObject.transform.Find("CheckMarkShadow").gameObject;

                if (PlayerPrefs.HasKey(AchievementName))
                {
                    if (PlayerPrefs.GetInt(AchievementName) == 1)
                    {
                        Unlocked.Add(i); //If Unlocked, Add it

                        CheckMarkObject.SetActive(true);
                        Debug.Log("So you unlocked Achievement_" + i);
                    } else if (PlayerPrefs.GetInt(AchievementName) == 0)
                    {
                        CheckMarkObject.SetActive(false);
                        Debug.Log("You didn't unlock " + AchievementName);
                    }
                }
                else 
                {
                    PlayerPrefs.SetInt(AchievementName, 0);
                    PlayerPrefs.Save();
                    Debug.Log("Created " + AchievementName);
                }
            } else
            {
                Debug.Log(AchievementName + " does not exist, it is likely removed.");
            }
            //Debug.Log("Cycled through " + i.ToString());



        }


       



        



    }

        // Update is called once per frame
        void Update()
    {
        
    }

    public void Reset()
    {
        PlayerPrefs.SetInt("Achievement_1", 0);
        PlayerPrefs.SetInt("Achievement_2", 0);
        PlayerPrefs.SetInt("Achievement_3", 0);
        PlayerPrefs.SetInt("Achievement_4", 0);
        PlayerPrefs.SetInt("Achievement_5", 0);
        PlayerPrefs.SetInt("Achievement_6", 0);
        PlayerPrefs.SetInt("Achievement_7", 0);
        PlayerPrefs.SetInt("Achievement_8", 0);
        PlayerPrefs.SetInt("Achievement_12", 0);
        PlayerPrefs.SetInt("MasteryUnlockProgress_1", 0);
        PlayerPrefs.SetInt("MasteryUnlockProgress_2", 0);
        PlayerPrefs.SetInt("MasteryUnlockProgress_3", 0);
        PlayerPrefs.Save();
        ReStart();
        AudioScript.PlaySound("Select3");
    }
}
