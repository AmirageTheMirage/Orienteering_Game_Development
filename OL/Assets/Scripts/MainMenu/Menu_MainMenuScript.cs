using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;
using UnityEngine.Audio;


public class Menu_MainMenuScript : MonoBehaviour //MainMenuScript is the Script that has the "Random Stuff" of MainMenu
{
    public GameObject MainMenu;
    public GameObject Settings;
    public GameObject Fader;
    public GameObject PlayMenu;
    public GameObject ChooseMenu;
    public GameObject Achievements;
    public GameObject Statistics;
    public GameObject IngameSettings;
    public TMP_Dropdown QualitySettingsDropDown;
    public TMP_Dropdown ShadowSettingDropDown;
    private bool Fade;
    private float FP = 0f;
    public int MapSettings = 0;
    public int QualitySetting = 3; //0=V.Low, 1 = Low, 2 = Medium, 3 = High, so we'll start with High obv
    public float AudioVolumeSetting = 1f;
    public AudioMixer MainAudioMixer;
    public Slider AudioSlider;
    public TextMeshProUGUI AudioSliderText;
    public GameObject RealShadowDropDown;
    public GameObject FakeShadowDropDown;
    public int ShadowsSetting = 1;
    public GameObject OverrideObject;
    public GameCode_PlayUsingCode CodeScript;
    public GameObject VersionChangeObject;
    private int UsingCode = 0;
    public float Speed = 2f;
    private AudioHandler AudioScript;
    private float StartCooldown = 0.4f;






    // private int PreAudioVolumeSetting;

    // Start is called before the first frame update
    void Awake()
    {
        AudioScript = GameObject.Find("FullAudioHandler").GetComponent<AudioHandler>();
        //AudioListener.volume = 0.5f;
        if (PlayerPrefs.GetInt("TutorialAbsolved") != 1)
        {
            SceneManager.LoadScene("TutorialScene");
        } else
        {
            OverrideObject.SetActive(false);
        }
        Cursor.lockState = CursorLockMode.None;
        MainMenu.SetActive(true);
        Settings.SetActive(false);
        Fade = false;
        Fader.SetActive(false);
        PlayMenu.SetActive(false);
        ChooseMenu.SetActive(false);
        Achievements.SetActive(false);
        Statistics.SetActive(false);
        IngameSettings.SetActive(false);

        AssignAudioVolume();
        AssignShadowsOnOff();//IMPORTANT: Needs to be BEFORE AssignQualityDropDown
        AssignQualityDropDown();
        GetMapSettings();
    }

    // Update is called once per frame
    void Update()
    {
        if (StartCooldown > 0f)
        {
            StartCooldown = StartCooldown - 1f * Time.deltaTime;
        }
        if (Fade) { //FADER stuff
            if (FP < 1f) {
                FP = FP + 0.5f * Speed * Time.deltaTime;
                Color col = Fader.GetComponent<Image>().color;
                col.a = FP;
                Fader.GetComponent<Image>().color = col;
            }
            else {
                UsingCode = PlayerPrefs.GetInt("UseCode_Setting");
                if (UsingCode == 1)
                {
                    
                    SceneManager.LoadScene(CodeScript.MapPart); //If using Code, open the Scene the Code wants to

                }
                else
                {
                    GetMapSettings();
                    if (MapSettings == 0)
                    {
                        SceneManager.LoadScene(1); //Forest 1
                    }
                    else if (MapSettings == 1)
                    {
                        SceneManager.LoadScene(2); //Forest 2
                    }
                    else if (MapSettings == 2)
                    {
                        SceneManager.LoadScene(3); //Maze 1
                    } else
                    {
                        SceneManager.LoadScene(5); // (5 bc 4 is Tutorial)
                    }
                }
            }
        }
    
}

    public void ReDoTutorial() //ButtonFunction
    {
        AudioScript.PlaySound("Select1");
        SceneManager.LoadScene("TutorialScene");
    }
    public void StartGame()
    {
        
        Fade = true;
        MainMenu.SetActive(false);
        Fader.SetActive(true);
        PlayMenu.SetActive(false);
        Achievements.SetActive(false);
        Statistics.SetActive(false);
        FP = 0f;
        AudioScript.PlaySound("Select2");
        //SceneManager.LoadScene(0);
    }


    public void AssignShadowsOnOff()
    {

        if (PlayerPrefs.HasKey("Shadows_Setting"))
        {
            ShadowsSetting = PlayerPrefs.GetInt("Shadows_Setting");
            PlayerPrefs.Save();


        }
        else
        {
            PlayerPrefs.SetInt("Shadows_Setting", ShadowsSetting);
            PlayerPrefs.Save();



        }
        UpdateShadows(ShadowsSetting); //Do visual & PlayerPrefUpdate
       // Debug.Log(ShadowsSetting);
        
    }
    public void AssignAudioVolume()
    {
        if (PlayerPrefs.HasKey("SoundVolume_Setting"))
        {
            AudioVolumeSetting = PlayerPrefs.GetFloat("SoundVolume_Setting");
            PlayerPrefs.Save();


        }
        else
        {
            PlayerPrefs.SetFloat("SoundVolume_Setting", AudioVolumeSetting);
            PlayerPrefs.Save();



        }
        AudioSlider.value = AudioVolumeSetting;
        AudioListener.volume = AudioVolumeSetting;
        AudioSliderText.text = Mathf.Round((AudioVolumeSetting * 100f)).ToString();
        //AudioSliderText.text = AudioVolumeSetting.ToString();
    }
    public void AssignQualityDropDown()
    {
        
        if (PlayerPrefs.HasKey("QualitySetting_Setting"))
        {
            QualitySetting = PlayerPrefs.GetInt("QualitySetting_Setting");
            PlayerPrefs.Save();
                       

        }
        else
        {
            PlayerPrefs.SetInt("QualitySetting_Setting", QualitySetting);
            PlayerPrefs.Save();
                       


        }
        QualitySettingsDropDown.value = QualitySetting; //Under 1
        
        SetGameQuality(QualitySetting);
    }

