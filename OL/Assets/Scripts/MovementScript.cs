using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementScript : MonoBehaviour
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
    public int PlayerSpeedSetting;
    public bool Debug_OverrideSpeedSetting = false;
    public bool IsOnTerrain = true;

    private Vector3 ExtraVector;
 

    public List<System.Func<float>> speedOverrides = new List<System.Func<float>>(); // This took me AGES

    void Awake()
    {
        AudioScript = GameObject.Find("FullAudioHandler").GetComponent<AudioHandler>(); //Get Audio Script
        rigidbody = GetComponent<Rigidbody>();
        originalRotation = transform.rotation;
        if (PlayerPrefs.GetInt("Achievement_8") == 1)
        {
            AlreadyUnlocked2 = true;
        }
        if (PlayerPrefs.GetInt("Achievement_2") == 1)
        {
            AlreadyUnlocked = true;
        }
        PlayerSpeedSetting = PlayerPrefs.GetInt("Speed_Setting");
        if (Debug_OverrideSpeedSetting == false)
        {
            speed = (float)PlayerSpeedSetting;
        }
        SnapToGround();
    }

    void FixedUpdate()
    {

            OnTerrainCheck();
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
            //Debug.Log(rigidbody.velocity.y);
            if (rigidbody.velocity.y >= 0f)
            {
                rigidbody.velocity = new Vector3(TargetVelocity.x, 0f, TargetVelocity.z);

            } else
            {
                rigidbody.velocity = new Vector3(TargetVelocity.x, rigidbody.velocity.y, TargetVelocity.z);

            }
                IsMoving = TargetVelocity.magnitude > 0.2f; //This feels advanced to know
                if (IsMoving && IsOnTerrain)
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

    private void SnapToGround()
    {
        RaycastHit MyRay;
        if (Physics.Raycast(transform.position, Vector3.down, out MyRay, 1000f))
        {
            transform.position = new Vector3(transform.position.x, MyRay.point.y, transform.position.z);
        }
    }

    private void OnTerrainCheck()
    {
        RaycastHit MyRay2;
        ExtraVector = new Vector3(transform.position.x, transform.position.y + 0.5f, transform.position.z);
        if (Physics.Raycast(ExtraVector, Vector3.down, out MyRay2, 1f))
        {
            IsOnTerrain = true;
        } else
        {
            IsOnTerrain = false;
        }
    }
    
}
