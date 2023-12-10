using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomCamera : MonoBehaviour
{
    public float XDiff = 0;
    public float YDiff = 0;
    public float ZDiff = 0;
    public GameObject TimeToHide;
    public GameObject Wall;
    public int FogSetting = 0;
    void Start()
    {
        TimeToHide.SetActive(false);
        Wall.SetActive(false);
    }

    //Pos1: Vector3(405.450012,55.7000008,378.21701)
    void Update()
    {
        if(Input.GetKey(KeyCode.UpArrow))
        {
            gameObject.transform.position = new Vector3(gameObject.transform.position.x + XDiff * Time.deltaTime, gameObject.transform.position.y + YDiff * Time.deltaTime, gameObject.transform.position.z + ZDiff * Time.deltaTime);
        } else if (Input.GetKey(KeyCode.DownArrow))
        {
            gameObject.transform.position = new Vector3(gameObject.transform.position.x - XDiff * Time.deltaTime, gameObject.transform.position.y - YDiff * Time.deltaTime, gameObject.transform.position.z - ZDiff * Time.deltaTime);

        }


        if (Input.GetKeyDown(KeyCode.N))
        {
            FogSetting += 1;
            if (FogSetting == 1)
            {
                Wall.SetActive(false);
                RenderSettings.fogDensity = 0.005f;
            }
            else if (FogSetting == 2)
            {
                Wall.SetActive(false);
                RenderSettings.fogDensity = 0.01f;
            }
            else if (FogSetting == 3)
            {
                Wall.SetActive(true);
                RenderSettings.fogDensity = 0.03f;
            }
            else if (FogSetting == 4)
            {
                Wall.SetActive(true);
                RenderSettings.fogDensity = 0.06f;
                
            }
            else if (FogSetting == 5)
            {
                Wall.SetActive(true);
                RenderSettings.fogDensity = 0.2f;
                FogSetting = 0;
            }
        }
    }
}
