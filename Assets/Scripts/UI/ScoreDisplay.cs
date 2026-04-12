using UnityEngine;
using TMPro;

public class ScoreDisplay : MonoBehaviour
{
    [SerializeField]
    private TMP_Text scoreText;

    // Update is called once per frame
    void Update()
    {
        scoreText.text = ObjectManager.totalScore.ToString();
    }
}
