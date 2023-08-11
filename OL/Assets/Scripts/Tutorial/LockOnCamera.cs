using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LockOnCamera : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject MainCam;
    //public float ExtraRotationX;
    //private Vector3 MainCamTransform;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 LookDirection = -1 * (MainCam.transform.position - transform.position);
        transform.rotation = Quaternion.LookRotation(LookDirection, Vector3.up);
       // Quaternion ExtraRotation = 
        
    }
}
