using System;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.W))
            Debug.Log("Move Forward");
        
        if (Input.GetKeyDown(KeyCode.A))
            Debug.Log("Move Left");
        
        if (Input.GetKeyDown(KeyCode.S))
            Debug.Log("Move Backward");
        
        if (Input.GetKeyDown(KeyCode.D))
            Debug.Log("Move Right");
    }
}
