using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class AchievementHandler : MonoBehaviour
{
    public TextMeshProUGUI TitleText;
    public TextMeshProUGUI Description;
    public GameObject Compass2;
    public GameObject Compass3;
    public GameObject Compass4;
    public GameObject Achievement;
    public GameObject TargetObject;
    public GameObject UnlockCompassToo;
    public int SceneryInt;
    public bool AlreadySliding = false;
    public TMP_Text AchievementUnlockedText;
    public int FramesInScene = 0;
    private AudioHandler AudioScript;

    private Vector3 originPosition;
    [Space]
    public float slideSpeed = 400f;

    private void Start()
    {
        AudioScript = GameObject.Find("FullAudioHandler").GetComponent<AudioHandler>();
        originPosition = Achievement.transform.position;
        
        
    }

    private void Update()
    {
        FramesInScene++;
    }

    private IEnumerator ShowAchievement()
    {
       // yield return new WaitForSeconds(1f);

        float startTime = Time.time;
        

        while (Achievement.transform.position.x > TargetObject.transform.position.x)
        {
            float distCovered = (Time.time - startTime) * slideSpeed;
            Achievement.transform.position = new Vector3(Achievement.transform.position.x - slideSpeed * Time.deltaTime, Achievement.transform.position.y, Achievement.transform.position.z);
            // Achievement.transform.position = Vector3.Lerp(originPosition, targetPosition, fractionOfJourney);
            //Debug.Log(Achievement.transform.position.x);
            
            yield return null;
        }
        yield return new WaitForSeconds(6f);

        while (Achievement.transform.position.x < originPosition.x)
        {
            float distCovered = (Time.time - startTime) * slideSpeed;
            Achievement.transform.position = new Vector3(Achievement.transform.position.x + slideSpeed * Time.deltaTime, Achievement.transform.position.y, Achievement.transform.position.z);
            // Achievement.transform.position = Vector3.Lerp(originPosition, targetPosition, fractionOfJourney);
            //Debug.Log(Achievement.transform.position.x);

            yield return null;
        }

        Debug.Log("Sliding complete");
        AlreadySliding = false;
    }
    public void Mastery(int MasteryInt)
    {
        Debug.Log("Called MasteryFunction for "+ MasteryInt);
        AchievementUnlockedText.text = "Mastery Complete";
        string CurrentMasteryPlayerPrefIntName = "MasteryUnlockProgress_" + MasteryInt.ToString();
        
        int MasteryProgress = PlayerPrefs.GetInt(CurrentMasteryPlayerPrefIntName);
        if (MasteryProgress < 10)
        {
            MasteryProgress++;
            PlayerPrefs.SetInt(CurrentMasteryPlayerPrefIntName, MasteryProgress);
            PlayerPrefs.Save();
            if (MasteryProgress == 10)
            {
                Description.text = "";
                Debug.Log("Mastery Complete!");
                if (MasteryInt == 1)
                {
                    UnlockCompassToo.SetActive(true);
                    Compass2.SetActive(true);
                    TitleText.text = "Mastery of Forest 1";
                    PlayerPrefs.SetInt("Compass_2", 1); //Unlock
                    PlayerPrefs.Save();


                }
                else if (MasteryInt == 2)
                {
                    Compass3.SetActive(true);
                    TitleText.text = "Mastery of Forest 2";
                    UnlockCompassToo.SetActive(true);
                    PlayerPrefs.SetInt("Compass_3", 1); //Unlock
                    PlayerPrefs.Save();


                }
                else if (MasteryInt == 3)
                {
                    Compass4.SetActive(true);
                    TitleText.text = "Mastery of the Maze";
                    UnlockCompassToo.SetActive(true);
                    PlayerPrefs.SetInt("Compass_4", 1); //Unlock
                    PlayerPrefs.Save();
                }
                AlreadySliding = true;
                StartCoroutine(ShowAchievement());

            }
        }
    }
    public void UnlockAchievement(int AchievementName)
    {
        Debug.Log("Called AchievementFunction");
        AchievementUnlockedText.text = "Achievement Unlocked";
        string Achievementcurrentname = "Achievement_" + AchievementName.ToString();
        
        int PlayerPrefCheck = 0;
        PlayerPrefCheck = PlayerPrefs.GetInt(Achievementcurrentname);
        PlayerPrefs.SetInt(Achievementcurrentname, 1); //Unlock
        PlayerPrefs.Save();
        UnlockCompassToo.SetActive(false);
        Compass2.SetActive(false);
        Compass3.SetActive(false);

        if (PlayerPrefCheck == 0) //if it was 0 before
        {
            if (AchievementName == 1)
            {
               // Compass2.SetActive(true);
                TitleText.text = "Pinpointed";
                Description.text = "You Pinpointed your exact location.";
                UnlockCompassToo.SetActive(false);
                //PlayerPrefs.SetInt("Compass_2", 1); //Unlock
                //PlayerPrefs.Save();
                // PlayerPrefs.SetInt("Achievement_1", 1);
                //Implemented2

            } else if (AchievementName == 2)
            {
                UnlockCompassToo.SetActive(false);
                TitleText.text = "It's a Ball!";
                Description.text = "Find the Secret Beach Ball.";
                PlayerPrefs.SetInt("Achievement_2", 1);
                //Implemented

            }
            //else if (AchievementName == 3)
            //{
            //    UnlockCompassToo.SetActive(false);
            //    TitleText.text = "Easy!";
            //    Description.text = "Find a Post in easy mode.";
            //    PlayerPrefs.SetInt("Achievement_3", 1);
            //    //Implemented2
            //}
            //else if (AchievementName == 4)
            //{
            //    UnlockCompassToo.SetActive(false);
            //    TitleText.text = "Hard Mode!";
            //    Description.text = "Find a Post in hard mode.";
            //    PlayerPrefs.SetInt("Achievement_4", 1);
            //    Compass3.SetActive(true);
            //    UnlockCompassToo.SetActive(true);
            //    PlayerPrefs.SetInt("Compass_3", 1); //Unlock
            //    PlayerPrefs.Save();
            //    //Implemented2
            //}
            else if (AchievementName == 5)
            {
                UnlockCompassToo.SetActive(false);
                TitleText.text = "Too hard?";
                Description.text = "Get >300m distance in Orienteering Mode. You might wanna try again.";
                PlayerPrefs.SetInt("Achievement_5", 1);
                //Implemented2
            }
            //else if (AchievementName == 6)
            //{
            //    UnlockCompassToo.SetActive(false);
            //    TitleText.text = "Where am I?";
            //    Description.text = "Get a perfect result in Orienteering-Mode with Maximum Fog.";
            //    PlayerPrefs.SetInt("Achievement_6", 1);
            //    //Implemented2
            //}
            else if (AchievementName == 7)
            {
                UnlockCompassToo.SetActive(false);
                TitleText.text = "Fog Master";
                Description.text = "Get <1m distance in Orienteering Mode with Maximum Fog.";
                PlayerPrefs.SetInt("Achievement_7", 1);
                //Implemented2
            }
            else if (AchievementName == 8)
            {
                UnlockCompassToo.SetActive(false);
                TitleText.text = "How did we...";
                Description.text = "Fall off the Map.";
                PlayerPrefs.SetInt("Achievement_8", 1);
                //Implemented
            } else if (AchievementName == 12)
            {
                UnlockCompassToo.SetActive(false);
                TitleText.text = "Owchie!";
                Description.text = "You got stuck in thorns.";
                PlayerPrefs.SetInt("Achievement_12", 1);
            }
            PlayerPrefs.Save();
            if (AlreadySliding == false)
            {
                AlreadySliding = true;
                AudioScript.PlaySound("Select3");
                StartCoroutine(ShowAchievement());
            }
           // UnlockCompassToo.SetActive(false);
           // Compass2.SetActive(false);
           // Compass3.SetActive(false);
        }
    }
}
