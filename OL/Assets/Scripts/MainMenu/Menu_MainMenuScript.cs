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
    public GameObject PlayMenu;
    public GameObject ChooseMenu;
    private bool Fade;
    private float FP = 0f;
    public int MapSettings = 0;
    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.None;
        MainMenu.SetActive(true);
        Settings.SetActive(false);
        Fade = false;
        Fader.SetActive(false);
        PlayMenu.SetActive(false);
        ChooseMenu.SetActive(false);
        GetMapSettings();
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
                GetMapSettings();
                if (MapSettings == 0)
                {
                    SceneManager.LoadScene(1); //Forest 1
                } else
                {
                    SceneManager.LoadScene(2); //Forest 2
                }
            }
        }
    
}
    public void StartGame()
    {

        Fade = true;
        MainMenu.SetActive(false);
        Fader.SetActive(true);
        PlayMenu.SetActive(false);
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
        PlayMenu.SetActive(false);
    }
    public void ChangeToPlayMenu()
    {
        PlayMenu.SetActive(true);
        MainMenu.SetActive(false);
    }

    public void ChangeToChooseMenu()
    {
        ChooseMenu.SetActive(true);
        MainMenu.SetActive(false);
        Settings.SetActive(false);
    }

    public void BackToSettings()
    {
        ChooseMenu.SetActive(false);
        Settings.SetActive(true);
        MainMenu.SetActive(false);
        PlayMenu.SetActive(false);
    }

    public void GetMapSettings()
    {
        MapSettings = PlayerPrefs.GetInt("MapDropdown_Setting");
    }
}
