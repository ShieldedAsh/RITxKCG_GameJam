using UnityEngine;

public class Benchmarker : MonoBehaviour
{
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
        if (ObjectManager.totalScore >= 99999)
        {
            sGrade.SetActive(true);
            PlayAnim("Surprised");
        }
        else if (ObjectManager.totalScore >= 79999)
        {
            aGrade.SetActive(true);
            PlayAnim("Laughing");
        }
        else if (ObjectManager.totalScore >= 59999)
        {
            bGrade.SetActive(true);
            PlayAnim("Wink");
        }
        else if (ObjectManager.totalScore >= 39999)
        {
            cGrade.SetActive(true);
            PlayAnim("Think");
        }
        else if (ObjectManager.totalScore <= 20000)
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
