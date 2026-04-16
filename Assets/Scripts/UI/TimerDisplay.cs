using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using TMPro;
using System;

public class TimerDisplay : MonoBehaviour
{
    public static TimerDisplay Instance;

    [SerializeField]
    private TMP_Text timerText;

    public static float timer = 0f;

    public float Timer { get { return timer; } set { timer = value; } }

    private void Awake()
    {
        Instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        if (timer >= 90f)
        {
            timer = 0f;
            StartCoroutine(PlaySoundAndWait(AudioManager.Instance.SeTimeUp));
        }
        
        timer += Time.deltaTime;
        timerText.text = FormatTime(timer);
    }

    string FormatTime(float time)
    {
        TimeSpan ts = TimeSpan.FromSeconds(time);
        return string.Format("{0:00}:{1:00}", (int)ts.TotalSeconds, ts.Milliseconds / 10);
    }

    IEnumerator PlaySoundAndWait(AudioSource source)
    {
        source.Play();
        yield return new WaitForSecondsRealtime(source.clip.length / 3f);

        SceneManager.LoadScene("ResultsScene");
    }
}
