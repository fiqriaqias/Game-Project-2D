using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuScript : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public void MulaiGame()
    {
        SceneManager.LoadScene("SampleScene");
    }

    // Update is called once per frame
    public void ExitGame()
    {
        Application.Quit();
    }
}
