using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudSpawner : MonoBehaviour
{
    public float CloudHeight;
   // public GameObject CloudSpawnerObject;
    public GameObject Cloud1;
    public GameObject Cloud2;
    public GameObject Cloud3;
    public GameObject Cloud4;
    public GameObject Cloud5;
    private GameObject Cloud;
    void Start()
    {
        Reassign();

        for (int i = 0; i < 50; i++)
        {
            StartSpawn();
        }

        StartCoroutine(CloudSpawn());


    }

    // Update is called once per frame
    void Update()
    {

    }

    private void Reassign()
    {
        gameObject.transform.position = new Vector3(Random.Range(-1000f, 2000f), CloudHeight, -1000f);
    }
    private void StartSpawn()
    {
        gameObject.transform.position = new Vector3(Random.Range(-1000f, 2000f), CloudHeight, Random.Range(-1000f, 2000f));
        int cloudNumber = Random.Range(1, 6);
        switch (cloudNumber)
        {
            case 1:
                Cloud = Cloud1;
                break;
            case 2:
                Cloud = Cloud2;
                break;
            case 3:
                Cloud = Cloud3;
                break;
            case 4:
                Cloud = Cloud4;
                break;
            case 5:
                Cloud = Cloud5;
                break;
        }
        GameObject CloudClone = Instantiate(Cloud, transform.position, Quaternion.identity);
        CloudClone.SetActive(true);
        
    }

    private IEnumerator CloudSpawn()
    {

        while (true)
        {
            Reassign();
            int cloudNumber = Random.Range(1, 6);
            switch (cloudNumber)
            {
                case 1:
                    Cloud = Cloud1;
                    break;
                case 2:
                    Cloud = Cloud2;
                    break;
                case 3:
                    Cloud = Cloud3;
                    break;
                case 4:
                    Cloud = Cloud4;
                    break;
                case 5:
                    Cloud = Cloud5;
                    break;
            }
            GameObject CloudClone = Instantiate(Cloud, transform.position, Quaternion.identity);
            CloudClone.SetActive(true);
            
            yield return new WaitForSeconds(1f);
        }
    }

}
