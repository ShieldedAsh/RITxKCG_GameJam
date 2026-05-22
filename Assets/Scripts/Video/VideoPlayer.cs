using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;

public class VideoPlayerController : MonoBehaviour
{
    // キャンバスグループ
    [SerializeField] private CanvasGroup canvasGroup;
    // フェードされるまでの時間
    [SerializeField] private float idleThreshold = 5f;
    // 消える時間
    [SerializeField] private float fadeDuration = 1.5f;
    // ビデオプレイヤー
    [SerializeField] private VideoPlayer videoPlayer;
    // イメージ
    [SerializeField] private RawImage rawImage;

    // 最終チェックタイム
    private float lastInputTime = 0f;
    // フェードぐあい
    private float fadeT = 0f;
    // 現在フェードされているか
    private bool isFadingIn = false;
    // 現在フェードされているか
    private bool isFadingOut = false;

    private bool isFirst = true;

    private void Start()
    {
        canvasGroup.alpha = 0f;
        fadeT = 0f;
        rawImage.raycastTarget = false;
        lastInputTime = Time.time;
    }

    private void Update()
    {
        CheckInput();
        CheckIdle();
        UpdateFade();
    }

    /// <summary>
    /// 入力チェック
    /// </summary>
    private void CheckInput()
    {
        if (Input.anyKey || Input.GetAxis("Mouse X") != 0 || Input.GetAxis("Mouse Y") != 0)
        {
            lastInputTime = Time.time;

            // 入力があれば即フェードアウト
            isFadingIn = false;
            isFadingOut = true;
        }
    }

    /// <summary>
    /// しばらく何もしていないかのちぇっく
    /// </summary>
    private void CheckIdle()
    {
        if (isFadingIn || isFadingOut) return;

        if (Time.time - lastInputTime > idleThreshold)
        {


            isFadingIn = true;
        }
    }

    /// <summary>
    /// フェードを更新
    /// </summary>
    private void UpdateFade()
    {
        if (isFadingIn)
        {
            fadeT += Time.deltaTime / fadeDuration;
            if (isFirst)
            {
                videoPlayer.time = 0;
                videoPlayer.Play();
                isFirst = false;
            }
            if (fadeT >= 1f)
            {
                fadeT = 1f;
                isFadingIn = false;

                lastInputTime = Time.time;
            }
        }
        else if (isFadingOut)
        {
            fadeT -= Time.deltaTime * 10f / fadeDuration;
            if (fadeT <= 0f)
            {
                fadeT = 0f;
                isFadingOut = false;
                isFirst = true;
                lastInputTime = Time.time;
            }
        }

        canvasGroup.alpha = fadeT;
    }

}
