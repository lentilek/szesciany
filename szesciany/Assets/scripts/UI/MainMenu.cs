using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public GameObject controlsScreen;
    //load scene
    public void Play()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    //quit the game
    public void Quit()
    {
        Application.Quit();
        //Debug.Log("Quit");
    }

    public void Controls()
    {
        controlsScreen.SetActive(true);
    }

    public void BackToMM()
    {
        controlsScreen.SetActive(false);
    }
}
