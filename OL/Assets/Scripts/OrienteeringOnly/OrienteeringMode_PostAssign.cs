using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrienteeringMode_PostAssign : MonoBehaviour
{
    public GameObject Player;
    public GameObject Target;
    public LayerMask OurGround;
    public GameObject TerrainCollider;
    public Orienteering_MapObjectHandler MapScript;
    private bool IsMaze;
    public float raycastDistance = 100f;
    public LayerMask terrainLayerMask;
    public LayerMask FieldLayer;
    public GameObject DebugObject;
    public IsMapMaze IsMapMazeScript;


    // Start is called before the first frame update
    void Start()
    {
        IsMaze = IsMapMazeScript.IsMaze;
        Ground();
    }

    private void Ground()
    {
        TerrainCollider.SetActive(true);
        if (PlayerPrefs.GetInt("UseCode_Setting") == 1)
        {
            float OrientX = (float)PlayerPrefs.GetInt("OrienteeringX_Code");
            //float OrientY = PlayerPrefs.GetInt("OrienteeringY_Code");
            float OrientZ = (float)PlayerPrefs.GetInt("OrienteeringZ_Code");
            //Player.transform.position = new Vector3((float)OrientX, (float)OrientY, (float)OrientZ);
            Target.transform.position = new Vector3(OrientX, 100f, OrientZ);
            //Target.transform.position = new Vector3(Target.transform.position.x, Target.transform.position.y + 1.9f, Target.transform.position.z);
            MapScript.SetPositionOfTarget();

        }
        else
        {
            
            if (IsMaze) //Mazes are only 100x100 instead of 500x500
            {
                Target.transform.position = new Vector3(Random.Range(460f, 540), 100f, Random.Range(460f, 540f));
            }
            else
            {
                Target.transform.position = new Vector3(Random.Range(260f, 740f), 100f, Random.Range(260f, 740f));
            }
        }
        if (PlayerPrefs.GetInt("UseCode_Setting") == 1)
        {
            Ray ray = new Ray(Target.transform.position, Vector3.down);
            RaycastHit hit;
            SetPlayer();


        } else  if (IsMaze)
            {
                RaycastHit hit23;
                if (Physics.Raycast(Target.transform.position, Vector3.down, out hit23, raycastDistance))
                {
                    DebugObject.transform.position = hit23.point;
                    if (DebugObject.transform.position.y > 11f) // Means too high up for a Maze, means spawned in a wall
                    {
                        Debug.Log("TrySettingPlayerNew");
                        Ground();
                    }
                    else
                    {
                        SetPlayer();
                    }
                }
            }
            else
            {
                    Ray ray = new Ray(Target.transform.position, Vector3.down);
                    RaycastHit hit;
                    if (Physics.Raycast(ray, out hit, Mathf.Infinity, FieldLayer)) //If Hit a field, try again.
                    {
                        Debug.Log("TrySettingPlayerNew");
                        Ground();
                    }
                    else
                    {
                        SetPlayer();
                    }
                }
        
        
    }

    private void SetPlayer()
    {
        RaycastHit hit;

        if (Physics.Raycast(Target.transform.position, Vector3.down, out hit, Mathf.Infinity, OurGround))
        {
            Target.transform.position = hit.point;
        }

        Target.transform.position = new Vector3(Target.transform.position.x, Target.transform.position.y + 1.9f, Target.transform.position.z);
        Player.transform.position = new Vector3(Target.transform.position.x, Target.transform.position.y, Target.transform.position.z);
        TerrainCollider.SetActive(false);
        MapScript.SetPositionOfTarget();
        PlayerPrefs.SetInt("OrienteeringX_Code", Mathf.RoundToInt(Player.transform.position.x));
        //PlayerPrefs.SetInt("OrienteeringY_Code", Mathf.RoundToInt(Player.transform.position.y));
        PlayerPrefs.SetInt("OrienteeringZ_Code", Mathf.RoundToInt(Player.transform.position.z));
    }

    
}
