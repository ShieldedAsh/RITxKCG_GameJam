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
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if (ObjectManager.totalScore >= 99999)
        {
            sGrade.SetActive(true);
        }
        else if (ObjectManager.totalScore >= 79999)
        {
            aGrade.SetActive(true);
        }
        else if (ObjectManager.totalScore >= 59999)
        {
            bGrade.SetActive(true);
        }
        else if (ObjectManager.totalScore >= 39999)
        {
            cGrade.SetActive(true);
        }
        else if (ObjectManager.totalScore <= 20000)
        {
            dGrade.SetActive(true);
        }
    }
}
