using UnityEngine;

public class GameState : MonoBehaviour
{
    private bool isExplanation = true;
    public bool IsExplanation { get => isExplanation; set => isExplanation = value; }

    private bool isStarted = false;
    public bool IsStarted { get => isStarted; set => isStarted = value; }

    private bool isFinished = false;
    public bool IsFinished { get => isFinished; set => isFinished = value; }

    private bool isPaused = false;
    public bool IsPaused { get => isPaused; set => isPaused = value; }

    void Start()
    {
        isExplanation = true;

        isStarted = false;

        isFinished = false;

        isPaused = false;
    }

    public bool IsInPlay()
    {
        return !isExplanation && isStarted && !isFinished && !isPaused;
    }

    public bool IsOutPlay()
    {
        return isExplanation || !isStarted || isFinished || isPaused;
    }
}
