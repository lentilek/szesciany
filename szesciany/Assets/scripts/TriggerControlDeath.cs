using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TriggerControlDeath : MonoBehaviour
{
    public ParticleSystem death;
    public float timer = 0;
    public float howLong = 3; 
    public bool isDead = false;

    [SerializeField] GameObject player;
    [SerializeField] Transform spawnPoint;
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
                RespawnPoint();
            }
        }
    }

    void RespawnPoint()
    {
        player.transform.position = spawnPoint.transform.position;
        player.SetActive(true);
        isDead= false;
    }
}