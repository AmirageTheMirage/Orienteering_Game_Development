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

    private Quaternion originalRotation;
    private Rigidbody rigidbody;

    public List<System.Func<float>> speedOverrides = new List<System.Func<float>>(); // This took me AGES

    void Awake()
    {
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

            } else
            {
                PlayerMoveSpeed = speed;
            }
            Vector3 targetVelocity = RotatedDirection * PlayerMoveSpeed;

            rigidbody.velocity = new Vector3(targetVelocity.x, rigidbody.velocity.y, targetVelocity.z);
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

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("BeachBall") && AlreadyUnlocked == false)
        {
            AchievScript.UnlockAchievement(2);
            AlreadyUnlocked = true;
        }
    }
}
