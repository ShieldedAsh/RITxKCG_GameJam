using System.Collections.Generic;
using UnityEngine;

public class LightManager : MonoBehaviour
{
    [Header("Light Prefab")]
    // 光のプレファブ
    [SerializeField] private GameObject _lightPrefab;

    [Header("Light Radius")]
    // 光生成の中心からの距離
    [SerializeField] private float _createLengh;

    // 障子のデータ
    private ShojiTear[,] _shojis;

    // 光生成用方向配列
    private Vector2[] LightCreateDirections = new Vector2[]
    {
        new Vector2(-1,  1),
        new Vector2( 0,  1),
        new Vector2( 1,  1),
        new Vector2(-1,  0),
        new Vector2( 1,  0),
        new Vector2(-1, -1),
        new Vector2( 0, -1),
        new Vector2( 1, -1),
    };

    // 障子の状態検知の為に使用する方向配列
    private Vector2[] CheckDirections = new Vector2[]
    {
        new Vector2( 0,  1),
        new Vector2(-1,  0),
        new Vector2( 1,  0),
        new Vector2( 0, -1),
    };

    // Shojiにつける光のmap
    private Dictionary<ShojiTear, List<GameObject>> _spawnedLights
        = new Dictionary<ShojiTear, List<GameObject>>();

    /// <summary>
    /// 初期化
    /// </summary>
    /// <param name="shojis">全ての障子データ</param>
    public void Initialize(ShojiTear[,] shojis)
    {
        _shojis = shojis;
    }


    private void Update()
    {
        UpdateLight();
    }

    /// <summary>
    /// ライトの更新処理
    /// </summary>
    private void UpdateLight()
    {
        if (_shojis == null) return;

        int height = _shojis.GetLength(0);
        int width = _shojis.GetLength(1);

        for (int y = 0; y < height; y++)
        {
            for (int x = 0; x < width; x++)
            {
                ShojiTear shoji = _shojis[y, x];

                if (shoji.breakLevel == BreakLevel.TrueBreak)
                {
                    if (!_spawnedLights.ContainsKey(shoji))
                    {
                        CreateLight(shoji, x, y);
                    }
                    else
                    {
                        UpdateLightVisible(shoji, x, y);
                    }
                }
                else
                {
                    RemoveLight(shoji);
                }
            }
        }
    }


    /// <summary>
    /// 8方向に光を生成
    /// </summary>
    /// <param name="shoji">障子</param>
    /// <param name="shojiX">障子のX座標</param>
    /// <param name="shojiY">障子のY座標</param>
    private void CreateLight(ShojiTear shoji, int shojiX, int shojiY)
    {
        List<GameObject> lights = new List<GameObject>();

        for (int i = 0; i < 8; i++)
        {
            Vector2 dir = LightCreateDirections[i];

            GameObject lightObj = Instantiate(
                _lightPrefab,
                shoji.transform.position + new Vector3(dir.x * _createLengh, dir.y * _createLengh, 0f),
                Quaternion.identity
            );

            lights.Add(lightObj);
        }

        _spawnedLights.Add(shoji, lights);

        UpdateLightVisible(shoji, shojiX, shojiY);
    }


    /// <summary>
    /// ライトの表示を更新
    /// </summary>
    /// <param name="shoji">障子</param>
    /// <param name="shojiX">障子のX座標</param>
    /// <param name="shojiY">障子のY座標</param>
    private void UpdateLightVisible(ShojiTear shoji, int shojiX, int shojiY)
    {
        var lights = _spawnedLights[shoji];

        int height = _shojis.GetLength(0);
        int width = _shojis.GetLength(1);

        for (int i = 0; i < 8; i++)
            lights[i].SetActive(true);

        // 隣り合っていると消す
        for (int i = 0; i < 4; i++)
        {
            Vector2 dir = CheckDirections[i];
            int nierX = shojiX + (int)dir.x;
            int nierY = shojiY + (int)dir.y;

            // 隣が TrueBreak かどうか
            bool isNierBreak = false;
            if (nierX >= 0 && nierX < width && nierY >= 0 && nierY < height && _shojis[nierY, nierX].breakLevel == BreakLevel.TrueBreak)
            {
                isNierBreak = true;
            }

            // 隣が壊れている所の空くディブを消す
            if (isNierBreak)
            {
                for (int j = 0; j < 8; j++)
                {
                    if (LightCreateDirections[j] == dir)
                    {
                        lights[j].SetActive(false);
                        break;
                    }
                }
            }
        }
    }

    /// <summary>
    /// ライトの削除
    /// </summary>
    /// <param name="shoji">障子</param>
    private void RemoveLight(ShojiTear shoji)
    {
        if (!_spawnedLights.ContainsKey(shoji)) return;

        foreach (var light in _spawnedLights[shoji])
            Destroy(light);

        _spawnedLights.Remove(shoji);
    }
}
