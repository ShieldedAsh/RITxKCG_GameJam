using System;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "GameData", menuName = "Scriptable Objects/GameData")]
public class GameData : ScriptableObject
{
    [Header("ゲーム時間")]
    [SerializeField]
    private float gameTime;
    public float GameTime { get => gameTime; }

    [Header("ゲーム開始時の的出現数")]
    [SerializeField]
    private int startTargetNum;
    public int StartTargetNum { get => startTargetNum; }

    [Header("的の数が増える間隔")]
    [SerializeField]
    private float targetNumIncreaseInterval;
    public float TargetNumIncreaseInterval { get => targetNumIncreaseInterval; }

    [Header("増える的の数")]
    [SerializeField]
    private int targetNumIncreaseAmount;
    public int TargetNumIncreaseAmount { get => targetNumIncreaseAmount; }

    [Header("的の最高速度")]
    [SerializeField]
    private float targetMaxSpeed;
    public float TargetMaxSpeed { get => targetMaxSpeed; }

    [Header("的の最低速度")]
    [SerializeField]
    private float targetMinSpeed;
    public float TargetMinSpeed { get => targetMinSpeed; }

    [Header("的の種類とスコア")]
    [SerializeField]
    private List<TargetScore> targetScores;
    public List<TargetScore> TargetScores { get => targetScores; }
}

[Serializable]
public struct TargetScore
{
    [SerializeField]
    public TargetKind Kind;
    [SerializeField]
    public int Score;
}
