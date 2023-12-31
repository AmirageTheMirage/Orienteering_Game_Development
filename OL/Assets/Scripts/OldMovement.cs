using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OldMovement : MonoBehaviour
{
    public float speed = 5;
    public float ThornSpeed = 5;

    public GameObject Map;
    public PauseMenuScript PauseScript;
    private bool AlreadyUnlocked = false;
    private bool AlreadyUnlocked2 = false;
    public AchievementHandler AchievScript;
    public TouchingThorns ThornsScript;
    private AudioHandler AudioScript;

    private Quaternion originalRotation;
    private Rigidbody rigidbody;
    private float FootStepInterval = 0.4f;
    private float TimeSinceLastFootStep = 0f;
    private bool IsMoving;
    private float RigidbodyMass;
    public bool Debug_OverrideSpeedSetting = false;
    private float PlayerSpeedSetting;

    public List<System.Func<float>> speedOverrides = new List<System.Func<float>>(); // This took me AGES

    void Awake()
    {
        PlayerSpeedSetting = PlayerPrefs.GetInt("Speed_Setting");
        if (Debug_OverrideSpeedSetting == false)
        {
            speed = (float)PlayerSpeedSetting;
        }
        AudioScript = GameObject.Find("FullAudioHandler").GetComponent<AudioHandler>(); //Get Audio Script
        rigidbody = GetComponent<Rigidbody>();
        originalRotation = transform.rotation;
        RigidbodyMass = rigidbody.mass;
        if (PlayerPrefs.GetInt("Achievement_8") == 1)
        {
            AlreadyUnlocked2 = true;
        }
        if (PlayerPrefs.GetInt("Achievement_2") == 1)
        {
            AlreadyUnlocked = true;
        }
    }

    void FixedUpdate()
    {


        if (Map.activeSelf == false && PauseScript.EscapeMenu == false)
        {

            Vector3 InputDirection = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
            Vector3 RotatedDirection = originalRotation * InputDirection;
            float PlayerMoveSpeed = 0f;
            if (ThornsScript.IsTouchingThorns)
            {

                PlayerMoveSpeed = ThornSpeed;

            }
            else
            {
                PlayerMoveSpeed = speed;
            }
            Vector3 TargetVelocity = RotatedDirection * PlayerMoveSpeed;

            rigidbody.velocity = new Vector3(TargetVelocity.x, rigidbody.velocity.y, TargetVelocity.z);
            IsMoving = TargetVelocity.magnitude > 0.2f; //This feels advanced to know
            if (IsMoving)
            {
                TimeSinceLastFootStep += Time.fixedDeltaTime;
                if (TimeSinceLastFootStep >= FootStepInterval)
                {
                    AudioScript.PlaySound("Footstep");
                    TimeSinceLastFootStep = 0f;
                }
            }
        }
        else
        {

            rigidbody.freezeRotation = true; //Dumb fix for Dumb bug.
            rigidbody.velocity = Vector3.zero;
        }

        if (Map.activeSelf == false && PauseScript.EscapeMenu == false)
        {

            originalRotation = transform.rotation;
        }

        if (AlreadyUnlocked2 == false && transform.position.y < -50f)
        {
            AchievScript.UnlockAchievement(8);
            AlreadyUnlocked2 = true;
        }





    }

    private void OnTriggerEnter(Collider other) //BeachBall Achievement
    {
        if (other.CompareTag("BeachBall") && AlreadyUnlocked == false)
        {
            AchievScript.UnlockAchievement(2);
            AlreadyUnlocked = true;
        }
    }
}