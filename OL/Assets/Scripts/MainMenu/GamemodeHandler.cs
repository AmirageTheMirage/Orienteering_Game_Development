using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GamemodeHandler : MonoBehaviour
{
    public int GameMode;
    public GameObject Orienteering;
    public GameObject PostSearch;
    void Start()
    {
        PostSearch.SetActive(false);
        Orienteering.SetActive(false);
        GameMode = PlayerPrefs.GetInt("ModeDropdown_Setting");
       // Debug.Log(GameMode.ToString());
        if (GameMode == 0)
        {
            PostSearch.SetActive(true);
            Orienteering.SetActive(false);
        } else if (GameMode == 1)
        {
            PostSearch.SetActive(false);
            Orienteering.SetActive(true);
        }
    }

}
