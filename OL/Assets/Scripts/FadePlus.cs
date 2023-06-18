using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadePlus : MonoBehaviour
{
    public GameObject Fader;
    public GameObject FaderHandler;
    public GameObject Loading;
    private float AfterFP = 0f;
    private float FP = 1f; //FP = FaderPercent
    // Start is called before the first frame update
    void Start()
    {
        Loading.SetActive(false);
        Color col = Fader.GetComponent<Image>().color;
        col.a = 1f;
        Fader.GetComponent<Image>().color = col;
    }

    // Update is called once per frame
    void Update()
    {
        if (AfterFP < 1) {

            AfterFP = AfterFP + 1f * Time.deltaTime;

        } else {
            Loading.SetActive(false);   
            FP = FP - 0.5f * Time.deltaTime;
            Color col = Fader.GetComponent<Image>().color;
            col.a = FP;
            Fader.GetComponent<Image>().color = col;

            if (FP <= 0f)
            {
                Fader.SetActive(false);
                FaderHandler.SetActive(false);
            }
        }
    }
}
