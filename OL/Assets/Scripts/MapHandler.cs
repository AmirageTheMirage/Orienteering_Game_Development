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
    private Light SunLightComponent;
    public Color EveningColor;
    public Color NightFogColor;
    public GameObject FogWall;
    public GameObject PostSearchCam;
    public GameObject OrienteeringCam;
    private AudioHandler AudioScript;
    private bool FlashlightActive;
    public int GameMode;
    private GameObject FlashLightObject;
    void Start()
    {
        FlashlightActive = false; 
        if (PlayerPrefs.GetInt("UseCode_Setting") == 1)
        {
            GameMode = PlayerPrefs.GetInt("ModePart_Code");
        }
        else
        {
            GameMode = PlayerPrefs.GetInt("ModeDropdown_Setting");
        }

        AudioScript = GameObject.Find("FullAudioHandler").GetComponent<AudioHandler>();
        SunLightComponent = DirectLight.GetComponent<Light>();
        
        FogWall.SetActive(false);
        if (PlayerPrefs.GetInt("UseCode_Setting") == 1) //Override with GameCode Input
        {
            TimeOfDay = PlayerPrefs.GetInt("TimePart_Code");
        }
        else
        {
            TimeOfDay = PlayerPrefs.GetInt("Time_Setting");
        }
        DirectLight.transform.eulerAngles = new Vector3(15f * TimeOfDay -90f, 90f, 0f); //So it's in east
        if (TimeOfDay <= 7 || TimeOfDay >= 16) //If Evening
        {
            if (TimeOfDay <= 5 || TimeOfDay >= 19)
            {
                DirectLight.SetActive(false);
                FlashlightActive = true;
            } else
            {
                SunLightComponent.color = EveningColor;
            }
        }
        
        //if Its Time = 0, The Angle is -90f
        //One Complete TurnAround = 360
        //360 / 24 * TimeOfDay
        if (PlayerPrefs.GetInt("UseCode_Setting") == 1) //Override with Code Input
        {
            FogSetting = PlayerPrefs.GetInt("FogPart_Code");
        }
        else
        {
            FogSetting = PlayerPrefs.GetInt("Fog_Setting");
        }
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
        



        if (FlashlightActive)
        {
            if (GameMode == 0)
            {
                FlashLightObject = PostSearchCam.transform.Find("FlashLightHolder").gameObject;
                FlashLightObject.SetActive(true);
            } else if (GameMode == 1)
            {
                FlashLightObject = OrienteeringCam.transform.Find("FlashLightHolder").gameObject;
                FlashLightObject.SetActive(true);
            }
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        //if (FlashlightActive)
        //{
        //    Vector3 FlashlightPosition;

        //    if (GameMode == 0) // If PostSearch
        //    {
        //        FlashlightPosition = PostSearchCam.transform.position;
        //    }
        //    else if (GameMode == 1) // If Orienteering
        //    {
        //        FlashlightPosition = OrienteeringCam.transform.position;
        //    }
        //    else
        //    {
        //        Debug.Log("GameMode couldn't be fetched (MapHandlerScript for Flashlight Part)");
        //        return;
        //    }

            
        //    FlashLightObject.transform.position = FlashlightPosition;
        //}

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
                        AudioScript.PlaySound("CloseMap");
                    }

                } else {
                    MapActive = true;
                    Map.SetActive(true);
                    Cursor.lockState = CursorLockMode.None;
                    AudioScript.PlaySound("OpenMap");

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
