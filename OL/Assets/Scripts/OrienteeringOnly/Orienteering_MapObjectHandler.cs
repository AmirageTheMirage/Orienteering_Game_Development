using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Orienteering_MapObjectHandler : MonoBehaviour
{
    public GameObject UI_Target;
    public GameObject UI_Player;
    public GameObject ActualPlayerPosition;
    private float ActualPlayerPositionX;
    private float ActualPlayerPositionZ;
    public GameObject MapUI;
    private bool AlreadySetTarget = false;
    public bool ended = false;
    public GameObject ActualMapUI;
    public GameObject SideUI;
    public GameObject EndUI;
    public GameObject Compass;
    public bool IsMaze;
    private AudioHandler AudioScript;
    public Vector2 GoToPos;
    public bool FirstTimeMoving = true;
    public float Dis = 0f;
    

    void Start()
    {
        
        AudioScript = GameObject.Find("FullAudioHandler").GetComponent<AudioHandler>();
        UI_Player.SetActive(false);
        UI_Target.SetActive(false);
        SideUI.SetActive(false);
        EndUI.SetActive(false);
        Compass.SetActive(true);
    }
    void FixedUpdate()
    {
        if (FirstTimeMoving == false)
        {
            Dis = Vector2.Distance(GoToPos, UI_Player.GetComponent<RectTransform>().anchoredPosition);
            
            if (Dis >= 0.1f)
            {
                UI_Player.GetComponent<RectTransform>().anchoredPosition = Vector2.Lerp(UI_Player.GetComponent<RectTransform>().anchoredPosition, GoToPos, 0.5f);
            }
        }
    }
    void Update()
    {
        
        if (MapUI.activeSelf)
        {
            SideUI.SetActive(true); //Map Side UI for Orienteering Mode
            if (AlreadySetTarget)
            {
                UI_Player.SetActive(true);

            }
            else
            {
                UI_Player.SetActive(false);
            }

            if (Input.GetMouseButtonDown(0))
            {
                Debug.Log("MouseClick");

                // Check if the mouse pointer is touching the ActualMapUI
                if (IsMouseTouchingUI(ActualMapUI))
                {
                    SetPositionOfPlayer(Input.mousePosition.x, Input.mousePosition.y);
                }
                else
                {
                    Debug.Log("Not Touching");
                }
            }
        }
        else
        {
            UI_Player.SetActive(false);
            SideUI.SetActive(false);
        }
    }

    public void SetPositionOfTarget()
    {



        ActualPlayerPositionX = (ActualPlayerPosition.transform.position.x - 500f) * 300f / 600f;
        ActualPlayerPositionZ = (ActualPlayerPosition.transform.position.z - 500f) * 300f / 600f;

        if (IsMaze)
        {
            UI_Target.GetComponent<RectTransform>().anchoredPosition = new Vector2(ActualPlayerPositionX * 7f, ActualPlayerPositionZ * 7f); //Bc 5.26 times smaller Map Area (95 Wide for some reason)
        } else { 
        UI_Target.GetComponent<RectTransform>().anchoredPosition = new Vector2(ActualPlayerPositionX, ActualPlayerPositionZ);
        }
        // Debug.Log(ActualPlayerPositionX.ToString());
        // Debug.Log(ActualPlayerPositionZ.ToString());

    }

    public void SetPositionOfPlayer(float x, float y)
    {
        UI_Player.SetActive(true);
        AlreadySetTarget = true;
        AudioScript.PlaySound("Select3");

        RectTransform canvasRectTransform = UI_Player.GetComponentInParent<Canvas>().GetComponent<RectTransform>(); //Get Rect Transform

        Vector2 localMousePosition;
        RectTransformUtility.ScreenPointToLocalPointInRectangle(canvasRectTransform, new Vector2(x, y), null, out localMousePosition);
        if (FirstTimeMoving)
        {
            UI_Player.GetComponent<RectTransform>().anchoredPosition = localMousePosition;
            GoToPos = localMousePosition;
            FirstTimeMoving = false;
        } else
        {
            GoToPos = localMousePosition;
        }
    }

    public void EndOfTheMode() //If Button is pressed, go to EndUI Mode
    {
        if (AlreadySetTarget)
        {
            AudioScript.PlaySound("Select1");
            ended = true;
            EndUI.SetActive(true);
            UI_Target.SetActive(true);
            UI_Player.SetActive(true);
            SideUI.SetActive(false);
            Compass.SetActive(false);
            gameObject.SetActive(false);
        }
    }

    

    private bool IsMouseTouchingUI(GameObject uiElement) //Only set a Guess on the Map, not beside the map.
    {
        RectTransform rectTransform = uiElement.GetComponent<RectTransform>();
        Vector2 mousePosition = Input.mousePosition;

        // Convert the mouse position to a position relative to the UI element
        Vector2 localMousePosition;
        RectTransformUtility.ScreenPointToLocalPointInRectangle(rectTransform, mousePosition, null, out localMousePosition);

        // Check if the local mouse position is within the UI element's bounds
        if (RectTransformUtility.RectangleContainsScreenPoint(rectTransform, mousePosition))
        {
            return true;
        }

        return false;
    }
}
