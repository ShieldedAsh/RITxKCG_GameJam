using UnityEngine;
using UnityEngine.InputSystem;

/// <summary>
/// Instead of a mouse cursor
/// </summary>
public class PunchCursor : MonoBehaviour
{
    [SerializeField, Range(0, 1)]
    private float sensitivity = 1f;

    Vector3 bottomLeft;
    Vector3 topRight;

    /// <summary>
    /// èâä˙âª
    /// </summary>
    public void Initialize()
    {
        //Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;

        //Get the world coordinates of the bottom-left and top-right corners of the screen
        bottomLeft = Camera.main.ScreenToWorldPoint(new Vector3(0, 0, 0));
        topRight = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, 0));
    }

    /// <summary>
    /// çXêVèàóù
    /// </summary>
    public void SelfUpdate()
    {
        Vector3 mouseMoveVec = Mouse.current.delta.ReadValue();

        transform.position = ClampToScreen(transform.position + sensitivity * 0.01f * mouseMoveVec);
    }

    /// <summary>
    /// Fit within the screen
    /// </summary>
    private Vector3 ClampToScreen(Vector3 mousePos)
    {
        mousePos.x = Mathf.Clamp(mousePos.x, bottomLeft.x, topRight.x);
        mousePos.y = Mathf.Clamp(mousePos.y, bottomLeft.y, topRight.y);
        return mousePos;
    }

}
