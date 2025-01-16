using UnityEngine;

public class RotateCamera : MonoBehaviour
{   
    void Update()
    {        
       transform.Rotate(Vector3.up * Input.GetAxis("Mouse X"));        
    }
}
