using UnityEngine;

public class TitleManager : MonoBehaviour
{
    [SerializeField]
    private LocalizationManager localizationManager;

    void Start()
    {
        //localizationManager.Initialize();
    }

    void Update()
    {
        localizationManager.SelfUpdate();
    }
}
