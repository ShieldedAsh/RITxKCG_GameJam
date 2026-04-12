using UnityEngine;

public class LocalizationManager : MonoBehaviour
{
    [SerializeField]
    private GameObject jpUIs;

    [SerializeField]
    private GameObject enUIs;

    /// <summary>
    /// Keep current language
    /// </summary>
    private Language currentLanguage;

    public void Initialize()
    {
        currentLanguage = SettingsManager.Instance.CurrentLanguage;
        SwitchUI(currentLanguage);
    }

    // Update is called once per frame
    public void SelfUpdate()
    {
        //When the language changes
        if (currentLanguage != SettingsManager.Instance.CurrentLanguage)
        {
            currentLanguage = SettingsManager.Instance.CurrentLanguage;
            SwitchUI(currentLanguage);
        }
    }

    /// <summary>
    /// Switch the UI based on the language
    /// </summary>
    private void SwitchUI(Language language)
    {
        jpUIs.SetActive(language == Language.Japanese);
        enUIs.SetActive(language == Language.English);
    }
}
