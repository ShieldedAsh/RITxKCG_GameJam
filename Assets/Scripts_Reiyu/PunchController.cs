using UnityEngine;

public class PunchController : MonoBehaviour
{
    [SerializeField]
    private PunchCursor punchCursor;
    [SerializeField]
    private PunchAction punchAction;

    void Start()
    {
        punchCursor.Initialize();
        punchAction.Initialize();
    }

    // Update is called once per frame
    void Update()
    {
        punchCursor.SelfUpdate();
        punchAction.SelfUpdate();
    }
}
