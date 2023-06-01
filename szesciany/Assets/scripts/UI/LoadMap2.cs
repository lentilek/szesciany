using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadMap2 : MonoBehaviour
{
    public PickableTypes meta;
    public GameObject nextLvlUI;
    public Timer time;
    public PlayerInventory pi;
    public TextMeshProUGUI points;
    public TextMeshProUGUI timer;
    public bool UI = false;

    private void OnTriggerEnter(Collider other)
    {
        PlayerInventory playerInventory = other.GetComponent<PlayerInventory>();

        
        if (playerInventory.numberOfPickupsMeta >= meta.toCollect)
        {
            nextLvlUI.SetActive(true);
            Time.timeScale = 0f;
            UI = true;
            timer.text = "Time Left: " + time.time.ToString();
            points.text = "Points: " + pi.numberOfPickupsGold.ToString();
        }
    }

    public void GoToMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void NextLevel()
    {
        if (SceneManager.GetActiveScene().buildIndex == 6) 
        { 
            SceneManager.LoadScene("MainMenu"); 
        }
        else
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }
}
