using UnityEngine;
using UnityEngine.InputSystem;

public class GoodObject : ObjectBase
{
    public override void ClickObject()
    {
        AudioManager.Instance.PlayTargetHit();
        base.ClickObject();
    }
}
