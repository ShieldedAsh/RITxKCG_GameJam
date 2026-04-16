using UnityEngine;
using UnityEngine.InputSystem;

public class BadObject : ObjectBase
{
    private void OnMouseOver()
    {
        if (Mouse.current.leftButton.isPressed)
        {
            AudioManager.Instance.PlayFailedHit();
            ObjectManager.totalScore += objScore;
            Debug.Log(ObjectManager.totalScore);
            ObjectManager.objects.Remove(this.gameObject);
            Destroy(this.gameObject);
        }
    }
}
