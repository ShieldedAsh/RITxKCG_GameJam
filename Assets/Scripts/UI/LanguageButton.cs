using UnityEngine;
using UnityEngine.UI;

public class LanguageButton : MonoBehaviour
{
    [SerializeField]
    private Language language;

    void Start()
    {
        Button button = GetComponent<Button>();
        button.onClick.AddListener(()=>
        {
            SettingsManager.Instance.CurrentLanguage = language;
        });
    }
}
