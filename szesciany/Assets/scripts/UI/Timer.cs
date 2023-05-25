using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Timer : MonoBehaviour
{
    public float time = 180f;
    public TextMeshProUGUI timerTxt;
    public string toLoad;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Timing());
    }

    IEnumerator Timing()
    {
        do
        {
            timerTxt.text = time.ToString();
            yield return new WaitForSeconds(1f);
            time--;
        } while (time >= 0);
        SceneManager.LoadScene(toLoad);
    }
}
