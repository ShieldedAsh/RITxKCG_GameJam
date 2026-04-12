using System.Collections.Generic;
using UnityEngine;

public enum Language
{
    English,
    Japanese,
}

[System.Serializable]
public struct Masage
{
    public int scoreNum;
    public Language language;
    public string masage;
}

public class WomanScoreMessage : MonoBehaviour
{

    // メッセージ格納配列
    private List<string>[,] _messages;

    // スコア判定用配列
    [Header("Score")]
    [SerializeField] private int[] _scoreThresholds;

    [Header("Masage")]
    // キャラクターのメッセージリスト
    [SerializeField] private Masage[] _womanMessages;

    [Header("Langage")]
    // 現在の言語
    [SerializeField] private Language _currentLanguage;
    // 使用する言語の数
    [SerializeField] private int _langageCount;


    private void Start()
    {
        Initialize();
        Debug.Log(Check(188));
        Debug.Log(Check(100));
    }

    /// <summary>
    /// 初期化
    /// </summary>
    private void Initialize()
    {

        _messages = new List<string>[_langageCount, _scoreThresholds.Length];

        for (int langage = 0; langage < _langageCount; langage++)
        {
            for (int i = 0; i < _scoreThresholds.Length; i++)
            {
                _messages[langage, i] = new List<string>();
            }
        }

        InitializeWomanMsg();
    }

    /// <summary>
    /// キャラクターのメッセージを
    /// </summary>
    private void InitializeWomanMsg()
    {
        foreach (var msg in _womanMessages)
        {
            AddMessage(msg.language, msg.scoreNum, msg.masage);
        }
    }

    /// <summary>
    /// チェックして言葉を返す関数
    /// </summary>
    /// <param name="score">スコア</param>
    /// <returns>キャラクターが離す言葉</returns>
    public string Check(int score)
    {
        for (int i = 0; i < _scoreThresholds.Length; i++)
        {
            if (score <= _scoreThresholds[i])
            {
                var list = _messages[(int)_currentLanguage, i];
                return list[Random.Range(0, list.Count)];
            }
        }

        return "エラー";
    }

    /// <summary>
    /// メッセージの追加
    /// </summary>
    /// <param name="language">追加するメッセージの言語</param>
    /// <param name="scoreNum">追加するメッセージの場所（インデックス）</param>
    /// <param name="Message">追加するメッセージ</param>
    public void AddMessage(Language language, int scoreNum, string message)
    {
        _messages[(int)language, scoreNum].Add(message);
    }

}
