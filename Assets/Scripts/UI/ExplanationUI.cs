using UnityEngine;
using UnityEngine.InputSystem;

public class ExplanationUI : MonoBehaviour
{
    [SerializeField]
    private GameState gameState;

    [SerializeField]
    private CountDownCanvas countDownCanvas;

    [SerializeField]
    private GameObject explanationUI_JP;

    [SerializeField]
    private GameObject explanationUI_EN;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if (SettingsManager.Instance.CurrentLanguage == Language.Japanese)
        {
            explanationUI_JP.SetActive(true);
            explanationUI_EN.SetActive(false);
        }
        else
        {
            explanationUI_JP.SetActive(false);
            explanationUI_EN.SetActive(true);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Mouse.current.leftButton.wasPressedThisFrame)
        {
            gameState.IsExplanation = false;
            countDownCanvas.gameObject.SetActive(true);
            countDownCanvas.Initialize();

            //Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;

            this.gameObject.SetActive(false);
        }
    }
}
