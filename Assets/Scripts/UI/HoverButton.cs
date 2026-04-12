using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class HoverButton : MonoBehaviour,IPointerEnterHandler, IPointerExitHandler
{
    [SerializeField,Header("Sprite on hover")]
    private Sprite hoverSprite;

    /// <summary>
    /// 初期状態のスプライトを保存するための変数
    /// </summary>
    private Sprite defaultSprite;

    /// <summary>
    /// Imageコンポーネントへの参照を保持するための変数
    /// </summary>
    private Image image;

    private void Start()
    {
        image = GetComponent<Image>();
        defaultSprite = image.sprite;
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        image.sprite = hoverSprite;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        image.sprite = defaultSprite;
    }

}
