using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MapHandler : MonoBehaviour
{
    public GameObject Map;
    
    private float cooldown = 0f;
    public bool MapActive = false;
    public PauseMenuScript PauseScript;
    public bool EscapeMen = false;
    public GameObject Orienteering_EndUI;
    public GameObject DirectLight;
    private int TimeOfDay;
    private int FogSetting;
    public Color NightFogColor;
    public GameObject FogWall;
    void Start()
    {
        FogWall.SetActive(false);
        TimeOfDay = PlayerPrefs.GetInt("Time_Setting");
        DirectLight.transform.eulerAngles = new Vector3(360f / 24f * TimeOfDay - 90f, 0f, 0f);
        //if Its Time = 0, The Angle is -90f
        //One Complete TurnAround = 360
        //360 / 24 * TimeOfDay

        FogSetting = PlayerPrefs.GetInt("Fog_Setting");
        if (FogSetting == 1)
        {
            RenderSettings.fogDensity = 0.005f;
        } else if (FogSetting == 2)
        {
            RenderSettings.fogDensity = 0.01f;
        } else if (FogSetting == 3)
        {
            RenderSettings.fogDensity = 0.03f;
        }
        else if (FogSetting == 4)
        {
            RenderSettings.fogDensity = 0.06f;
            FogWall.SetActive(true);
        }
        else if (FogSetting == 5)
        {
            RenderSettings.fogDensity = 0.2f;
            FogWall.SetActive(true);
        }
        if (TimeOfDay >= 20 || TimeOfDay <= 4)
        {
            RenderSettings.fogColor = NightFogColor;
            if (FogSetting < 3)
            {
                RenderSettings.fogDensity = 0.015f;
            }

        }
        Map.SetActive(false);
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        EscapeMen = PauseScript.EscapeMenu;

        if (cooldown >= 0)
        {
            cooldown = cooldown - 1 * Time.deltaTime;
        } else
        {
            if (Input.GetKey("m") && PauseScript.EscapeMenu == false)
                {
                cooldown = 0.5f;
                    if (MapActive) {
                    if (Orienteering_EndUI.activeSelf == false)
                    {
                        CloseMap();
                    }

                } else {
                    MapActive = true;
                    Map.SetActive(true);
                    Cursor.lockState = CursorLockMode.None;

                }
                }
        }
    }

    public void CloseMap()
    {
        MapActive = false;
        Map.SetActive(false);
        Cursor.lockState = CursorLockMode.Locked;
    }
}
