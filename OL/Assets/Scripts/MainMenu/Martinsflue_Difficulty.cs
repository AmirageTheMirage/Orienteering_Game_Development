using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Martinsflue_Difficulty : MonoBehaviour
{
    public GameObject Highlighter;
    public GameObject Object1;
    public GameObject Object2;
    public GameObject Object3;
    public GameObject Object4;

    public GameObject SP_Object1; //SP = SelectedParent
    public GameObject SP_Object2;
    public GameObject SP_Object3;
    public GameObject SP_Object4;
    public Vector3 LerpTo;
    public bool HasToLerp = false;
    private AudioHandler AudioScript;
    public int MapChosen = 1;
    void Start()
    {

        
        AudioScript = GameObject.Find("FullAudioHandler").GetComponent<AudioHandler>();
        if (PlayerPrefs.HasKey("SpecialMap_Setting"))
        {
            //Cool, it exists
            MapChosen = PlayerPrefs.GetInt("SpecialMap_Setting");
            
        } else
        {
            PlayerPrefs.SetInt("SpecialMap_Setting", MapChosen);
            PlayerPrefs.Save();
        }
        ActualizeMap(MapChosen);
        if (MapChosen == 1)
        {
        Highlighter.transform.position = Object1.transform.position;

        } else if (MapChosen == 2)
        {
            Highlighter.transform.position = Object2.transform.position;
        }
        else if (MapChosen == 3)
        {
            Highlighter.transform.position = Object3.transform.position;
        }
        else if (MapChosen == 4)
        {
            Highlighter.transform.position = Object4.transform.position;
        }


    }

    // Update is called once per frame
    void Update()
    {
        if (HasToLerp)
        {
            Highlighter.transform.position = Vector3.Lerp(Highlighter.transform.position, LerpTo, 15f * Time.deltaTime);
            if (Vector3.Distance(Highlighter.transform.position, LerpTo) <= 0.1f)
            {
                HasToLerp = false;
            }
        }
    }


    public void ChoseSpecialMode(int Choix)
    {
        MapChosen = Choix;
        PlayerPrefs.SetInt("SpecialMap_Setting", MapChosen);
        PlayerPrefs.Save();
        AudioScript.PlaySound("Select3");
            if (Choix == 1)
            {
                LerpTo = Object1.transform.position;
                ActualizeMap(1);
            } else if (Choix == 2)
            {
                LerpTo = Object2.transform.position;
                ActualizeMap(2);
            }
            else if (Choix == 3)
            {
                LerpTo = Object3.transform.position;
                ActualizeMap(3);
            }
            else if (Choix == 4)
            {
                LerpTo = Object4.transform.position;
                ActualizeMap(4);
            }

            HasToLerp = true;


        
    }

    public void ActualizeMap(int which)
    {
        if (which == 1)
        {
            SP_Object1.SetActive(true);
            SP_Object2.SetActive(false);
            SP_Object3.SetActive(false);
            SP_Object4.SetActive(false);
        } else if (which == 2)
        {
            SP_Object1.SetActive(false);
            SP_Object2.SetActive(true);
            SP_Object3.SetActive(false);
            SP_Object4.SetActive(false);
        }
        else if (which == 3)
        {
            SP_Object1.SetActive(false);
            SP_Object2.SetActive(false);
            SP_Object3.SetActive(true);
            SP_Object4.SetActive(false);
        }
        else if (which == 4)
        {
            SP_Object1.SetActive(false);
            SP_Object2.SetActive(false);
            SP_Object3.SetActive(false);
            SP_Object4.SetActive(true);
        }
    }
}
