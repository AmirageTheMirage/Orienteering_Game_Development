using System.Collections.Generic;
using UnityEngine;

public class FirstPersonMovement : MonoBehaviour
{
    public float speed = 5;

    [Header("Running")]
    public bool canRun = true;
    public bool IsRunning { get; private set; }
    public float runSpeed = 9;
    public KeyCode runningKey = KeyCode.LeftShift;
    public GameObject Map;
    public PauseMenuScript PauseScript;
    private bool AlreadyUnlocked = false;
    private bool AlreadyUnlocked2 = false;
    public AchievementHandler AchievScript;

    Rigidbody rigidbody;
    /// <summary> Functions to override movement speed. Will use the last added override. </summary>
    public List<System.Func<float>> speedOverrides = new List<System.Func<float>>();



    void Awake()
    {
        // Get the rigidbody on this.
        rigidbody = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        if (Map.activeSelf == false && PauseScript.EscapeMenu == false)
        {
            // Update IsRunning from input.
            IsRunning = canRun && Input.GetKey(runningKey);

            // Get targetMovingSpeed.
            float targetMovingSpeed = IsRunning ? runSpeed : speed;
            if (speedOverrides.Count > 0)
            {
                targetMovingSpeed = speedOverrides[speedOverrides.Count - 1]();
            }

            // Get targetVelocity from input.
            Vector2 targetVelocity = new Vector2(Input.GetAxis("Horizontal") * targetMovingSpeed, Input.GetAxis("Vertical") * targetMovingSpeed);

            // Apply movement.
            rigidbody.velocity = transform.rotation * new Vector3(targetVelocity.x, rigidbody.velocity.y, targetVelocity.y);
        }

        if (AlreadyUnlocked2 == false && transform.position.y < -50f)
        {
            AchievScript.UnlockAchievement(8);
            AlreadyUnlocked2 = true;

        }
    }


    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Collided");
        if (other.CompareTag("BeachBall"))
        {
            Debug.Log("ItsBeachBall");
            if (AlreadyUnlocked == false)
            {
                Debug.Log("Unlock");
                AchievScript.UnlockAchievement(2);
                AlreadyUnlocked = true;
            }
        }
    }
}