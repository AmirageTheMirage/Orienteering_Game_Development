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
    string[] EasyPosts = new string[] { "151", "152", "154", "157", "160", "164"};
    string[] MidPosts = new string[] { "151", "152", "154", "157", "160", "164",    "150", "156", "158", "161" };
    string[] HardPosts = new string[] { "151", "152", "154", "157", "160", "164",     "150", "156", "158", "161",      "153", "155", "159", "162", "163", "165", "166" };
    int startposten = 0;
    //string MidPosts = "";
    //string HardPosts = "";
    // Start is called before the first frame update
    void Start()
    {


        Difficulty = PlayerPrefs.GetInt("Difficulty_Setting");
        //Debug.Log(Difficulty);
        //Selection of Posts
        if (Difficulty == 1)
        {
            
            startposten = int.Parse(EasyPosts[Random.Range(0, EasyPosts.Length)]);
            endposten = int.Parse(EasyPosts[Random.Range(0, EasyPosts.Length)]);

            while (endposten - 0.1 < startposten && endposten + 0.1 > startposten)
            {
                endposten = int.Parse(EasyPosts[Random.Range(0, EasyPosts.Length)]);
            }

        }
        else if (Difficulty == 2)
        {
            startposten = int.Parse(MidPosts[Random.Range(0, MidPosts.Length)]);
            endposten = int.Parse(MidPosts[Random.Range(0, MidPosts.Length)]);
            while (endposten - 0.1 < startposten && endposten + 0.1 > startposten)
            {
                endposten = int.Parse(MidPosts[Random.Range(0, MidPosts.Length)]);
            }

        }
        else if (Difficulty == 3)
        {

            startposten = int.Parse(HardPosts[Random.Range(0, HardPosts.Length)]);
            endposten = int.Parse(HardPosts[Random.Range(0, HardPosts.Length)]);
            while (endposten - 0.1 < startposten && endposten + 0.1 > startposten)
            {
                endposten = int.Parse(HardPosts[Random.Range(0, HardPosts.Length)]);
            }
        }
        





        



        GameObject child = Posten.transform.Find(startposten.ToString()).gameObject;
        child.SetActive(true);
        GameObject child2 = Posten.transform.Find(endposten.ToString()).gameObject;
        child2.SetActive(true);
        //Charakter.transform.position = new Vector3(5f, 1f, 1f);
        EndX = child.transform.position.x;
        EndY = child.transform.position.y;
        EndZ = child.transform.position.z;
        Charakter.transform.position = new Vector3(EndX + 1f, EndY + 1f, EndZ);




    }



}
