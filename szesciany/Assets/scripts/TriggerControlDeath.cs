using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TriggerControlDeath : MonoBehaviour
{
    public GameObject deathParticle;
    public ParticleSystem death;
    public float timer = 0;
    public float howLong = 3;
    public bool isDead = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isDead = true;
            timer = 0;
            other.gameObject.SetActive(false);
 
            death.Play();
        }

    }
    private void Update()
    {
        if(isDead)
        {
            timer += Time.deltaTime;
            if(timer >= howLong)
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            }
        }
    }
    private void OnTriggerStay(Collider other)
    {

    }

    private void OnTriggerExit(Collider other)
    {
        //SceneManager.LoadScene("SampleScene");
        //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex); //build index in the build settings>>file
    }
}