using UnityEngine;

public class ObjectBase : MonoBehaviour
{
    [SerializeField]
    //this specific objects score
    protected int objScore;

    public void ClickObject()
    {
        ObjectManager.totalScore += objScore;
        Debug.Log(ObjectManager.totalScore);
        ObjectManager.objects.Remove(this.gameObject);
        Destroy(this.gameObject);
    }
}
