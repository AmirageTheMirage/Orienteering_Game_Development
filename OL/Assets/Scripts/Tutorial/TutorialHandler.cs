using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using TMPro;
using UnityEngine.SceneManagement;

public class TutorialHandler : MonoBehaviour
{
    public float TransparentTime = 3f;
    public float TransparentTimeForOrienteering = 3f;
    public GameObject TutorialElement;
    private CanvasGroup ObjectCanvasGroup;
    public int LerpCounter = 1;
    public LerpScript LerperScript;
    public GameObject OrienteeringObject;
    public TMP_Text TitleText;
    public TMP_Text ActualText;
    public GameObject ThankYouForPlaying;
    private CanvasGroup ThankYouForPlayingCanvasGroup;
    private bool SurpressProceed = true; //Yes... but this is right
    private int mode = 0;
    private CanvasGroup OrienteeringCanvasGroup;
    public GameObject ProceedToMainMenu;
    public GameObject GetChildFromThisPanel;


    string[] TitleTexts = { "ThisIsElement[0]", "Orienteering", "Compass-Usage", "Map", "Post-Search-Mode", "Orienteering-Mode", "Achievements", "Settings", "Savecodes" };
    string[] ActualTexts = {
    "ThisIsElement[0]",
    "Thank you for downloading \"Orienteering\"! This is a Learning\u2011Game about orientating in a 3D\u2011World. Please click \"Proceed\".",
    "While playing, look at the bottom right of your screen, as you will find a compass there, which will always point towards north. You can also choose your compass, as seen in the image below.",
    "You also have a map that you can open or close using the \"m\" key on your keyboard. Use the mouse to rotate your character towards north, so your map matches the environment around you.",
    "There are two gamemodes implemented. In Post\u2011Search\u2011Mode, you will start besides a post and have to search for the other one. Use your map to find out at which post you are, and move to the second post using the W, A, S and D keys on your keyboard. Walk close to the post you targeted so you can mark its discovery.",
    "In Orienteering\u2011Mode, you will have to guess your location. Use your compass and map to determine your location, then open the map and click at your suspected location. Click \"Confirm\" to get a rating of how close you actually were to your target.",
    "Achievements are voluntary sidemissions that you can fulfill if you want to. You can also \"Master\" a specific map by completing the Map\u2011Mission, which will reward you with a new compass!",
    "You can customize your experience using the \"Settings\"\u2011Tab located in the Main\u2011Menu. The settings can be used to add some extra challenge to your game by tweaking the \"Ingame Settings\", or optimizing your game using \"Main\u2011Settings\" incase it doesn't run smoothly.",
    "Lastly, if you want to share your experience with your friends, press your \"escape\" key while in a game and click \"Copy Gamecode\". Use this so called \"Gamecode\" in the Main\u2011Menu so you can play the exact scenario again, or share the code with your friends, so they can play your scenario."
};


    public void ToMainMenu()
    {
        PlayerPrefs.SetInt("TutorialAbsolved", 1);
        SceneManager.LoadScene(0);
    }
    private void Start()
    {
        TutorialElement.SetActive(false);
        OrienteeringObject.SetActive(false);
        ThankYouForPlaying.SetActive(false);
        ProceedToMainMenu.SetActive(false);
        ObjectCanvasGroup = TutorialElement.GetComponent<CanvasGroup>(); //Gets Canvas Group GameObject is in
        OrienteeringCanvasGroup = OrienteeringObject.GetComponent<CanvasGroup>();
        ThankYouForPlayingCanvasGroup = ThankYouForPlaying.GetComponent<CanvasGroup>();
        //Tutorial(1);

    }

    public void StartLogo()
    {
        if (mode == 0)
        {
            mode = 1;
            StartCoroutine(FadeIn());
            Debug.Log("Started");
        }
    }
    public void Tutorial(int Stage)
    {
        ActualText.text = ActualTexts[Stage];
        TitleText.text = TitleTexts[Stage];
        GameObject SetActiveChild = GetChildFromThisPanel.transform.Find(Stage.ToString()).gameObject;
        SetActiveChild.SetActive(true);
        if (Stage > 1)
        {
            GameObject SetNotActiveChild = GetChildFromThisPanel.transform.Find((Stage - 1).ToString()).gameObject;
            SetNotActiveChild.SetActive(false); //Sets past Childs not active
        }
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
        Debug.Log("FadeIn");
        if (mode == 0)
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
        else
        {
            if (mode == 1)
            {
                //Debug.Log("Started2");
                OrienteeringObject.SetActive(true);
                OrienteeringCanvasGroup.alpha = 0f;
                float DurationTime = 0f;
                float initialAlpha = OrienteeringCanvasGroup.alpha;


                while (DurationTime < TransparentTimeForOrienteering)
                {
                    float newAlpha = Mathf.Lerp(initialAlpha, 1f, DurationTime / TransparentTimeForOrienteering);
                    OrienteeringCanvasGroup.alpha = newAlpha;

                    DurationTime += Time.deltaTime; //+= is my newest learned coding shortcut :)
                    yield return null;
                }


                OrienteeringCanvasGroup.alpha = 1f;
                mode = 2;
                StartCoroutine(FadeIn());
                //SurpressProceed = false;
            } else
            {
                //ThankYouForPlaying
                // Debug.Log("Started2");
                ThankYouForPlaying.SetActive(true);
                ThankYouForPlayingCanvasGroup.alpha = 0f;
                float DurationTime = 0f;
                float initialAlpha = ThankYouForPlayingCanvasGroup.alpha;


                while (DurationTime < TransparentTimeForOrienteering)
                {
                    float newAlpha = Mathf.Lerp(initialAlpha, 1f, DurationTime / TransparentTimeForOrienteering);
                    ThankYouForPlayingCanvasGroup.alpha = newAlpha;

                    DurationTime += Time.deltaTime; //+= is my newest learned coding shortcut :)
                    yield return null;
                }


                ThankYouForPlayingCanvasGroup.alpha = 1f;
                ProceedToMainMenu.SetActive(true);
            }
        }
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
