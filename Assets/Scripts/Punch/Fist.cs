using UnityEngine;

public class Fist : MonoBehaviour
{
    [Header("パンチの速度")]
    [SerializeField]
    private float punchTime = 0.2f;

    [Header("パンチの威力")]
    [SerializeField]
    private float smallRasio = 0.99f;

    private float timer;

    public void Initialize()
    {
        timer = punchTime;
    }

    private void Update()
    {
        timer -= Time.deltaTime;

        transform.localScale *= smallRasio;

        if (timer <= 0)
        {
            Destroy(gameObject);
        }
    }
}
