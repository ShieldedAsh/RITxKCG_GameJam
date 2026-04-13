using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public static PauseMenu Instance;

    public static bool GameIsPaused = false;
    public GameObject pauseMenuUI;
    public GameObject shojiWallFrame;

    private void Awake()
    {
        Instance = this;
    }

    void Update()
    {
        // Check for pause input (Escape key)
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            if (GameIsPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }

    public void Resume()
    {
        // Make the cursor invisible
        Cursor.visible = false;

        shojiWallFrame.SetActive(true);
        pauseMenuUI.SetActive(false); // Hide pause menu
        Time.timeScale = 1f; // Resume game time
        GameIsPaused = false;
    }

    void Pause()
    {
        AudioManager.Instance.SePause.Play();

        // Make the cursor visible
        Cursor.visible = true;

        // Unlock the cursor so it can move freely
        Cursor.lockState = CursorLockMode.None;

        shojiWallFrame.SetActive(false);
        pauseMenuUI.SetActive(true); // Show pause menu
        Time.timeScale = 0f; // Freeze game time
        GameIsPaused = true;
    }
}