using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using System.Collections;
using Unity.VectorGraphics;

public class GameStartButton : MonoBehaviour
{
    private bool isLoading = false;

    void Start()
    {
        Button button = GetComponent<Button>();
        button.onClick.AddListener(() =>
        {
            if (isLoading) return;
            isLoading = true;

            button.interactable = false;

            Time.timeScale = 1f;
            PauseMenu.GameIsPaused = false;

            TimerDisplay.timer = 0f;
            ObjectManager.totalScore = 0;

            StartCoroutine(PlaySoundAndWait(AudioManager.Instance.SeGameStart));
        });
    }

    IEnumerator PlaySoundAndWait(AudioSource source)
    {
        source.Play();
        yield return new WaitForSecondsRealtime(source.clip.length / 3f);

        SceneManager.LoadScene("MainScene");
    }
}
