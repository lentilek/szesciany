using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManagerScript : MonoBehaviour
{
    public static AudioClip collectsound, deathsound, jumpsound, finishsound;
    static AudioSource audioSrc;
    // Start is called before the first frame update
    void Start()
    {
        collectsound = Resources.Load<AudioClip>("collectsound");
        deathsound = Resources.Load<AudioClip>("deathsound");
        jumpsound = Resources.Load<AudioClip>("jumpsound");
        finishsound = Resources.Load<AudioClip>("finishsound");

        audioSrc = GetComponent<AudioSource>();

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public static void PlaySound (string clip)
    {
        switch (clip)
        {
            case "collectsound":
                audioSrc.PlayOneShot(collectsound);
                break;
            case "deathsound":
                audioSrc.PlayOneShot(deathsound);
                break;
            case "jumpsound":
                audioSrc.PlayOneShot(jumpsound);
                break;
            case "finishsound":
                audioSrc.PlayOneShot(finishsound);
                break;
        }
    }
}
