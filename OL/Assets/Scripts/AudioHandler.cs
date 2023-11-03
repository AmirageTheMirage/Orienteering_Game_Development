using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class AudioHandler : MonoBehaviour
{
    // Start is called before the first frame update
    [Header("Setup")]
    public bool PlayBackGroundSound = true;
    public bool IsMainMenu = false;
    public bool FollowPostCam = false;
    public GameObject OrienteeringCamera;
    public GameObject PostCamera;
    [Header("Sources")]
    public AudioSource BackGroundSoundDay;
    public AudioSource FootstepSound;
    public AudioSource SelectSound;
    public AudioSource TickSound1;
    public AudioSource TickSound2;
    public AudioSource SelectSoundUp;
    public AudioSource SelectSoundDown;
    public AudioSource OpenMap;
    public AudioSource CloseMap;
    public AudioSource BackGroundSoundNight;
    private int Mode;
    private float StartCooldown = 0.5f;
    private int TimeOfDay;
    void Start()
    {
        if (PlayerPrefs.GetInt("UseCode_Setting") == 1) //Override with GameCode Input, Get TimeOfDay
        {
            TimeOfDay = PlayerPrefs.GetInt("TimePart_Code");
        }
        else
        {
            TimeOfDay = PlayerPrefs.GetInt("Time_Setting");
        }
        if (IsMainMenu)
        {
            float StartBackGround = Random.Range(1f, 140f);
            BackGroundSoundDay.time = StartBackGround;
            BackGroundSoundDay.Play();
        }
        else
        {
            if (PlayBackGroundSound)
            {

                if (TimeOfDay >= 6 && TimeOfDay <= 18) //If Day
                {

                    float StartBackGround = Random.Range(1f, 140f);
                    BackGroundSoundDay.time = StartBackGround;
                    BackGroundSoundDay.Play();

                }
                else //If Night
                {
                    float StartBackGround = Random.Range(1f, 140f);
                    BackGroundSoundNight.time = StartBackGround;
                    BackGroundSoundNight.Play();
                }
            }
        }
    
        
        
        if (FollowPostCam)
        {
            Mode = 0;
        } else
        {
            if (PlayerPrefs.GetInt("UseCode_Setting") == 1)
            {
                Mode = PlayerPrefs.GetInt("ModePart_Code");
            }
            else
            {
                Mode = PlayerPrefs.GetInt("ModeDropdown_Setting");
            }
        }

    }

    void Update()
    {
        if (StartCooldown > 0f)
        {
            StartCooldown = StartCooldown - 1f * Time.deltaTime;
        }
        if (Mode == 0)
        {
            transform.position = PostCamera.transform.position;
        } else
        {
            transform.position = OrienteeringCamera.transform.position;
        }
    }

    public void PlaySound(string Name) //Can be accessed by other scrupts using "public" function property
    {
        if (Name == "Footstep")
        {
            FootstepSound.pitch = Random.Range(0.8f, 1.2f);
            FootstepSound.volume = Random.Range(0.2f, 0.5f);
            FootstepSound.Play();
        }
        if (Name == "Select1")
        {
            SelectSound.pitch = Random.Range(0.8f, 1.2f);
            SelectSound.volume = Random.Range(0.5f, 1f);
            SelectSound.Play();
        }
        if (Name == "Select2")
        {
            SelectSoundUp.pitch = Random.Range(0.8f, 1.2f);
            SelectSoundUp.volume = Random.Range(0.5f, 1f);
            SelectSoundUp.Play();
        }
        if (Name == "Select3")
        {
            SelectSoundDown.pitch = Random.Range(0.8f, 1.2f);
            SelectSoundDown.volume = Random.Range(0.5f, 1f);
            SelectSoundDown.Play();
        }
        if (Name == "Tick1")
        {
            TickSound1.pitch = Random.Range(0.8f, 1.2f);
            TickSound1.volume = Random.Range(0.5f, 1f);
            TickSound1.Play();
        }
        if (Name == "Tick2")
        {
            TickSound2.pitch = Random.Range(0.8f, 1.2f);
            TickSound2.volume = Random.Range(0.5f, 1f);
            TickSound2.Play();
        }
        if (Name == "OpenMap")
        {
            OpenMap.pitch = Random.Range(0.8f, 1.2f);
            OpenMap.volume = Random.Range(0.5f, 1f);
            OpenMap.Play();
        }
        if (Name == "CloseMap")
        {
            CloseMap.pitch = Random.Range(0.8f, 1.2f);
            CloseMap.volume = Random.Range(0.5f, 1f);
            CloseMap.Play();
        }
    }

    public void ExtraSound()
    {
        if (StartCooldown < 0f)
        {

            PlaySound("Tick2");
        }
    }
}
