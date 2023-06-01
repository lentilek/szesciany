using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TriggerControlDeath : MonoBehaviour
{
    public ParticleSystem death;
    public float howLong = 3;
    private Skale scale;

    [SerializeField] GameObject player;
    [SerializeField] Transform spawnPoint;
    private void Start()
    {
        scale = player.GetComponent<Skale>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            player.SetActive(false);
 
            death.Play();
            StartCoroutine(IsDead());
            SoundManagerScript.PlaySound("deathsound");
        }
    }

    void RespawnPoint()
    {
        player.transform.position = spawnPoint.transform.position;
        player.transform.localScale = new Vector3(1, 1, 1);
        scale.canBeSmall= true;
        player.SetActive(true);
    }

    IEnumerator IsDead()
    {
        yield return new WaitForSeconds(howLong);
        RespawnPoint();
        
    }
}