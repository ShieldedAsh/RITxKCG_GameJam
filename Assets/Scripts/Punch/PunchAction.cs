using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PunchAction : MonoBehaviour
{
    [SerializeField]
    private CircleCollider2D punchCollider;

    [SerializeField]
    private ComboCounter _comboCounter;

    public void Initialize()
    {

    }

    public void SelfUpdate()
    {
        if (Mouse.current.leftButton.wasPressedThisFrame)
        {
            Collider2D[] results = Physics2D.OverlapPointAll(punchCollider.bounds.center);

            //背景のオブジェクトがヒットしているかどうかを判定するためのフラグ
            bool isBackObjectHit = false;
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
                    if((int)obj.Kind < badObjectcount)
                    {
                        _comboCounter.ResetCombo();
                    }
                    else
                    {
                        _comboCounter.AddCombo();
                    }

                    Debug.Log("点数オブジェクトをヒット");

                }

                shojiTear.SetBreakLevelTrueBreak();
            }
            else
            {
                shojiTear.SetBreakLevelBreak();
            }
        }
    }
}
