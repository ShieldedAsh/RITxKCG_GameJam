using UnityEngine;

public class SettingsManager : MonoBehaviour
{
    public static SettingsManager Instance;

    public Language CurrentLanguage { get; set; }

    public float MouseSensitivity { get; private set; } = 1.0f;

    void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);

        LoadSettings();
    }

    public void SetLanguage(Language language)
    {
        CurrentLanguage = language;
        PlayerPrefs.SetInt("Language", (int)language);
        PlayerPrefs.Save();
    }

    private void LoadSettings()
    {
        if (PlayerPrefs.HasKey("Language"))
        {
            CurrentLanguage = (Language)PlayerPrefs.GetInt("Language");
        }
        else
        {
            CurrentLanguage = Language.English;
        }
    }
}
