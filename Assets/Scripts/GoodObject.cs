using UnityEngine;
using UnityEngine.InputSystem;

public class GoodObject : MonoBehaviour
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
            ObjectManager.objects.Remove(this.gameObject);
            Destroy(this.gameObject);
        }
    }
}
