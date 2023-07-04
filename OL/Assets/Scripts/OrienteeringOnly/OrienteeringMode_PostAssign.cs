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
    
    // Start is called before the first frame update
    void Start()
    {
        
        Ground();
        
    }

    // Update is called once per frame
    private void Ground()
    {
        TerrainCollider.SetActive(true);
        Target.transform.position = new Vector3(Random.Range(260f, 740f), 100f, Random.Range(260f, 740f));
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

        if (Input.GetKey("g"))
        {
            
            Ground();
        }
    }
}
