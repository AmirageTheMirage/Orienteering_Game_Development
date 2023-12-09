using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TimerScript : MonoBehaviour
{
    public bool TimerRunning = false;
    public bool StartTimer;
    public float Timer = 0f;
    public float RoundedTimer;
    public TMP_Text TimerText;
    public bool Ended = false;
    private int Mode;
    public bool IsThisAMaze = false;
    
    void Start()
    {
        Mode = PlayerPrefs.GetInt("ModeDropdown_Setting");
        TimerText.text = "0:00s";
        TimerRunning = false;
        StartTimer = false;
        Ended = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (TimerRunning && StartTimer)
        {
            Timer += Time.deltaTime;
            RoundedTimer = (float)(Mathf.Round(Timer * 100f) / 100f);
            TimerText.text = RoundedTimer.ToString() + "s";
        }
        if (StartTimer == false) {
            if (Mode == 0)//If PostSearch
            {
            if (Input.GetKeyDown(KeyCode.M) || Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.DownArrow) || Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.RightArrow))
            {
                StartTimer = true;
                TimerRunning = true;
            }
            } else
            {
                if (Input.GetKeyDown(KeyCode.M))
                {
                    StartTimer = true;
                    TimerRunning = true;
                }
            }
        }
        if (Ended == false && TimerRunning == false && StartTimer == true)
        {
            Ended = true;
            TimerText.text = "Final Time: " + TimerText.text;

            //STATISTICS
            if (PlayerPrefs.GetInt("Statistics_Record") == 1)
            {
                AddToStatistics();
            }
        }
    }

    public void HideTextElement()
    {
        gameObject.SetActive(false);
    }

    public void AddToStatistics()
    {
        if (IsThisAMaze == false)
        {
            Debug.Log("AddToStats called! Timer: " + RoundedTimer.ToString());
            int currentNumber = 0;
            int currentTimes = 0;
            if (Mode == 0) //PostMode
            {
                currentNumber = PlayerPrefs.GetInt("Statistics_TimerPostNumber");
                currentTimes = PlayerPrefs.GetInt("Statistics_TimerPostTimes");
                currentNumber = currentNumber += (int)(RoundedTimer * 100);
                currentTimes += 1;
                PlayerPrefs.SetInt("Statistics_TimerPostNumber", currentNumber);
                PlayerPrefs.SetInt("Statistics_TimerPostTimes", currentTimes);
                PlayerPrefs.Save();
            }
            else if (Mode == 1)
            {
                currentNumber = PlayerPrefs.GetInt("Statistics_TimerOrientNumber");
                currentTimes = PlayerPrefs.GetInt("Statistics_TimerOrientTimes");
                currentNumber = currentNumber += (int)(RoundedTimer * 100);
                currentTimes += 1;
                PlayerPrefs.SetInt("Statistics_TimerOrientNumber", currentNumber);
                PlayerPrefs.SetInt("Statistics_TimerOrientTimes", currentTimes);
                PlayerPrefs.Save();

            }
        }
    }
}
