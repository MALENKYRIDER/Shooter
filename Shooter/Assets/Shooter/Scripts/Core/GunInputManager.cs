using UnityEngine;

public class ShootInputManager : MonoBehaviour
{
    void Update()
    {
        if (Input.GetKey(KeyCode.Mouse0))
            Debug.Log("Shoot");
        
        if (Input.GetKeyDown(KeyCode.R))
            Debug.Log("Reload");
    }
}