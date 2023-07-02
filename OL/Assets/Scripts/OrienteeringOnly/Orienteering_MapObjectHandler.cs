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
    void Start()
    {
        UI_Player.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (MapUI.activeSelf)
        {
            if (Input.GetMouseButtonDown(0))
            {
                Debug.Log("MouseClick");
                SetPositionOfPlayer(Input.mousePosition.x, Input.mousePosition.y);
            }
        }
    }

    public void SetPositionOfTarget()
    {
        //Karte Range: -160 zu 160 = 320 Range
        // Welt Range: von -300 zu 300 = 600 Range, Mitte bei 500|500
        ActualPlayerPositionX = (ActualPlayerPosition.transform.position.x - 500f) * 320f / 600f;
        ActualPlayerPositionZ = (ActualPlayerPosition.transform.position.z - 500f) * 320f / 600f;
       
        Debug.Log(ActualPlayerPositionX.ToString());
        Debug.Log(ActualPlayerPositionZ.ToString());
        UI_Target.GetComponent<RectTransform>().anchoredPosition = new Vector2(ActualPlayerPositionX, ActualPlayerPositionZ);

    }

    public void SetPositionOfPlayer(float x, float y)
    {
        UI_Player.SetActive(true);
        Debug.Log(x.ToString());
        Debug.Log(y.ToString());

        // Get the RectTransform of the Canvas
        RectTransform canvasRectTransform = UI_Player.GetComponentInParent<Canvas>().GetComponent<RectTransform>();

        // Convert the mouse position to a position relative to the Canvas
        Vector2 localMousePosition;
        RectTransformUtility.ScreenPointToLocalPointInRectangle(canvasRectTransform, new Vector2(x, y), null, out localMousePosition);

        // Set the anchored position of the UI_Player object to the mouse position
        UI_Player.GetComponent<RectTransform>().anchoredPosition = localMousePosition;
    }
}
