using UnityEngine;
using UnityEngine.UI;

public class SceneTransitionButton : MonoBehaviour
{
    [SerializeField]
    private string sceneName;

    private void Start()
    {
        Button button = GetComponent<Button>();
        // Add a listener to the button's onClick event to load the specified scene
        button.onClick.AddListener(() => SceneManager.LoadScene(sceneName));
    }

}
