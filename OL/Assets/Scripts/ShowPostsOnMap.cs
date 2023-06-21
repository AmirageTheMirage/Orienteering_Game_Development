using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowPostsOnMap : MonoBehaviour
{
    public MapHandler MapScript;
    public bool MapShowing = false;
    
    void Start()
    {
        
    }
    // Update is called once per frame
    void Update()
    {
        MapShowing = MapScript.MapActive;
        GameObject child = gameObject.transform.Find("Kreis").gameObject;

        if (MapShowing && MapScript.EscapeMen == false)
        {
            child.SetActive(true);
        } else
        {
            child.SetActive(false);
        }
    }
}
