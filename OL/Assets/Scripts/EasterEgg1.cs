using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EasterEgg1 : MonoBehaviour
{
    public GameObject EasterEggText;
    private int Randomness;

    void Start()
    {
        Randomness = Random.Range(0, 1000);
        //Debug.Log("EasterEggNumber: " +Randomness);
        if (Randomness <= 1)
        {
            Debug.Log("The 0.1% Text has spawned!"); //Really Rare
        } else
        {
            Destroy(EasterEggText);
        }
    }
}

