using UnityEngine;

public class Benchmarker : MonoBehaviour
{
    private int score;

    [SerializeField]
    private GameObject sGrade;
    [SerializeField]
    private GameObject aGrade;
    [SerializeField]
    private GameObject bGrade;
    [SerializeField]
    private GameObject cGrade;
    [SerializeField]
    private GameObject dGrade;

    [SerializeField]
    private Animator shojiGirl;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        score = ObjectManager.totalScore;
        Debug.Log("Total score:" + score);
        Debug.Log("ObjectManager score:" + ObjectManager.totalScore);

        if (score >= 9999)
        {
            Debug.Log("S grade");
            sGrade.SetActive(true);
            PlayAnim("Surprised");
        }
        else if (score >= 7999)
        {
            aGrade.SetActive(true);
            PlayAnim("Laughing");
        }
        else if (score >= 5999)
        {
            bGrade.SetActive(true);
            PlayAnim("Wink");
        }
        else if (score >= 3999)
        {
            cGrade.SetActive(true);
            PlayAnim("Think");
        }
        else
        {
            dGrade.SetActive(true);
            PlayAnim("Angry");
        }
    }

    void PlayAnim(string anim)
    {
        shojiGirl.CrossFade(anim, 0.2f);
    }

}
