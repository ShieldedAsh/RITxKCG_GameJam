using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PunchAction : MonoBehaviour
{
    [SerializeField]
    private CircleCollider2D punchCollider;

    [SerializeField]
    private ComboCounter _comboCounter;

    [Header("右拳プレハブ")]
    [SerializeField]
    private Fist rightFist;

    [Header("左拳プレハブ")]
    [SerializeField]
    private Fist leftFist;

    GameState gameState;

    public void Initialize(GameState state)
    {
        gameState = state;
    }

    public void SelfUpdate()
    {
        if (gameState.IsOutPlay()) return;

        if (Mouse.current.leftButton.wasPressedThisFrame)
        {
            Collider2D[] results = Physics2D.OverlapPointAll(punchCollider.bounds.center);

            //ヒットした点数オブジェクトのリスト
            List<ObjectBase> objectBases = new();
            //ヒットした障子オブジェクト
            ShojiTear shojiTear = null;

            //ヒットしたオブジェクトの中の障子クラスと点数クラスを取得する
            //Determine whether there is a score object among the hit objects
            foreach (Collider2D collider in results)
            {
                if (collider.gameObject.transform.TryGetComponent(out ObjectBase obj))
                {
                    objectBases.Add(obj);
                }
                else if (collider.gameObject.transform.TryGetComponent(out ShojiTear shoji))
                {
                    shojiTear = shoji;
                }
            }

            if (shojiTear == null) return;

            if (objectBases.Count != 0)
            {
                foreach (ObjectBase obj in objectBases)
                {
                    obj.ClickObject();
                    const int badObjectcount = 3;
                    if ((int)obj.Kind < badObjectcount)
                    {
                        _comboCounter.ResetCombo();
                    }
                    else
                    {
                        _comboCounter.AddCombo();
                    }

                    Debug.Log("点数オブジェクトをヒット");

                }

                CreateFist();
                shojiTear.SetBreakLevelTrueBreak();
            }
            else if (shojiTear.breakLevel == BreakLevel.NotBreak)
            {
                CreateFist();
                shojiTear.SetBreakLevelBreak();
            }
        }
    }

    /// <summary>
    /// 拳の生成
    /// </summary>
    private void CreateFist()
    {
        if (transform.position.x > 0)
        {
            Fist fistR = Instantiate(rightFist, transform.position, Quaternion.identity);
            fistR.Initialize();
        }
        else
        {
            Fist fistL = Instantiate(leftFist, transform.position, Quaternion.identity);
            fistL.Initialize();
        }
    }
}


