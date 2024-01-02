using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Martinsflue_AssignMap : MonoBehaviour
{
    public GameObject NormalMap;
    public GameObject HeightOnly;
    public GameObject StonesOnly;
    public GameObject PathsOnly;
    public int SpecialMapChosen;

    void Start()
    {
        if (PlayerPrefs.HasKey("SpecialMap_Setting")){

        SpecialMapChosen = PlayerPrefs.GetInt("SpecialMap_Setting");
        } else
        {
            SpecialMapChosen = 1; //Should never come so far, as SpecialMap_Setting is assigned in MainMenu
        }
        FetchMap(SpecialMapChosen);
    }

    public void FetchMap(int Chosen)
    {
        if (Chosen == 1)
        {
            NormalMap.SetActive(true);
            HeightOnly.SetActive(false);
            StonesOnly.SetActive(false);
            PathsOnly.SetActive(false);
        } else if (Chosen == 2)
        {
            NormalMap.SetActive(false);
            HeightOnly.SetActive(true);
            StonesOnly.SetActive(false);
            PathsOnly.SetActive(false);
        }
        else if (Chosen == 3)
        {
            NormalMap.SetActive(false);
            HeightOnly.SetActive(false);
            StonesOnly.SetActive(true);
            PathsOnly.SetActive(false);
        }
        else if (Chosen == 4)
        {
            NormalMap.SetActive(false);
            HeightOnly.SetActive(false);
            StonesOnly.SetActive(false);
            PathsOnly.SetActive(true);
        }
    }

    
}
