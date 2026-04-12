using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CloseOptionButton : MonoBehaviour
{
    [SerializeField]
    private List<GameObject> options;

    void Start()
    {
        Button button = GetComponent<Button>();
        button.onClick.AddListener(() =>
        {
            foreach (GameObject option in options)
            {
                option.SetActive(false);
            }
        });
    }
}
