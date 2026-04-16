using UnityEngine;

public class ComboSlider1 : MonoBehaviour
{
    // スライダーの手前
    [SerializeField] private RectTransform fill;
    // スライダーの億
    [SerializeField] private RectTransform back;

    // 最大値
    [SerializeField] private float max;
    // 最小値
    [SerializeField] private float min;
    // 値
    [SerializeField] private float value;

    // バックの横幅
    private float width;

    /// <summary>
    /// 初期化
    /// </summary>
    public void Initialize()
    {
        width = back.sizeDelta.x;
        max = 0;
        UpdateFill();
    }

    /// <summary>
    /// 更新処理
    /// </summary>
    public void UpdateFill()
    {
        if (max == min)
        {
            fill.sizeDelta = new Vector2(0f, fill.sizeDelta.y);
            return;
        }

        float t = (value - min) / (max - min);
        t = Mathf.Clamp01(t);

        fill.sizeDelta = new Vector2(width * t, fill.sizeDelta.y);
    }

    /// <summary>
    /// セッター:value
    /// </summary>
    public void SetValue(float value)
    {
        this.value = Mathf.Clamp(value, min, max);
    }

    /// <summary>
    /// セッター:max
    /// </summary>
    public void SetMax(float max)
    {
        this.max = max;
    }
}
