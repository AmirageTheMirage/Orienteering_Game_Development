using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PostAssign : MonoBehaviour
{
    
    public GameObject Posten;
    public GameObject Charakter;
    public GameObject Fader;
    public int endposten = 0;
    private float EndX = 0f;
    private float EndY = 0f;
    private float EndZ = 0f;
    // Start is called before the first frame update
    void Start()
    {


        
        int startposten = Random.Range(150, 166);
         endposten = Random.Range(150, 166);
        

        while (endposten - 0.1 < startposten && endposten + 0.1 > startposten)
        {
            endposten = Random.Range(150, 166);
        }
        GameObject child = Posten.transform.Find(startposten.ToString()).gameObject;
        child.SetActive(true);
        GameObject child2 = Posten.transform.Find(endposten.ToString()).gameObject;
        child2.SetActive(true);
        //Charakter.transform.position = new Vector3(5f, 1f, 1f);
        EndX = child.transform.position.x;
        EndY = child.transform.position.y;
        EndZ = child.transform.position.z;
        Charakter.transform.position = new Vector3(EndX + 1f, EndY + 1f, EndZ);




    }



}
