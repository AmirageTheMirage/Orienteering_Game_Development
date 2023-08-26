using UnityEngine;
using System.Collections;


public class LookAround : MonoBehaviour
{
    public Transform character;
    public float sensitivity;
    public float smoothing = 1.5f;
    public GameObject Map;
    public PauseMenuScript PauseScript;
    private float StartCoolDown = 0.5f;
    

    private Vector2 currentRotation;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        character.localRotation = Quaternion.Euler(0, 0, 0);
        

    }

    void Update()
    {
        if (StartCoolDown > 0f)
        {
            StartCoolDown = StartCoolDown - 1f * Time.deltaTime;
        }
        else
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

    
}
