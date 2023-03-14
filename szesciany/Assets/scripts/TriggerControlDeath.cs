using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TriggerControlDeath : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {

    }

    private void OnTriggerStay(Collider other)
    {

    }

    private void OnTriggerExit(Collider other)
    {
        SceneManager.LoadScene("SampleScene");
        //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex); build index in the build settings>>file
    }
}