using UnityEngine;
using UnityEngine.UI;

public class MainMenuButton : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Button button = GetComponent<Button>();
        // Add a listener to the button's onClick event to load the specified scene and resume game
        button.onClick.AddListener(() =>
        {
            Time.timeScale = 1f;
            PauseMenu.GameIsPaused = false;

            ObjectManager.totalScore = 0;

            Cursor.visible = true;

            SceneManager.LoadScene("TitleScene");
        });
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
