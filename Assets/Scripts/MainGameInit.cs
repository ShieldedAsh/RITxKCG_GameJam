using UnityEngine;
using UnityEngine.InputSystem;

public class MainGameInit : MonoBehaviour
{
    void Awake()
    {
        Time.timeScale = 1f;
        PauseMenu.GameIsPaused = false;

        TimerDisplay.timer = 0f;
        ObjectManager.totalScore = 0;

        Cursor.lockState = CursorLockMode.Locked;
    }
}
