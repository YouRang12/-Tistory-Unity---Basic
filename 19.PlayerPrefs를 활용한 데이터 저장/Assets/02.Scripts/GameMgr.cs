using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameMgr : MonoBehaviour {
    public InputField inputName;
    public InputField inputAge;
    public InputField inputHeight;

    public void Save()
    {
        PlayerPrefs.SetString("Name", inputName.text);
        PlayerPrefs.SetInt("Age", int.Parse(inputAge.text));
        PlayerPrefs.SetFloat("height", float.Parse(inputHeight.text));
    }

    public void Load()
    {
        if(PlayerPrefs.HasKey("Name"))
        {
            inputName.text = PlayerPrefs.GetString("Name");
            inputAge.text = PlayerPrefs.GetInt("Age").ToString();
            inputHeight.text = PlayerPrefs.GetFloat("height").ToString();
        }
    }
}


