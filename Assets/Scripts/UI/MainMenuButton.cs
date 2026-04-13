using UnityEngine;
using UnityEngine.UI;

public class MainMenuButton : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        PauseMenu.Instance.Resume();
        Button button = GetComponent<Button>();
        // Add a listener to the button's onClick event to load the specified scene and resume game
        button.onClick.AddListener(() =>
        {
            if (PauseMenu.Instance != null)
            {
                PauseMenu.Instance.Resume();
                TimerDisplay.Instance.Timer = 0f;
                Cursor.visible = true;
            }

            SceneManager.LoadScene("TitleScene");
        });
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
