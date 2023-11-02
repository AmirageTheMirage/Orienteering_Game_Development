using UnityEngine;
using System.Collections;


public class LookAround : MonoBehaviour
{
    public Transform character;
    public GameObject Map;
    private float Sensitivity;
    public float smoothing = 1.5f;
    public PauseMenuScript PauseScript;
    private float StartCoolDown = 0.5f;
    private float Rotation;
    

    private Vector2 CurrentRotation;

    void Start()
    {
        Sensitivity = 120f; 
        //Application.targetFrameRate = 60;
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
                //CurrentRotation += mouseDelta * sensitivity * Time.deltaTime;
                CurrentRotation += mouseDelta * Sensitivity * 0.01f;
                CurrentRotation.y = Mathf.Clamp(CurrentRotation.y, -80, 80);
                transform.localRotation = Quaternion.Euler(-CurrentRotation.y, 0, 0);
                character.localRotation = Quaternion.Euler(0, CurrentRotation.x, 0);


            }
        }
    }

    

    
}
