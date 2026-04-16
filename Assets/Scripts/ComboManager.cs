using UnityEditor.Build;
using UnityEngine;

public class ComboManager : MonoBehaviour
{
    [SerializeField]ComboCounter comboCounter;

    [SerializeField]ComboSlider1 comboSlider;
    void Start()
    {
        comboCounter.Initialize();
        comboSlider.Initialize();
    }

    void Update()
    {
        comboCounter.MyUpdate();
        comboSlider.SetMax(comboCounter.resetTime);
        comboSlider.SetValue(comboCounter.timer);
        comboSlider.UpdateFill();
    }
}
