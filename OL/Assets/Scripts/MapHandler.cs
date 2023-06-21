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
    void Start()
    {
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
                    CloseMap();

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
