using UnityEngine;

public class TitleManager : MonoBehaviour
{
    [SerializeField]
    private LocalizationManager localizationManager;

    void Awake()
    {
        Time.timeScale = 1f;
        PauseMenu.GameIsPaused = false;
    }

    void Start()
    {
        //localizationManager.Initialize();
    }

    void Update()
    {
        //localizationManager.SelfUpdate();
    }
}
