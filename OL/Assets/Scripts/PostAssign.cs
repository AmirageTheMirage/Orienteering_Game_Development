using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PostAssign : MonoBehaviour
{
    
    public GameObject Posten;
    public GameObject Charakter;
    public int Difficulty;
    public GameObject Fader;
    public int endposten = 0;
    private float EndX = 0f;
    private float EndY = 0f;
    private float EndZ = 0f;
    //public bool IsMaze;

    //DEFINE POSTS (Hard is obsolete, could just use all, however this way I can disable Posts I don't want
    string[] Forest1EasyPosts = new string[] { "151", "152", "154", "157", "160", "164"};
    string[] Forest1MidPosts = new string[] { "151", "152", "154", "157", "160", "164",    "150", "156", "158", "161" };
    string[] Forest1HardPosts = new string[] { "151", "152", "154", "157", "160", "164",     "150", "156", "158", "161",      "153", "155", "159", "162", "163", "165", "166" };
    string[] Forest2EasyPosts = new string[] { "151", "155", "156", "157", "159", "163" };
    string[] Forest2MidPosts = new string[] { "151", "155", "156", "157", "159", "163",                "153", "154", "166", "164" };
    string[] Forest2HardPosts = new string[] { "151", "155", "156", "157", "159", "163",            "153", "154", "166", "164",             "150", "152", "158", "161", "160", "165", "162" };
    string[] Forest3EasyPosts = new string[] { "157", "159", "161", "162", "165" };
    string[] Forest3MidPosts = new string[] { "157", "159", "161", "162", "165", "154", "155", "156", "163", "166" };
    string[] Forest3HardPosts = new string[] { "157", "159", "161", "162", "165", "154", "155", "156", "163", "166", "150", "151", "152", "153", "158", "160", "164" };


    string[] Forest4EasyPosts = new string[] { "153", "157", "163", "166" };
    string[] Forest4MidPosts = new string[] { "153", "157", "163", "166", "151", "154", "156", "158", "164", "165"};

    string[] Forest4HardPosts = new string[] { "157", "159", "161", "162", "165", "154", "155", "156", "163", "166", "150", "151", "152", "153", "158", "160", "164" };
    


    string[] EasySelection;
    string[] MidSelection;
    string[] HardSelection;
    
    
    int startposten = 0;
    public int MapSetting;
    
    //string Forest1MidPosts = "";
    //string Forest1HardPosts = "";
    // Start is called before the first frame update
    void Start()
    {
        if (PlayerPrefs.GetInt("UseCode_Setting") == 1)
        {
           // Difficulty = PlayerPrefs.GetInt("Difficulty_Code");
           startposten = PlayerPrefs.GetInt("StartPost_Code");
           endposten = PlayerPrefs.GetInt("EndPost_Code");
           MapSetting = PlayerPrefs.GetInt("MapPart_Code") - 1;

        }
        else
        {
            MapSetting = PlayerPrefs.GetInt("MapDropdown_Setting");
            Difficulty = PlayerPrefs.GetInt("Difficulty_Setting");
            //Debug.Log(Difficulty);
            //Selection of Posts

            if (MapSetting == 0)
            {
                EasySelection = Forest1EasyPosts;
                MidSelection = Forest1MidPosts;
                HardSelection = Forest1HardPosts;
            }
            else if (MapSetting == 1)
            {
                EasySelection = Forest2EasyPosts;
                MidSelection = Forest2MidPosts;
                HardSelection = Forest2HardPosts;
            }
            else if (MapSetting == 2)
            {
                EasySelection = Forest2HardPosts;
                MidSelection = Forest2HardPosts;
                HardSelection = Forest2HardPosts; //Maze = No Difficulty Changing, so all posts always
            } else if (MapSetting == 3)
            {
                EasySelection = Forest3EasyPosts;
                MidSelection = Forest3MidPosts;
                HardSelection = Forest3HardPosts;
            } else
            {
                EasySelection = Forest4EasyPosts;
                MidSelection = Forest4MidPosts;
                HardSelection = Forest4HardPosts;
            }
            if (Difficulty == 1) //Depending on Difficulty
            {

                startposten = int.Parse(EasySelection[Random.Range(0, EasySelection.Length)]);
                endposten = int.Parse(EasySelection[Random.Range(0, EasySelection.Length)]);

                while (endposten - 0.1 < startposten && endposten + 0.1 > startposten)
                {
                    endposten = int.Parse(EasySelection[Random.Range(0, EasySelection.Length)]);
                }

            }
            else if (Difficulty == 2)
            {
                startposten = int.Parse(MidSelection[Random.Range(0, MidSelection.Length)]);
                endposten = int.Parse(MidSelection[Random.Range(0, MidSelection.Length)]);
                while (endposten - 0.1 < startposten && endposten + 0.1 > startposten)
                {
                    endposten = int.Parse(MidSelection[Random.Range(0, MidSelection.Length)]);
                }

            }
            else if (Difficulty == 3)
            {

                startposten = int.Parse(HardSelection[Random.Range(0, HardSelection.Length)]);
                endposten = int.Parse(HardSelection[Random.Range(0, HardSelection.Length)]);
                while (endposten - 0.1 < startposten && endposten + 0.1 > startposten)
                {
                    endposten = int.Parse(HardSelection[Random.Range(0, HardSelection.Length)]);
                }
            }



        }





        PlayerPrefs.SetInt("StartPost_Code", startposten);
        PlayerPrefs.SetInt("EndPost_Code", endposten);
       // PlayerPrefs.SetInt("DifficultyPart_Code", Difficulty);
        PlayerPrefs.Save();
        GameObject child = Posten.transform.Find(startposten.ToString()).gameObject;
        child.SetActive(true);
        GameObject child2 = Posten.transform.Find(endposten.ToString()).gameObject;
        child2.SetActive(true);
        //Charakter.transform.position = new Vector3(5f, 1f, 1f);
        if (MapSetting == 0)
        {
            EndX = child.transform.position.x;
            EndY = child.transform.position.y;
            EndZ = child.transform.position.z;
        }
        else
        {
            
            GameObject child3 = child.transform.Find(startposten.ToString()).gameObject;
            EndX = child3.transform.position.x;
            EndY = child3.transform.position.y;
            EndZ = child3.transform.position.z;
        }
        Charakter.transform.position = new Vector3(EndX + 1f, EndY, EndZ); //AfterHolidayEdit: EndXYZ is actually the start coordinates. No Idea what I did back then. Not gonna change it anymore.
        
        



    }



}
