using UnityEngine;

public class Cursor_start : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    
    void Start()
    {   
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        
    }
}
