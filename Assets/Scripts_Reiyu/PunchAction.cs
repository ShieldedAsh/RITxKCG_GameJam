using UnityEngine;
using UnityEngine.InputSystem;

public class PunchAction : MonoBehaviour
{
    [SerializeField]
    private CircleCollider2D punchCollider;

    public void Initialize()
    {

    }

    public void SelfUpdate()
    {
        if (Mouse.current.leftButton.wasPressedThisFrame)
        {
            Collider2D[] results = Physics2D.OverlapCircleAll(punchCollider.bounds.center, punchCollider.radius);

            foreach (Collider2D collider in results)
            {
                if (collider == punchCollider) continue;

                Debug.Log("Hit: " + collider.name, this);
                var renderer = GetComponent<SpriteRenderer>();
                renderer.color = renderer.color == Color.white ? Color.red : Color.white;
            }
        }
    }
}
