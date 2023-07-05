using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Achievements : MonoBehaviour
{

    public int Achievement_1 = 0;
    public int Achievement_2 = 0;
    public GameObject Check_1;
    public GameObject Check_2;
    void Start()
    {
        ReStart();
    }
    void ReStart()
    {

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

        if (Achievement_1 == 1)
        {
            Check_1.SetActive(true);
        } else
        {
            Check_1.SetActive(false);
        }
        if (Achievement_2 == 1)
        {
            Check_2.SetActive(true);
        } else
        {
            Check_2.SetActive(false);
        }
    }

        // Update is called once per frame
        void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            PlayerPrefs.SetInt("Achievement_1", 0);
            PlayerPrefs.SetInt("Achievement_2", 0);
            PlayerPrefs.Save();
            ReStart();
        }

    }
}
