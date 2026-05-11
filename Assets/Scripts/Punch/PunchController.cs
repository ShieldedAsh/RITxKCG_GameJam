using UnityEngine;

public class PunchController : MonoBehaviour
{
    [SerializeField]
    private GameState gameState;
    [SerializeField]
    private PunchCursor punchCursor;
    [SerializeField]
    private PunchAction punchAction;

    void Start()
    {
        punchCursor.Initialize(gameState);
        punchAction.Initialize(gameState);
    }

    // Update is called once per frame
    void Update()
    {
        punchCursor.SelfUpdate();
        punchAction.SelfUpdate();
    }
}
