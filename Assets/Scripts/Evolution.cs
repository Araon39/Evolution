using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Evolution : MonoBehaviour
{
    // Объекты, которые будут активироваться и деактивироваться
    public GameObject egg;
    public GameObject egglet;
    public GameObject shade;
    public GameObject shadow;

    // Префаб системы частиц для создания магии
    public GameObject magicPrefab;

    // Позиция, где будет создаваться магия
    public Transform summonPosition;

    // Время жизни магии
    public float duration = 2.0f;

    void Update()
    {
        // Проверяем нажатие клавиш 1, 2, 3 и 4
        if (Input.GetKey(KeyCode.Alpha1))
        {
            // Активируем объект egg и создаем магию
            SetActiveStates(true, false, false, false);
            CreateMagic();
        }
        else if (Input.GetKey(KeyCode.Alpha2))
        {
            // Активируем объект egglet и создаем магию
            SetActiveStates(false, true, false, false);
            CreateMagic();
        }
        else if (Input.GetKey(KeyCode.Alpha3))
        {
            // Активируем объект shade и создаем магию
            SetActiveStates(false, false, true, false);
            CreateMagic();
        }
        else if (Input.GetKey(KeyCode.Alpha4))
        {
            // Активируем объект shadow и создаем магию
            SetActiveStates(false, false, false, true);
            CreateMagic();
        }
    }

    // Метод для создания магии
    void CreateMagic()
    {
        // Создаем экземпляр системы частиц
        GameObject magicInstance = Instantiate(magicPrefab, summonPosition.position, Quaternion.identity);

        // Делаем систему частиц дочерним объектом персонажа
        magicInstance.transform.SetParent(transform);

        // Уничтожаем экземпляр через заданное время
        Destroy(magicInstance, duration);
    }

    // Метод для установки активных состояний объектов
    void SetActiveStates(bool eggActive, bool eggletActive, bool shadeActive, bool shadowActive)
    {
        egg.SetActive(eggActive);
        egglet.SetActive(eggletActive);
        shade.SetActive(shadeActive);
        shadow.SetActive(shadowActive);
    }
}
