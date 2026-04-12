using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;

public class OptionButton : MonoBehaviour
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
                option.SetActive(true);
            }
        });
    }
}
