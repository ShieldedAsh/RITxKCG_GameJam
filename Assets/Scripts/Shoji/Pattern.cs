using System.Collections.Generic;
using UnityEngine;

public class Pattern : MonoBehaviour
{
    // パターン
    public List<bool[,]> pattern { get; private set; } = new List<bool[,]>();

    private void Start()
    {
        InitializePatterns();
    }

    /// <summary>
    /// パターンの初期化
    /// </summary>
    private void InitializePatterns()
    {
        // 四角
        pattern.Add(new bool[,]{
            { true, true },
            { true, true }
        });

        // 横一列
        pattern.Add(new bool[,]{
            { true, true, true }
        });

        // 縦一列
        pattern.Add(new bool[,]{
            { true },
            { true },
            { true }
        });
    }
}
