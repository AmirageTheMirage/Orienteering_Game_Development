using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotatingWindmill : MonoBehaviour
{
    public float speed;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 rotationToAdd = new Vector3(0f,0f, -1f * speed * Time.deltaTime);
        transform.Rotate(rotationToAdd);
    
}
}
