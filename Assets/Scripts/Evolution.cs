using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Evolution : MonoBehaviour
{
    public GameObject egg;
    public GameObject egglet;
    public GameObject shade;
    public GameObject shadow;

    void Update()
    {
        if (Input.GetKey(KeyCode.Alpha1))
        {
            SetActiveStates(true, false, false, false);
        }
        else if (Input.GetKey(KeyCode.Alpha2))
        {
            SetActiveStates(false, true, false, false);
        }
        else if (Input.GetKey(KeyCode.Alpha3))
        {
            SetActiveStates(false, false, true, false);
        }
        else if (Input.GetKey(KeyCode.Alpha4))
        {
            SetActiveStates(false, false, false, true);
        }
    }

    void SetActiveStates(bool eggActive, bool eggletActive, bool shadeActive, bool shadowActive)
    {
        egg.SetActive(eggActive);
        egglet.SetActive(eggletActive);
        shade.SetActive(shadeActive);
        shadow.SetActive(shadowActive);
    }
}