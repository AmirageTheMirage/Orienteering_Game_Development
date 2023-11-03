using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotatingWindmill : MonoBehaviour
{
    public float speed;
    

    // Update is called once per frame
    void Update()
    {
        Vector3 rotationToAdd = new Vector3(0f,0f, -1f * speed * Time.deltaTime); //Windmill's FIXED!!!
        transform.Rotate(rotationToAdd);
    
}
}
