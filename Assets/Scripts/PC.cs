using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PC : MonoBehaviour
{
    void Update()
    {
        transform.Translate(Vector3.forward * Input.GetAxis("Vertical") * Time.deltaTime * 10);
        transform.Rotate(Vector3.up * Input.GetAxis("Horizontal") * Time.deltaTime * 300);
    }
}
