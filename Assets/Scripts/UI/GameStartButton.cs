using UnityEngine;
using UnityEngine.UI;

public class GameStartButton : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Button button = GetComponent<Button>();
        button.onClick.AddListener(() => AudioManager.Instance.SeGameStart.Play());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
