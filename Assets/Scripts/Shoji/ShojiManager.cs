// 破壊レベル
using UnityEngine;

public enum BreakLevel
{
    NotBreak,
    Break,
    TrueBreak
}

public class ShojiManager : MonoBehaviour
{
    // 障子
    public ShojiTear[,] _shojis { get; private set; }

    [Header("CreateCounts")]
    // 生成する横幅
    [SerializeField] private int _createWidth;

    // 生成する立幅
    [SerializeField] private int _createHeight;

    [Header("CreateSpacing")]
    // X座標の生成間隔
    [SerializeField] private float _xSpacing;

    // Y座標の生成間隔
    [SerializeField] private float _ySpacing;

    [Header("CreatePosition")]
    // 最初の生成座標
    [SerializeField] private Vector3 _startPosition = Vector3.zero;

    [Header("Prefabs")]

    //障子のプレファブ
    [SerializeField] private ShojiTear _shojiPrefab;

    [Header("Light")]
    // 光管理クラス
    [SerializeField] private LightManager _lightManager;

    // パターンの
    private ShojiPattern _pattern;

    // スプライト配列
    public Sprite[] _sprites;

    // 破壊スプライト配列
    private Sprite[] _breakSprites;

    public void Start()
    {
        _sprites = Resources.LoadAll<Sprite>("Shoji");
        _breakSprites = Resources.LoadAll<Sprite>("BreakShoji");

        InitializeShojis();
        _pattern = new ShojiPattern();
        _pattern.InitializePatterns();
        _lightManager.Initialize(_shojis);
    }



    private void Update()
    {
        Check();
    }

    /// <summary>
    /// パターンのチェック
    /// </summary>
    public void Check()
    {
        // 全てのパターンをチェック
        foreach (var it in _pattern.pattern)
        {
            if (CheckPattern(it))
            {
                Debug.Log("パターン成立");
            }
        }
    }

    /// <summary>
    /// 障子のしょきか　
    /// </summary>
    private void InitializeShojis()
    {
        _shojis = new ShojiTear[_createHeight, _createWidth];

        Vector3 _offsetPos = new Vector3(-_createWidth * 0.5f + 0.5f, -_createHeight * 0.5f + 0.5f, 0);

        for (int y = 0; y < _createHeight; y++)
        {
            for (int x = 0; x < _createWidth; x++)
            {
                Vector3 pos = _offsetPos + _startPosition + new Vector3(
                    x * _xSpacing,
                    y * _ySpacing,
                    0f
                );
                int spriteNum = x + (_createHeight - 1 - y) * _createWidth;

                var shoji = CreateShoji(pos, spriteNum);
                _shojis[y, x] = shoji;
            }
        }
    }

    /// <summary>
    /// 障子の生成
    /// </summary>
    /// <param name="createPos">生成座標</param>
    public ShojiTear CreateShoji(Vector3 createPos, int spriteNum)
    {
        var createObj = Instantiate(_shojiPrefab, createPos, Quaternion.identity);

        var shoji = createObj.GetComponent<ShojiTear>();

        // スプライト配列から指定番号のスプライトを設定
        shoji.sprites = new Sprite[2] { _sprites[spriteNum], _breakSprites[spriteNum] };

        return shoji;
    }


    /// <summary>
    /// パターンのチェック
    /// </summary>
    /// <param name="pattern">パターン</param>
    public bool CheckPattern(bool[,] pattern)
    {

        int patternHeight = pattern.GetLength(0);
        int patternWidth = pattern.GetLength(1);

        int shojiHeight = _shojis.GetLength(0);
        int shojiWidth = _shojis.GetLength(1);

        for (int y = 0; y <= shojiHeight - patternHeight; y++)
        {
            for (int x = 0; x <= shojiWidth - patternWidth; x++)
            {
                if (IsMatchAt(x, y, pattern))
                {
                    BreakPattern(x, y, pattern);
                    return true;
                }
            }
        }

        return false;
    }

    /// <summary>
    /// その場所がパターンと一致しているか調べる
    /// </summary>
    /// <param name="startX">開始地点X</param>
    /// <param name="startY">開始地点Y</param>
    /// <param name="pattern">パターン</param>
    /// <returns>探索成功したらtrue</returns>
    private bool IsMatchAt(int startX, int startY, bool[,] pattern)
    {
        int patternHeight = pattern.GetLength(0);
        int patternWidth = pattern.GetLength(1);

        for (int y = 0; y < patternHeight; y++)
        {
            for (int x = 0; x < patternWidth; x++)
            {
                if (pattern[y, x])
                {
                    if (_shojis[startY + y, startX + x].breakLevel != BreakLevel.TrueBreak)
                        return false;
                }
            }
        }
        return true;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="startX">開始地点X</param>
    /// <param name="startY">開始地点Y</param>
    /// <param name="pattern">パターン</param>
    private void BreakPattern(int startX, int startY, bool[,] pattern)
    {
        int patternHeight = pattern.GetLength(0);
        int patternWidth = pattern.GetLength(1);

        for (int y = 0; y < patternHeight; y++)
        {
            for (int x = 0; x < patternWidth; x++)
            {
                if (pattern[y, x])
                {
                    _shojis[startY + y, startX + x].ResetBreak();
                }
            }
        }
    }

    public int GetCreateWidth()
    {
        return _createWidth;
    }

    public int GetCreateHeight()
    {
        return _createHeight;
    }
};
