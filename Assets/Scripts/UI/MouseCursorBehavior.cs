using UnityEngine;

public class MouseCursorBehavior : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // Make the cursor visible
        Cursor.visible = true;

        // Unlock the cursor so it can move freely
        Cursor.lockState = CursorLockMode.None;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
