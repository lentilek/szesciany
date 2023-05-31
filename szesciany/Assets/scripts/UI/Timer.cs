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

    void Start()
    {
        StartCoroutine(Timing());
    }

    IEnumerator Timing()
    {
        do
        {
            //timerTxt.text = time.ToString();
            Display();
            yield return new WaitForSeconds(1f);
            time--;
        } while (time >= 0);
        SceneManager.LoadScene(toLoad);
    }
    private void Display()
    {
        float minutes = Mathf.FloorToInt(time/ 60);
        float seconds = Mathf.FloorToInt(time% 60);
        timerTxt.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }
}
