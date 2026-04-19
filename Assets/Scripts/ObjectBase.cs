using UnityEngine;

[System.Serializable]
public enum TargetKind
{
    /// <summary>
    /// 栗
    /// </summary>
    CHESTNUT,
    /// <summary>
    /// ハリネズミ
    /// </summary>
    HEDGEHOG,
    /// <summary>
    /// パイナップル
    /// </summary>
    PINEAPPLE,
    /// <summary>
    /// 本
    /// </summary>
    BOOK,
    /// <summary>
    /// 箱
    /// </summary>
    BOX,
    /// <summary>
    /// ネコ
    /// </summary>
    CAT,
    /// <summary>
    /// 犬
    /// </summary>
    DOG,
    /// <summary>
    /// メガネ
    /// </summary>
    GLASSES,
    /// <summary>
    /// ティーカップ
    /// </summary>
    TEACUP,
    /// <summary>
    /// クマのぬいぐるみ
    /// </summary>
    TEDDY,
}

public class ObjectBase : MonoBehaviour
{
    [SerializeField]
    //this specific objects score
    protected int objScore;

    [SerializeField]
    protected TargetKind kind;
    public TargetKind Kind { get => kind; }

    public void Initialize(int score)
    {
        objScore = score;
    }

    public virtual void ClickObject()
    {
        ObjectManager.totalScore += objScore;
        Debug.Log(ObjectManager.totalScore);
        ObjectManager.objects.Remove(this.gameObject);
        Destroy(this.gameObject);
    }
}
