using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChange : MonoBehaviour {

	public void ChangeFirstScene()
    {
        SceneManager.LoadScene("01.FirstScene");
    }

    public void ChangeSecondScene()
    {
        SceneManager.LoadScene("02.SecondScene");
    }
}


