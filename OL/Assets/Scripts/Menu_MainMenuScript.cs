using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class Menu_MainMenuScript : MonoBehaviour
{
    public GameObject MainMenu;
    public GameObject Settings;
    public GameObject Fader;
    private bool Fade;
    private float FP;
    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.None;
        MainMenu.SetActive(true);
        Settings.SetActive(false);
        Fade = false;
        Fader.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Fade) {
            if (FP < 1f) {
                FP = FP + 0.5f * Time.deltaTime;
                Color col = Fader.GetComponent<Image>().color;
                col.a = FP;
                Fader.GetComponent<Image>().color = col;
            }
            else { 
                SceneManager.LoadScene(1);
            }
        }
    
}
    public void StartGame()
    {
        Fade = true;
        MainMenu.SetActive(false);
        Fader.SetActive(true);
        FP = 0f;
        //SceneManager.LoadScene(0);
    }
    public void QuitGame()
    {
        Application.Quit();
    }

    public void SettingsGame()
    {
        MainMenu.SetActive(false);
        Settings.SetActive(true);
    }

    public void BackToMainMenu()
    {
        MainMenu.SetActive(true);
        Settings.SetActive(false);
    }
}
