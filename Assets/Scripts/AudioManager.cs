using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;

    [Header("Sounds")]
    [SerializeField] private AudioSource seShapeCompletion;
    [SerializeField] private AudioSource seFailedHit;
    [SerializeField] private AudioSource seButtonPress;
    [SerializeField] private AudioSource seHittingShojiScreen;
    [SerializeField] private AudioSource seTargetHit;
    [SerializeField] private AudioSource seMenuOpen;
    [SerializeField] private AudioSource seGameStart;
    [SerializeField] private AudioSource sePause;
    [SerializeField] private AudioSource seCombo;
    [SerializeField] private AudioSource seTimeUp;

    [Header("BGM")]
    [SerializeField] private AudioSource bgmTitle;
    [SerializeField] private AudioSource bgmMainGame;
    [SerializeField] private AudioSource bgmResults;

    //Getters/Setters
    public AudioSource SeHittingShojiScreen { get { return seHittingShojiScreen; } }
    public AudioSource SeGameStart { get { return seGameStart; } }

    public AudioSource SeShapeCompletion { get { return seShapeCompletion; } }

    public AudioSource SeCombo { get { return seCombo; } }

    public AudioSource SePause { get { return sePause; } }
    public AudioSource SeTimeUp { get { return seTimeUp; } }
    public AudioSource BgmMainGame { get { return bgmMainGame; } }

    private void Awake()
    {
        // Singleton pattern � ensures only one AudioManager exists
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    // Start is called before the first frame update
    void Start()
    {
        //bgmTitle.Play();
        RegisterAllButtons();
    }

    // Update is called once per frame
    void Update()
    {

    }

  private void OnEnable()
  {
        UnityEngine.SceneManagement.SceneManager.sceneLoaded += OnSceneLoaded;
  }

  private void OnDisable()
  {
        UnityEngine.SceneManagement.SceneManager.sceneLoaded -= OnSceneLoaded;
  }

    private void RegisterAllButtons()
    {
        // TODO: Fix this deprecated code warning by using new option
        Button[] buttons = FindObjectsOfType<Button>(true);

        foreach (Button button in buttons)
        {
            // Add click sound
            if (!button.CompareTag("GameStart"))
            {
                button.onClick.AddListener(() => PlayButtonClick());
            }
            else
            {
                button.onClick.AddListener(() => PlayGameStart());
            }
        }
    }

    public void PlayButtonClick()
    {
        if (seButtonPress != null)
            seButtonPress.Play();
    }
    public void PlayGameStart()
    {
        if (seGameStart != null)
            seGameStart.Play();
    }
    public void PlayTimeUp()
    {
        if (seTimeUp != null)
            seTimeUp.PlayOneShot(seTimeUp.clip);
    }

    public void PlayTargetHit()
    {
        seTargetHit.PlayOneShot(seTargetHit.clip);
    }
    public void PlayFailedHit()
    {
        seFailedHit.PlayOneShot(seFailedHit.clip);
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
       // Stop atmosphere audio if we're not in the Game scene
       if (scene.name == "MainScene") 
       {
            bgmMainGame.Play();
       }
       else if (scene.name == "TitleScene")
       {
            bgmTitle.Play();
       }
        else if (scene.name == "ResultsScene")
        {
            bgmResults.Play();
        }

        // re-register UI buttons in the new scene
        RegisterAllButtons();
    }

}
