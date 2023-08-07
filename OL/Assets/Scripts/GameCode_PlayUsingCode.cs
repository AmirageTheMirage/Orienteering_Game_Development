using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameCode_PlayUsingCode : MonoBehaviour
{
    public TMP_InputField CodeInput;
    public int MapPart;
    public int ModePart;
    public int TimePart;
    public int FogPart;
    public int DifficultyPart;
    public int StartPostPart;
    public int EndPostPart;
    public int OrienteeringXPart;
    public int OrienteeringYPart;
    public int OrienteeringZPart;
    public bool ValidInput = false;
    public GameObject ValidCheck;
    public TMP_Text PlayText;
    void Start()
    {
            PlayerPrefs.SetInt("UseCode_Setting", 0);
          //  PlayerPrefs.SetInt("MapPart_Code", 0);
            PlayerPrefs.SetInt("ModePart_Code", 0);
            PlayerPrefs.SetInt("TimePart_Code", 0);
            PlayerPrefs.SetInt("FogPart_Code", 0);
            PlayerPrefs.SetInt("DifficultyPart_Code", 0);
            PlayerPrefs.SetInt("StartPost_Code", 112);
            PlayerPrefs.SetInt("EndPost_Code", 112);
            PlayerPrefs.SetInt("OrienteeringX_Code", 112);
            PlayerPrefs.SetInt("OrienteeringY_Code", 112);
            PlayerPrefs.SetInt("OrienteeringZ_Code", 112);
            PlayerPrefs.Save();
        //  Debug.Log("First Time Playing?");



        CodeInput.onValueChanged.AddListener(InputValueChanged);
        ValidCheck.SetActive(false);
        PlayText.text = "Play";
        PlayText.fontSize = 24;
    }

    public void InputValueChanged(string Code)
    {
        if (Code.Length == 21)
        {
            //Code = MapPart.ToString() + ModePart.ToString() + TimePartString + FogPart.ToString() + DifficultyPart.ToString() + StartPostPart.ToString() + EndPostPart.ToString();
            bool IsMapPartValid = int.TryParse(Code[0].ToString(), out MapPart);
            bool IsModePartValid = int.TryParse(Code[1].ToString(), out ModePart);
            bool IsTimePartValid = int.TryParse(Code.Substring(2, 2), out TimePart);
            bool IsFogPartValid = int.TryParse(Code[4].ToString(), out FogPart);
            bool IsDifficultyPartValid = int.TryParse(Code[5].ToString(), out DifficultyPart);
            bool StartPostPartValid = int.TryParse(Code.Substring(6, 3), out StartPostPart);
            bool EndPostPartValid = int.TryParse(Code.Substring(9, 3), out EndPostPart);
            bool OrienteeringXPartValid = int.TryParse(Code.Substring(12, 3), out OrienteeringXPart);
            bool OrienteeringYPartValid = int.TryParse(Code.Substring(15, 3), out OrienteeringYPart);
            bool OrienteeringZPartValid = int.TryParse(Code.Substring(18, 3), out OrienteeringZPart);

            if (IsMapPartValid && IsModePartValid && IsTimePartValid && IsFogPartValid
                && MapPart >= 1 && MapPart <= 3
                && ModePart >= 0 && ModePart <= 1 // Note: Changed <= 1 to >= 1 since mode can only be 1 or 2 according to the original code.
                && TimePart >= 1 && TimePart <= 24
                && FogPart >= 1 && FogPart <= 5)
            {
                ValidInput = true;
                ValidCheck.SetActive(true);
                PlayText.text = "Play (from code)";
                PlayText.fontSize = 16;
                PlayerPrefs.SetInt("UseCode_Setting", 1);
                PlayerPrefs.SetInt("MapPart_Code", MapPart);
                PlayerPrefs.SetInt("ModePart_Code", ModePart);
                PlayerPrefs.SetInt("TimePart_Code", TimePart);
                PlayerPrefs.SetInt("FogPart_Code", FogPart);
                PlayerPrefs.SetInt("DifficultyPart_Code", DifficultyPart);
                PlayerPrefs.SetInt("StartPost_Code", StartPostPart);
                PlayerPrefs.SetInt("EndPost_Code", EndPostPart);
                PlayerPrefs.SetInt("OrienteeringX_Code", OrienteeringXPart);
                PlayerPrefs.SetInt("OrienteeringY_Code", OrienteeringYPart);
                PlayerPrefs.SetInt("OrienteeringZ_Code", OrienteeringZPart);
                PlayerPrefs.Save();
                Debug.Log("Valid Input");
            }
            else
            {
                ValidInput = false;
                ValidCheck.SetActive(false);
                PlayText.text = "Play";
                PlayText.fontSize = 24;
                PlayerPrefs.SetInt("UseCode_Setting", 0);
                PlayerPrefs.Save();
                Debug.Log("Inalid Input");

            }
        } else
        {
            ValidInput = false;
            ValidCheck.SetActive(false);
            PlayText.text = "Play";
            PlayText.fontSize = 24;
            PlayerPrefs.SetInt("UseCode_Setting", 0);
            PlayerPrefs.Save();
            Debug.Log("Inalid Input by length, length is: " + Code.Length);
        }
    }
    void Update()
    {
        
    }
}
