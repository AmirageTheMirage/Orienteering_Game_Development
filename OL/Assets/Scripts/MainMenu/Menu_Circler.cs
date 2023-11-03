using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Menu_Circler : MonoBehaviour

    
    
{
    public GameObject ObjectToRotate;
    public float Speed;
    // Start is called before the first frame update
    void Start()
    {
        ObjectToRotate.transform.Rotate(0f, Random.Range(-180f, 180f), 0f, Space.World); //Random Rotation to begin with
    }

    // Update is called once per frame
    void Update()
    {
        ObjectToRotate.transform.Rotate(0f, Speed * Time.deltaTime, 0f, Space.World); //Rotate object
    }
}
