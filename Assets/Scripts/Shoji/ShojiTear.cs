using UnityEngine;

public class ShojiTear : MonoBehaviour
{
    // 障子の破壊フラグ
    public BreakLevel breakLevel { get; private set; }

    // 障子の永久破壊フラグ
    private bool _isTrueBreak;

    // 破壊されてからのカウント
    private float timeSinceBreak = 0f;

    // 破壊されてからのカウントの最大値
    [SerializeField] private float maxBreakElapsedTime;

    // レンダー
    private Renderer _rend;

    private void Start()
    {
        breakLevel = BreakLevel.NotBreak;
        _rend = GetComponent<Renderer>();
        _rend.enabled = false;
    }

    private void Update()
    {
        _rend.enabled = breakLevel == BreakLevel.NotBreak ? true : false;
        AddSinceBreakCount();
    }

    /// <summary>
    /// クリックされた時に実行
    /// </summary>
    private void OnMouseDown()
    {
        breakLevel = BreakLevel.TrueBreak;
    }

    /// <summary>
    /// 破壊されてからのカウントを進める
    /// </summary>
    private void AddSinceBreakCount()
    {
        if (breakLevel == BreakLevel.NotBreak || breakLevel == BreakLevel.TrueBreak)
            return;

        timeSinceBreak += Time.deltaTime;

        if (timeSinceBreak >= maxBreakElapsedTime)
        {
            ResetBreak();
        }
    }

    /// <summary>
    /// 破壊判定の初期化
    /// </summary>
    public void ResetBreak()
    {
        breakLevel = BreakLevel.NotBreak;
        _isTrueBreak = false;
        timeSinceBreak = 0f;
    }

    /// <summary>
    /// セッタ：破壊レベルをBreakに
    /// </summary>
    public void SetBreakLevelBreak()
    {
        breakLevel = BreakLevel.Break;
    }

    /// <summary>
    /// セッタ：破壊レベルをTrueBreakに
    /// </summary>
    public void SetBreakLevelTrueBreak()
    {
        breakLevel = BreakLevel.TrueBreak;
    }
}
