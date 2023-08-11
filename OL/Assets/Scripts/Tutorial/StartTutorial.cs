using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartTutorial : MonoBehaviour
{
    public float TransparentTime = 1f;
    public GameObject GetCanvasGroupFrom;
    public LerpScript LerperScript;
    private CanvasGroup ObjectCanvasGroup;
    void Start()
    {
        GetCanvasGroupFrom.SetActive(true);
    ObjectCanvasGroup = GetCanvasGroupFrom.GetComponent<CanvasGroup>();
    }


    public void StartTheTutorial()
    {
        StartCoroutine(FadeOut());
    }

    private IEnumerator FadeOut()
    {
        ObjectCanvasGroup.alpha = 1f;
        float DurationTime = 0f;
        float initialAlpha = ObjectCanvasGroup.alpha;
        LerperScript.LerpTo(1);

        while (DurationTime < TransparentTime)
        {
            float newAlpha = Mathf.Lerp(initialAlpha, 0f, DurationTime / TransparentTime);
            ObjectCanvasGroup.alpha = newAlpha;

            DurationTime += Time.deltaTime;
            yield return null;
        }


        ObjectCanvasGroup.alpha = 0f;
        //Debug.Log("Faded Starter Out");
        GetCanvasGroupFrom.SetActive(false);

    }
}
