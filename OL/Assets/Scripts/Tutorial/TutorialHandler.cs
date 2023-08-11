using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class TutorialHandler : MonoBehaviour
{
    public float TransparentTime = 3f;
    public GameObject TutorialElement;
    private CanvasGroup ObjectCanvasGroup;
    public int LerpCounter = 1;
    public LerpScript LerperScript;
    private bool SurpressProceed = true; //Yes... but this is right

    private void Start()
    {
        TutorialElement.SetActive(false);
        ObjectCanvasGroup = TutorialElement.GetComponent<CanvasGroup>(); //Gets Canvas Group GameObject is in
        //Tutorial(1);
        
    }


    public void Tutorial(int Stage)
    {
        //Assign Texts
        TutorialElement.SetActive(true);
        StartCoroutine(FadeIn());
    }
    public void InitializeFadeOut()
    {
        if (!SurpressProceed)
        {
            //Debug.Log("TryingFadeOut");
            SurpressProceed = true;
            StartCoroutine(FadeOut());
            LerpCounter++;
            LerperScript.LerpTo(LerpCounter);
        }
    }


    private IEnumerator FadeIn()
    {
        ObjectCanvasGroup.alpha = 0f;
        float DurationTime = 0f;
        float initialAlpha = ObjectCanvasGroup.alpha;

        while (DurationTime < TransparentTime)
        {
            float newAlpha = Mathf.Lerp(initialAlpha, 1f, DurationTime / TransparentTime);
            ObjectCanvasGroup.alpha = newAlpha;

            DurationTime += Time.deltaTime; //+= is my newest learned coding shortcut :)
            yield return null;
        }

        
        ObjectCanvasGroup.alpha = 1f;
        SurpressProceed = false; //Not SurpressProceed but this prevents from pressing "Proceed" too early
    }
    private IEnumerator FadeOut()
    {
        //Debug.Log("StartingFadeOut");
        
        ObjectCanvasGroup.alpha = 1f;
        float DurationTime = 0f;
        float initialAlpha = ObjectCanvasGroup.alpha;

        while (DurationTime < TransparentTime)
        {
            float newAlpha = Mathf.Lerp(initialAlpha, 0f, DurationTime / TransparentTime);
            ObjectCanvasGroup.alpha = newAlpha;

            DurationTime += Time.deltaTime;
            yield return null;
        }

        
        ObjectCanvasGroup.alpha = 0f;
        
        TutorialElement.SetActive(false);
        //Debug.Log("CompletedFadeOut");
    }
}
