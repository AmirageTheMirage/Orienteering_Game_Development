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
    public GameObject Achievement;
    public GameObject TargetObject;
    public GameObject UnlockCompassToo;

    private Vector3 originPosition;
    
    private float slideSpeed = 400f;

    private void Start()
    {
        originPosition = Achievement.transform.position;
        
        
    }

    private void Update()
    {
        //if (Input.GetKey("r")){
        //    UnlockComp(2);

        //}
        //if (Input.GetKey("t")){
        //    UnlockComp(3);

        //}
    }

    private IEnumerator ShowAchievement()
    {
        yield return new WaitForSeconds(1f);

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
    }

    public void UnlockAchievement(int AchievementName)
    {

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
                Compass2.SetActive(true);
                TitleText.text = "Pinpointed";
                Description.text = "You Pinpointed your exact location.";
                UnlockCompassToo.SetActive(true);
                PlayerPrefs.SetInt("Compass_2", 1); //Unlock
                PlayerPrefs.Save();
                // PlayerPrefs.SetInt("Achievement_1", 1);
                // PlayerPrefs.Save();

            } else if (AchievementName == 2)
            {
                UnlockCompassToo.SetActive(false);
                TitleText.text = "It's a Ball!";
                Description.text = "Sorry y'all but it's Summer.";
              //  PlayerPrefs.SetInt("Achievement_2", 1);
               // PlayerPrefs.Save();
            }
            StartCoroutine(ShowAchievement());
           // UnlockCompassToo.SetActive(false);
           // Compass2.SetActive(false);
           // Compass3.SetActive(false);
        }
    }
}
