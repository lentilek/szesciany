using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TriggerControlDeath : MonoBehaviour
{
    public ParticleSystem death;
    public float howLong = 3; 

    [SerializeField] GameObject player;
    [SerializeField] Transform spawnPoint;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            other.gameObject.SetActive(false);
 
            death.Play();
            StartCoroutine(IsDead());
        }
    }

    void RespawnPoint()
    {
        player.transform.position = spawnPoint.transform.position;
        player.SetActive(true);
    }

    IEnumerator IsDead()
    {
        yield return new WaitForSeconds(howLong);
        RespawnPoint();
    }
}