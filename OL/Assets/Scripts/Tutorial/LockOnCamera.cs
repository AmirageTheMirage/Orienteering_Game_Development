using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LockOnCamera : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject MainCam;
    
    void Update() //Always lock on Camera, could've put this into another Script
    {
        Vector3 LookDirection = -1 * (MainCam.transform.position - transform.position);
        transform.rotation = Quaternion.LookRotation(LookDirection, Vector3.up);
       // Quaternion ExtraRotation = 
        
    }
}
