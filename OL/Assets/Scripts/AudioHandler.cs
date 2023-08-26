using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class AudioHandler : MonoBehaviour
{
    // Start is called before the first frame update
    [Header("Setup")]
    public bool PlayBackGroundSound = true;
    public GameObject OrienteeringCamera;
    public GameObject PostCamera;
    [Header("Sources")]
    public AudioSource BackGroundSound;
    public AudioSource FootstepSound;
    private int Mode;
    void Start()
    {
        if (PlayBackGroundSound)
        {
            float StartBackGround = Random.Range(1f, 140f);
            BackGroundSound.time = StartBackGround;
            BackGroundSound.Play();
        }
        if (PlayerPrefs.GetInt("UseCode_Setting") == 1)
        {
            Mode = PlayerPrefs.GetInt("ModePart_Code");
        }
        else
        {
            Mode = PlayerPrefs.GetInt("ModeDropdown_Setting");
        }

    }

    void Update()
    {
        if (Mode == 0)
        {
            transform.position = PostCamera.transform.position;
        } else
        {
            transform.position = OrienteeringCamera.transform.position;
        }
    }

    public void PlaySound(string Name)
    {
        if (Name== "Footstep")
        {
            FootstepSound.pitch = Random.Range(0.8f, 1.2f);
            FootstepSound.volume = Random.Range(0.5f, 1f);
            FootstepSound.Play();
        }
    }

    
}
