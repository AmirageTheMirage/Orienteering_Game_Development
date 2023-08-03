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
    public bool IsMaze;
    public float raycastDistance = 100f;
    public LayerMask terrainLayerMask;
    public GameObject DebugObject;

    // Start is called before the first frame update
    void Start()
    {
        Ground();
    }

    private void Ground()
    {
        TerrainCollider.SetActive(true);
        if (IsMaze)
        {
            Target.transform.position = new Vector3(Random.Range(460f, 540), 100f, Random.Range(460f, 540f));
        }
        else
        {
            Target.transform.position = new Vector3(Random.Range(260f, 740f), 100f, Random.Range(260f, 740f));
        }
        if (IsMaze)
        {
            RaycastHit hit23;
            if (Physics.Raycast(Target.transform.position, Vector3.down, out hit23, raycastDistance))
            {
                DebugObject.transform.position = hit23.point;
                if (DebugObject.transform.position.y > 11f) // Means too high up for a Maze
                {
                    Debug.Log("TrySettingPlayerNew");
                    Ground();
                } else
                {
                    SetPlayer();
                }
            }
        } else
        {
            SetPlayer();
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
    }

    void Update()
    {
        //if (Input.GetKey("g"))
        //{
        //    Ground();
        //}
    }
}