    //Following ones are ButtonFunctions
    public void QuitGame()
    {
        Application.Quit();
    }

    public void SettingsGame()
    {
        
        MainMenu.SetActive(false);
        Achievements.SetActive(false);
        Settings.SetActive(true);
        AudioScript.PlaySound("Select1");
    }

    public void BackToMainMenu()
    {
        
        MainMenu.SetActive(true);
        Settings.SetActive(false);
        PlayMenu.SetActive(false);
        Achievements.SetActive(false);
        AudioScript.PlaySound("Select1");
    }
    public void ChangeToPlayMenu()
    {
        
        PlayMenu.SetActive(true);
        MainMenu.SetActive(false);
        AudioScript.PlaySound("Select1");
    }

    public void ChangeToChooseMenu()
    {
        ChooseMenu.SetActive(true);
        MainMenu.SetActive(false);
        Settings.SetActive(false);
        AudioScript.PlaySound("Select1");
    }

    public void BackToSettings()
    {
        ChooseMenu.SetActive(false);
        Achievements.SetActive(false);
        Settings.SetActive(true);
        MainMenu.SetActive(false);
        PlayMenu.SetActive(false);
        Statistics.SetActive(false);
        IngameSettings.SetActive(false);
        AudioScript.PlaySound("Select1");
    }

    public void ChangeToStatisticsMenu()

    {
        Settings.SetActive(false);
        Statistics.SetActive(true);
    }

    public void GetMapSettings()
    {
        MapSettings = PlayerPrefs.GetInt("MapDropdown_Setting");
    }

    public void ChangeToAchievements()
    {
        MainMenu.SetActive(false);
        Achievements.SetActive(true);
        Settings.SetActive(false);
        AudioScript.PlaySound("Select1");
    }

    public void DeleteAllPlayerPrefs()
    {
        Achievements.SetActive(true);
        Settings.SetActive(false);
        AudioScript.PlaySound("Select1");
    }

    public void SetGameQuality(int SetToIndex)
    {
        QualitySettings.SetQualityLevel(SetToIndex); //that was easy
        QualitySetting = SetToIndex;
        PlayerPrefs.SetInt("QualitySetting_Setting", QualitySetting);
        PlayerPrefs.Save();
        if (QualitySetting <= 1)
        {
            RealShadowDropDown.SetActive(false);
            FakeShadowDropDown.SetActive(true);
        }
        else
        {
            RealShadowDropDown.SetActive(true);
            FakeShadowDropDown.SetActive(false); //So from now on you can change shadows again
            //if (ShadowsSetting == 0)
            //{
            //    QualitySettings.shadows = ShadowQuality.Disable;
            //}
            //else
            //{
            //    QualitySettings.shadows = ShadowQuality.All;
            //}
            //ShadowSettingDropDown.value = ShadowsSetting; //So this part here resets the Shadows. so if you go over Low Res and have shadows turned off, this actualizes that.
        }

        UpdateShadows(ShadowsSetting); //Update the PlayerPrefShadow Manager
        
    }

    public void SetVolumeOfGame(float SetVolume)
    {

       // Debug.Log(SetVolume);
        AudioVolumeSetting = SetVolume;
        AudioListener.volume = AudioVolumeSetting;
        PlayerPrefs.SetFloat("SoundVolume_Setting", AudioVolumeSetting);
        PlayerPrefs.Save();

        //Debug.Log(SetVolume);
        AudioSliderText.text = Mathf.Round((AudioVolumeSetting * 100f)).ToString();
    }

    


    public void UpdateShadows(int ShadowNewSetting) //PlayerPref Shadow Handler
    {
        ShadowsSetting = ShadowNewSetting;
        PlayerPrefs.SetInt("Shadows_Setting", ShadowsSetting);
        PlayerPrefs.Save();
        if (ShadowsSetting == 1 && !(QualitySetting <= 1))
        {
            QualitySettings.shadows = ShadowQuality.All;
           
        } else
        {
            QualitySettings.shadows = ShadowQuality.Disable;
        }
        ShadowSettingDropDown.value = ShadowsSetting;
        //Debug.Log(ShadowsSetting);
    }
    public void ExtraSound() 
    {
        if (StartCooldown < 0f)
        {
            Debug.Log("ExtraSound got called!");
            AudioScript.PlaySound("Tick2");
        }
    }

    public void ChangeToIngameSettings()
    {
        Settings.SetActive(false);
        IngameSettings.SetActive(true);
        AudioScript.PlaySound("Select1");
    }


}
