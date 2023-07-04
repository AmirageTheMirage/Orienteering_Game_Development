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
    string[] Forest1EasyPosts = new string[] { "151", "152", "154", "157", "160", "164"};
    string[] Forest1MidPosts = new string[] { "151", "152", "154", "157", "160", "164",    "150", "156", "158", "161" };
    string[] Forest1HardPosts = new string[] { "151", "152", "154", "157", "160", "164",     "150", "156", "158", "161",      "153", "155", "159", "162", "163", "165", "166" };
    string[] Forest2EasyPosts = new string[] { "151", "155", "156", "157", "159", "163" };
    string[] Forest2MidPosts = new string[] { "151", "155", "156", "157", "159", "163",                "153", "154", "166", "164" };
    string[] Forest2HardPosts = new string[] { "151", "155", "156", "157", "159", "163",            "153", "154", "166", "164",             "150", "152", "158", "161", "160", "165", "162" };
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

        MapSetting = PlayerPrefs.GetInt("MapDropdown_Setting");
        Difficulty = PlayerPrefs.GetInt("Difficulty_Setting");
        //Debug.Log(Difficulty);
        //Selection of Posts

        if (MapSetting == 0)
        {
            EasySelection = Forest1EasyPosts;
            MidSelection = Forest1MidPosts;
            HardSelection = Forest1HardPosts;
        } else
        {
            EasySelection = Forest2EasyPosts;
            MidSelection = Forest2MidPosts;
            HardSelection = Forest2HardPosts;
        }
        if (Difficulty == 1)
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
        





        



        GameObject child = Posten.transform.Find(startposten.ToString()).gameObject;
        child.SetActive(true);
        GameObject child2 = Posten.transform.Find(endposten.ToString()).gameObject;
        child2.SetActive(true);
        //Charakter.transform.position = new Vector3(5f, 1f, 1f);
        if (MapSetting == 1)
        {
            GameObject child3 = child.transform.Find(startposten.ToString()).gameObject;
            EndX = child3.transform.position.x;
            EndY = child3.transform.position.y;
            EndZ = child3.transform.position.z;
        }
        else
        {
            EndX = child.transform.position.x;
            EndY = child.transform.position.y;
            EndZ = child.transform.position.z;
        }
        Charakter.transform.position = new Vector3(EndX + 1f, EndY + 1f, EndZ);




    }



}
