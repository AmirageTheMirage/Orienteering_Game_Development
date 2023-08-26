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
    public float Speed = 2f;
    public bool ShowLoading = true;
    // Start is called before the first frame update
    void Start()
    {
        StartFade();
    }

    public void StartFade()
    {
        AfterFP = 0f;
        FP = 1f;
        Fader.SetActive(true);
        Loading.SetActive(false);
        Color col = Fader.GetComponent<Image>().color;
        col.a = 1f;
        Fader.GetComponent<Image>().color = col;
    }

    // Update is called once per frame
    void Update()
    {
        if (AfterFP < 1) {

            AfterFP = AfterFP + 1f * Speed * Time.deltaTime;

        } else {
            Loading.SetActive(false);   
            FP = FP - 0.5f * Speed * Time.deltaTime;
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
