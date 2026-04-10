using UnityEngine;
using UnityEngine.InputSystem;

public class BadObject : MonoBehaviour
{
    [SerializeField]
    //this specific objects score
    private int objScore;

    private void OnMouseOver()
    {
        if (Mouse.current.leftButton.isPressed)
        {
            ObjectManager.totalScore += objScore;
            Debug.Log(ObjectManager.totalScore);
            Destroy(this.gameObject);
        }
    }
}
