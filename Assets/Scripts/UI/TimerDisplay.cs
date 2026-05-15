using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using TMPro;
using System;

public class TimerDisplay : MonoBehaviour
{
    public static TimerDisplay Instance;

    [SerializeField]
    private GameState gameState;

    [SerializeField]
    private GameData gameData;

    [SerializeField]
    private TMP_Text timerText;

    [SerializeField]
    private GameObject siren;

    public static float timer;

    public float Timer { get { return timer; } set { timer = value; } }

    private void Awake()
    {
        Instance = this;
        timer = gameData.GameTime;
    }

    // Update is called once per frame
    void Update()
    {
        if (gameState.IsOutPlay()) return;

        if (timer <= 0.0f)
        {
            timer = 0f;
            StartCoroutine(PlaySoundAndWait(AudioManager.Instance.SeTimeUp));
        }
        else if(timer <= gameData.WarningLampTime)
        {
             siren.SetActive(true);
        }

            timer -= Time.deltaTime;
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
