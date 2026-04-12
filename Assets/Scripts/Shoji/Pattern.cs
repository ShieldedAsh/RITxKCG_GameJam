using System.Collections.Generic;

public class ShojiPattern
{
    // パターン
    public List<bool[,]> pattern { get; private set; } = new List<bool[,]>();

    /// <summary>
    /// パターンの初期化
    /// </summary>
    public void InitializePatterns()
    {
        // 十字
        pattern.Add(new bool[,]
        {
        { false, true,  false },
        { true,  true,  true  },
        { false, true,  false }
        });

        // 一列
        pattern.Add(new bool[,]{
            { true },
            { true },
            { true },
            { true },
            { true }
        });

        pattern.Add(new bool[,]{
            {true,true,true,true,true}
        });

        // L字
        pattern.Add(new bool[,]
        {
        { true,  false, false },
        { true,  false, false },
        { true,  true,  true }
        });


        pattern.Add(new bool[,]{
  　    { true, true, true },
        { true, false, false },
    　  { true, false, false }
        });

        pattern.Add(new bool[,]{
        { true, true, true },
        { false, false, true },
        { false, false, true }
        });

        pattern.Add(new bool[,]{
        { false, false, true },
        { false, false, true },
        { true,  true,  true }
        });

        pattern.Add(new bool[,]
        {
        { true,  false, true  },
        { false, true,  false },
        { true,  false, true  }
        });

        // 5x5中空洞のダイヤ
        pattern.Add(new bool[,]{
        { false, false, true,  false, false },
        { false, true,  false, true,  false },
        { true,  false, false, false, true  },
        { false, true,  false, true,  false },
        { false, false, true,  false, false }
        });

        // 5x5ハート
        pattern.Add(new bool[,]{
        { false, false, true,  false, true,  false, false },
        { false, true,  false, true,  false, true,  false },
        { true,  false, false, false, false, false, true  },
        { false, true,  false, false, false, true,  false },
        { false, false, true,  false, true,  false, false },
        { false, false, false, true,  false, false, false }
        });

        pattern.Add(new bool[,]{
        { false, false, false, false, true,  false, false },
        { false, false, true,  false, false, true,  false },
        { false, true,  false, false, false, false, true  },
        { true,  false, false, false, false, false, false },
        { false, true,  false, true,  false, false, false },
        { false, false, true,  false, true,  false, false },
        { false, false, false, true,  false, false, false }
        });

        pattern.Add(new bool[,]{
        { false, false, false, true,  false, false, false },
        { false, false, true,  false, true,  false, false },
        { false, true,  false, false, false, true,  false },
        { true,  false, false, false, false, false, true  },
        { false, true,  false, true,  false, true,  false },
        { false, false, true,  false, true,  false, false },
        { false, false, false, true,  false, false, false }
        });

        pattern.Add(new bool[,]{
        { false, false, true,  false, false, false, false },
        { false, true,  false, true,  false, false, false },
        { true,  false, false, false, true,  false, false },
        { false, false, false, false, false, false, true  },
        { true,  false, false, false, true,  false, false },
        { false, true,  false, true,  false, false, false },
        { false, false, true,  false, false, false, false }
        });

    }
}
