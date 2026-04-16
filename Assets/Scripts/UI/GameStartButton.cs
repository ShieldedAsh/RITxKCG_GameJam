using UnityEngine;
using UnityEngine.UI;

public class GameStartButton : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Button button = GetComponent<Button>();
        button.onClick.AddListener(() =>
        {
            AudioManager.Instance.SeGameStart.Play();

            Time.timeScale = 1f;
            PauseMenu.GameIsPaused = false;

            TimerDisplay.timer = 0f;
            ObjectManager.totalScore = 0;
        });
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
