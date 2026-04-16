using TMPro;
using UnityEngine;

[System.Serializable]
public struct ComboData
{
    // このコンボ数以上ならこれにする
    public int checkCombo;
    // リセットまでの時間
    public float resetTime;  
}


public class ComboCounter : MonoBehaviour
{
    // カウントUI
    [SerializeField] private TextMeshProUGUI _countUI;

    // コンボリセット設定テーブル
    [SerializeField] private ComboData[] _resetTable;

    // 現在のコンボ
    private int _comboCount;

    // タイマー
    public float timer { get; private set; }

    public float resetTime {  get; private set; }

    /// <summary>
    /// 初期化
    /// </summary>
    public void Initialize()
    {
        _comboCount = 0;
        timer = 0;
        UpdateUI();
    }

    /// <summary>
    /// 更新処理
    /// </summary>
    public void MyUpdate()
    {
        if (Input.GetKeyUp(KeyCode.Space))
        {
            AddCombo();
        }
        if (_comboCount > 0)
        {
            timer -= Time.deltaTime;

            if (timer <= 0)
            {
                ResetCombo();
            }
        }
    }

    /// <summary>
    /// コンボの追加
    /// </summary>
    public void AddCombo()
    {
        _comboCount++;

        timer = GetResetTime();
        resetTime = timer;

        UpdateUI();
    }


    /// <summary>
    /// リセットされるまでの時間を取得
    /// </summary>
    /// <returns>時間</returns>
    private float GetResetTime()
    {
        float time = -1f;

        foreach (var data in _resetTable)
        {
            if (_comboCount >= data.checkCombo)
            {
                time = data.resetTime;
            }
        }

        return time;
    }


    /// <summary>
    /// コンボをリセット
    /// </summary>
    private void ResetCombo()
    {
        _comboCount = 0;
        UpdateUI();
    }

    /// <summary>
    /// UIの更新
    /// </summary>
    private void UpdateUI()
    {
            _countUI.text = _comboCount.ToString();
    }
}