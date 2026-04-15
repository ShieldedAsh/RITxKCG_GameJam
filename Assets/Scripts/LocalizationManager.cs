using UnityEngine;
using UnityEngine.SceneManagement;

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

    private static LocalizationManager Instance;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    private void Start()
    {
        if (jpUIs == null)
        {
            jpUIs = GameObject.FindWithTag("jpUI");
        }
        if (enUIs == null)
        {
            enUIs = GameObject.FindWithTag("enUI");
        }

        currentLanguage = SettingsManager.Instance.CurrentLanguage;

        Initialize();
    }

    private void Update()
    {
        SelfUpdate();
    }
    void OnEnable()
    {
        UnityEngine.SceneManagement.SceneManager.sceneLoaded += OnSceneLoaded;
    }

    void OnDisable()
    {
        UnityEngine.SceneManagement.SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if (jpUIs == null || enUIs == null)
        {
            Debug.LogWarning("Localization UI objects not found in scene: " + scene.name);
            return;
        }

        SwitchUI(currentLanguage);
    }

    public void Initialize()
    {
        if (jpUIs != null && enUIs != null)
        {
            SwitchUI(currentLanguage);
        }

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
        if (jpUIs == null || enUIs == null)
        {
            Debug.LogWarning("SwitchUI called but UI references are null!");
            return;
        }

        jpUIs.SetActive(language == Language.Japanese);
        enUIs.SetActive(language == Language.English);
    }
}