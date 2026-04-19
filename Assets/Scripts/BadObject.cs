using UnityEngine;
using UnityEngine.InputSystem;

public class BadObject : ObjectBase
{
    public override void ClickObject()
    {
        AudioManager.Instance.PlayFailedHit();
        base.ClickObject();
    }
}
