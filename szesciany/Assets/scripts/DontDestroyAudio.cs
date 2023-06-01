using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DontDestroyAudio : MonoBehaviour
{

    //Singleton 
    public static DontDestroyAudio instance;

    private void Awake()
    {
        if(instance == null)
        {
            DontDestroyOnLoad(transform.gameObject);
            instance = this;
            return;
        }

        Destroy(gameObject);
    }
}
