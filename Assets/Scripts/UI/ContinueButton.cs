using UnityEngine;
using UnityEngine.UI;

public class ContinueButton : MonoBehaviour
{
    [SerializeField] private Button button;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        button = GetComponent<Button>();
        // Add a listener to the button's onClick event to load the specified scene
        button.onClick.AddListener(() => PauseMenu.Instance.Resume());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
