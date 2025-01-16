using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Evolution : MonoBehaviour
{
    // �������, ������� ����� �������������� � ����������������
    public GameObject egg;
    public GameObject egglet;
    public GameObject shade;
    public GameObject shadow;

    // ������ ������� ������ ��� �������� �����
    public GameObject magicPrefab;

    // �������, ��� ����� ����������� �����
    public Transform summonPosition;

    // ����� ����� �����
    public float duration = 2.0f;

    void Update()
    {
        // ��������� ������� ������ 1, 2, 3 � 4
        if (Input.GetKey(KeyCode.Alpha1))
        {
            // ���������� ������ egg � ������� �����
            SetActiveStates(true, false, false, false);
            CreateMagic();
        }
        else if (Input.GetKey(KeyCode.Alpha2))
        {
            // ���������� ������ egglet � ������� �����
            SetActiveStates(false, true, false, false);
            CreateMagic();
        }
        else if (Input.GetKey(KeyCode.Alpha3))
        {
            // ���������� ������ shade � ������� �����
            SetActiveStates(false, false, true, false);
            CreateMagic();
        }
        else if (Input.GetKey(KeyCode.Alpha4))
        {
            // ���������� ������ shadow � ������� �����
            SetActiveStates(false, false, false, true);
            CreateMagic();
        }
    }

    // ����� ��� �������� �����
    void CreateMagic()
    {
        // ������� ��������� ������� ������
        GameObject magicInstance = Instantiate(magicPrefab, summonPosition.position, Quaternion.identity);

        // ������ ������� ������ �������� �������� ���������
        magicInstance.transform.SetParent(transform);

        // ���������� ��������� ����� �������� �����
        Destroy(magicInstance, duration);
    }

    // ����� ��� ��������� �������� ��������� ��������
    void SetActiveStates(bool eggActive, bool eggletActive, bool shadeActive, bool shadowActive)
    {
        egg.SetActive(eggActive);
        egglet.SetActive(eggletActive);
        shade.SetActive(shadeActive);
        shadow.SetActive(shadowActive);
    }
}
