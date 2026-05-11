using UnityEngine;

public class CountDownCanvas : MonoBehaviour
{
    [SerializeField]
    private GameState gameState;

    [SerializeField]
    private GameObject CountReady;

    [SerializeField]
    private GameObject CountPanch;

    private float timer;

    public void Initialize()
    {
        timer = 1f;
    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;

        if (timer <= 0f)
        {
            CountReady.SetActive(false);
            CountPanch.SetActive(true);
            if (timer <= -1f)
            {
                gameState.IsStarted = true;
                this.gameObject.SetActive(false);
            }
        }
        else if (timer <= 1f)
        {
            CountReady.SetActive(true);
        }
    }
}
