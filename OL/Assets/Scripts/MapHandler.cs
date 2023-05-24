using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapHandler : MonoBehaviour
{
    public GameObject Map;
    
    private float cooldown = 0f;
    public bool MapActive = false;
    void Start()
    {
        Map.SetActive(false);
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        
        if (cooldown >= 0)
        {
            cooldown = cooldown - 1 * Time.deltaTime;
        } else
        {
            if (Input.GetKey("m"))
                {
                cooldown = 0.5f;
                    if (MapActive) {
                    MapActive = false;
                    Map.SetActive(false);
                    Cursor.lockState = CursorLockMode.Locked;

                } else {
                    MapActive = true;
                    Map.SetActive(true);
                    Cursor.lockState = CursorLockMode.None;

                }
                }
        }
    }
}
