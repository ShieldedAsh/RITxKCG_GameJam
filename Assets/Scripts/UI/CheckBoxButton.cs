using UnityEngine;
using UnityEngine.UI;

public class CheckBoxButton : MonoBehaviour
{
    [SerializeField]
    private Language language;

    [SerializeField]
    private GameObject myCheckImage;

    [SerializeField]
    private GameObject notMyCheckImage;

    void Start()
    {
        myCheckImage.SetActive(SettingsManager.Instance.CurrentLanguage == language);

        Button button = GetComponent<Button>();
        button.onClick.AddListener(() =>
        {
            myCheckImage.SetActive(true);
            notMyCheckImage.SetActive(false);
            SettingsManager.Instance.SetLanguage(language);
        });
    }
}
