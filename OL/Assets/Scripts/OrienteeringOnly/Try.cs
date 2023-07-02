using UnityEngine;
using UnityEngine.UI;

public class Try : MonoBehaviour
{
    private RectTransform rectTransform;


    private void Start()
    {
        rectTransform = GetComponent<RectTransform>();
    }

    private void Update()
    {
        Vector2 mousePosition = Input.mousePosition;

        // Convert the mouse position to a position relative to the Canvas
        RectTransform canvasRectTransform = GetComponentInParent<Canvas>().GetComponent<RectTransform>();
        RectTransformUtility.ScreenPointToLocalPointInRectangle(canvasRectTransform, mousePosition, null, out Vector2 localMousePosition);

        // Set the anchored position of the UI element to the mouse position
        rectTransform.anchoredPosition = localMousePosition;
    }
}
