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

    // スプライト
    public Sprite[] sprites { get; set; }

    // スプライトレンダー
    private SpriteRenderer _spriteRenderer;



    private void Start()
    {
        breakLevel = BreakLevel.NotBreak;
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        UpdateSprite();
        AddSinceBreakCount();
        
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

    /// <summary>
    /// スプライトのアップデート
    /// </summary>
    private void UpdateSprite()
    {
        switch (breakLevel)
        {
            case BreakLevel.NotBreak:
                AudioManager.Instance.SeHittingShojiScreen.Play();
                _spriteRenderer.sprite = sprites[0];
                break;

            case BreakLevel.Break:
            case BreakLevel.TrueBreak:
                AudioManager.Instance.SeHittingShojiScreen.Play();
                _spriteRenderer.sprite = sprites[1];
                break;

        }
    }

}
