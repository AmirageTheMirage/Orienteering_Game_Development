using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Segelflieger : MonoBehaviour
{
    private int MovingMode = 0;
    public float Speed;
    public GameObject Flieger;
    public int TimeMode;
    public int FogMode;

    // Start is called before the first frame update
    void Start()
    {
        Flieger.SetActive(false);
        TimeMode = PlayerPrefs.GetInt("Time_Setting");
        FogMode = PlayerPrefs.GetInt("Fog_Setting");
        if (TimeMode == 14 && FogMode == 2)
        {
            
            StartCoroutine(WaitForSpawn());
        } else
        {
            Debug.Log(TimeMode);
            Debug.Log(FogMode);
            Destroy(gameObject);
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        if (MovingMode == 1)
        {
            Vector3 currentPosition = transform.position;
            Vector3 newPosition = new Vector3(currentPosition.x + Speed * Time.deltaTime * -1f, currentPosition.y, currentPosition.z);
            transform.position = newPosition;
        }

        if (transform.position.x < -2000f)
        {

            Destroy(gameObject);
        }
    }

    private IEnumerator WaitForSpawn()
    {
        yield return new WaitForSeconds(6f);
        MovingMode = 1;
        Flieger.SetActive(true);
    }
}
