using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
    public int Achievement_1 = 0;
    public int Achievement_2 = 0;
    public int Achievement_3 = 0;
    public int Achievement_4 = 0;
    public int Achievement_5 = 0;
    public int Achievement_6 = 0;
    public int Achievement_7 = 0;
    public int Achievement_8 = 0;

    public GameObject Check_1;
    public GameObject Check_2;
    public GameObject Check_3;
    public GameObject Check_4;
    public GameObject Check_5;
    public GameObject Check_6;
    public GameObject Check_7;
    public GameObject Check_8;
    void Start()
    {
        ReStart();
    }
    void ReStart()
    {
        Check_1.SetActive(false);
        Check_2.SetActive(false);
        Check_3.SetActive(false);
        Check_4.SetActive(false);
        Check_5.SetActive(false);
        Check_6.SetActive(false);
        Check_7.SetActive(false);
        Check_8.SetActive(false);
        if (PlayerPrefs.HasKey("Achievement_1"))
        {
            Achievement_1 = PlayerPrefs.GetInt("Achievement_1");

        }
        else
        {
            PlayerPrefs.SetInt("Achievement_1", Achievement_1);
            PlayerPrefs.Save();
        }
        if (PlayerPrefs.HasKey("Achievement_2"))
        {
            Achievement_2 = PlayerPrefs.GetInt("Achievement_2");

        }
        else
        {
            PlayerPrefs.SetInt("Achievement_2", Achievement_2);
            PlayerPrefs.Save();
        }
        
        if (PlayerPrefs.HasKey("Achievement_3"))
        {
            Achievement_3 = PlayerPrefs.GetInt("Achievement_3");

        }
        else
        {
            PlayerPrefs.SetInt("Achievement_3", Achievement_3);
            PlayerPrefs.Save();
        }
        
        
        if (PlayerPrefs.HasKey("Achievement_4"))
        {
            Achievement_4 = PlayerPrefs.GetInt("Achievement_4");

        }
        else
        {
            PlayerPrefs.SetInt("Achievement_4", Achievement_4);
            PlayerPrefs.Save();
        }
       
        
        if (PlayerPrefs.HasKey("Achievement_5"))
        {
            Achievement_5 = PlayerPrefs.GetInt("Achievement_5");

        }
        else
        {
            PlayerPrefs.SetInt("Achievement_5", Achievement_5);
            PlayerPrefs.Save();
        }
       
        
        if (PlayerPrefs.HasKey("Achievement_6"))
        {
            Achievement_6 = PlayerPrefs.GetInt("Achievement_6");

        }
        else
        {
            PlayerPrefs.SetInt("Achievement_6", Achievement_6);
            PlayerPrefs.Save();
        }
       
        
        if (PlayerPrefs.HasKey("Achievement_7"))
        {
            Achievement_7 = PlayerPrefs.GetInt("Achievement_7");

        }
        else
        {
            PlayerPrefs.SetInt("Achievement_7", Achievement_7);
            PlayerPrefs.Save();
        }
      
        
        if (PlayerPrefs.HasKey("Achievement_8"))
        {
            Achievement_8 = PlayerPrefs.GetInt("Achievement_8");

        }
        else
        {
            PlayerPrefs.SetInt("Achievement_8", Achievement_8);
            PlayerPrefs.Save();
        }

        if (Achievement_1 == 1)
        {
            Check_1.SetActive(true);
        }
        if (Achievement_2 == 1)
        {
            Check_2.SetActive(true);
        }
        if (Achievement_3 == 1)
        {
            Check_3.SetActive(true);
        }
        if (Achievement_4 == 1)
        {
            Check_4.SetActive(true);
        }
        if (Achievement_5 == 1)
        {
            Check_5.SetActive(true);
        }
        if (Achievement_6 == 1)
        {
            Check_6.SetActive(true);
        }
        if (Achievement_7 == 1)
        {
            Check_7.SetActive(true);
        }
        if (Achievement_8 == 1)
        {
            Check_8.SetActive(true);
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
        PlayerPrefs.Save();
        ReStart();
    }
}
