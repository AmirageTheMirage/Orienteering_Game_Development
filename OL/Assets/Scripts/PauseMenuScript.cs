using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenuScript : MonoBehaviour
{

    
    public bool EscapeMenu = false;
    public GameObject TheMainMenu;
    public GameObject Map;
    public MapHandler Handler;
    public GameObject Compass;
    public GameObject Fader;
    public Orienteering_MapObjectHandler Orienteering_Handler;
    private AudioHandler AudioScript; //AudioScript.PlaySound("Select3");
    // Start is called before the first frame update
    void Start()
    {
        AudioScript = GameObject.Find("FullAudioHandler").GetComponent<AudioHandler>();
        EscapeMenu = false;
        TheMainMenu.SetActive(false);
        Compass.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && Fader.activeSelf == false)
        {
            
            if (EscapeMenu) //Open or close (toggle)
            {
                AudioScript.PlaySound("Tick1");
                EscapeMenu = false;
                Cursor.lockState = CursorLockMode.Locked;
                TheMainMenu.SetActive(false);
                if (Orienteering_Handler.ended == false)
                {
                    Compass.SetActive(true);
                }
                
            }
            else
            {
                AudioScript.PlaySound("Tick1");
                if (Handler != null)
                {
                    Handler.CloseMap();
                }
                EscapeMenu = true;
                TheMainMenu.SetActive(true);
                Cursor.lockState = CursorLockMode.None;
                Compass.SetActive(false);
                
            }
            
        }
    }


    public void ResumeGame()
    {
        AudioScript.PlaySound("Select1");
        EscapeMenu = false;
        TheMainMenu.SetActive(false);
        Cursor.lockState = CursorLockMode.Locked;
        Map.SetActive(false);
        Compass.SetActive(true);

    }

    public void ExitToMainMenu()
    {
        AudioScript.PlaySound("Select1");
        SceneManager.LoadScene(0);
        
    }
}
