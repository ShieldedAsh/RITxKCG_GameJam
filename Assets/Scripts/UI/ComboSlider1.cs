using UnityEngine;

public class ComboSlider1 : MonoBehaviour
{
    // 手前のスプライトの座標
    [SerializeField] private Transform fill;
    // 億のスプライトの座標
    [SerializeField] private Transform back;

    // スライダーの最大値
    [SerializeField] private float max;
    // スライダーの最小値
    [SerializeField] private float min;
    // スライダーの値
    [SerializeField] private float value;
    // スライダーの横幅
    [SerializeField] private float width;

    /// <summary>
    /// 初期化
    /// </summary>
    public void Initialize()
    {
        width = back.localScale.x;
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
            fill.localScale = new Vector3(0f, fill.localScale.y, fill.localScale.z);
            return;
        }

        float t = (value - min) / (max - min);

        // Clamp
        if (t < 0f) t = 0f;
        if (t > 1f) t = 1f;

        fill.localScale = new Vector3(width * t, fill.localScale.y, fill.localScale.z);
    }

    /// <summary>
    /// セッター:value
    /// </summary>
    /// <param name="value"></param>
    public void SetValue(float value)
    {
        this.value = Mathf.Clamp(value, min, max);
    }

    /// <summary>
    /// セッター:max
    /// </summary>
    /// <param name="max"></param>
    public void SetMax(float max)
    {
        this.max = max;
    }
}
