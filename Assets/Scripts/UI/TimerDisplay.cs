using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using System;

public class TimerDisplay : MonoBehaviour
{
    [SerializeField]
    private TMP_Text timerText;

    public static float timer = 0f;

    // Update is called once per frame
    void Update()
    {
        if (timer >= 1f)
        {
            SceneManager.LoadScene("ResultsScene");
            timer = 0f;
        }
        
        timer += Time.deltaTime;
        timerText.text = FormatTime(timer);
    }

    string FormatTime(float time)
    {
        TimeSpan ts = TimeSpan.FromSeconds(time);
        return string.Format("{0:00}:{1:00}", (int)ts.TotalSeconds, ts.Milliseconds / 10);
    }
}
