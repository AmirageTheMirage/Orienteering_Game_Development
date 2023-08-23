using UnityEngine;

public class LookAround : MonoBehaviour
{
    public Transform character;
    public float sensitivity;
    public float smoothing = 1.5f;
    public GameObject Map;
    public PauseMenuScript PauseScript;

    private Vector2 currentRotation;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        
    }

    void Update()
    {
        if (Map.activeSelf == false && PauseScript.EscapeMenu == false)
        {
            Vector2 mouseDelta = new Vector2(Input.GetAxisRaw("Mouse X"), Input.GetAxisRaw("Mouse Y"));
            currentRotation += mouseDelta * sensitivity * Time.deltaTime;

            currentRotation.y = Mathf.Clamp(currentRotation.y, -80, 80);

            transform.localRotation = Quaternion.Euler(-currentRotation.y, 0, 0);
            character.localRotation = Quaternion.Euler(0, currentRotation.x, 0);
        }
    }

}
