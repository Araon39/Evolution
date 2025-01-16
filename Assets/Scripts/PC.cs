using UnityEngine;

public class PС : MonoBehaviour
{
    // Скорость движения персонажа
    public float speed = 5.0f;

    // Чувствительность мыши для управления камерой
    public float mouseSensitivity = 2.0f;

    // Гравитация, применяемая к персонажу
    public float gravity = -9.8f;

    // Высота прыжка персонажа
    public float jumpHeight = 2.0f;

    // Трансформ камеры игрока
    public Transform playerCamera;

    // Расстояние от персонажа до камеры
    public float cameraDistance = 5.0f;

    // Высота камеры относительно персонажа
    public float cameraHeight = 2.0f;

    // Компонент CharacterController для управления физикой персонажа
    private CharacterController characterController;

    // Скорость персонажа
    private Vector3 velocity;

    // Флаг, указывающий, находится ли персонаж на земле
    private bool isGrounded;

    // Углы наклона камеры по вертикали и горизонтали
    private float cameraVerticalAngle;
    private float cameraHorizontalAngle;

    void Start()
    {
        // Получаем компонент CharacterController
        characterController = GetComponent<CharacterController>();

        // Блокируем курсор в центре экрана
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        // Обрабатываем движение персонажа
        HandleMovement();

        // Обрабатываем управление камерой мышью
        HandleMouseLook();

        // Обновляем позицию камеры
        UpdateCameraPosition();
    }

    void HandleMovement()
    {
        // Проверяем, находится ли персонаж на земле
        isGrounded = characterController.isGrounded;

        // Если персонаж на земле и падает, сбрасываем вертикальную скорость
        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        // Получаем ввод с клавиатуры для движения вперед/назад и влево/вправо
        float moveForwardBack = Input.GetAxis("Vertical") * speed;
        float moveLeftRight = Input.GetAxis("Horizontal") * speed;

        // Вычисляем вектор движения на основе направления камеры
        Vector3 move = playerCamera.forward * moveForwardBack + playerCamera.right * moveLeftRight;
        move.y = 0; // Убедитесь, что движение только по горизонтали

        // Если персонаж движется, обновляем его направление
        if (move != Vector3.zero)
        {
            transform.forward = move;
        }

        // Перемещаем персонажа
        characterController.Move(move * Time.deltaTime);

        // Обрабатываем прыжок
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }

        // Применяем гравитацию
        velocity.y += gravity * Time.deltaTime;
        characterController.Move(velocity * Time.deltaTime);
    }

    void HandleMouseLook()
    {
        // Получаем ввод с мыши для управления камерой
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity;

        // Обновляем углы наклона камеры
        cameraHorizontalAngle += mouseX;
        cameraVerticalAngle -= mouseY;

        // Ограничиваем вертикальный угол наклона камеры
        cameraVerticalAngle = Mathf.Clamp(cameraVerticalAngle, -90f, 90f);

        // Обновляем углы поворота камеры
        playerCamera.localEulerAngles = new Vector3(cameraVerticalAngle, cameraHorizontalAngle, 0);
    }

    void UpdateCameraPosition()
    {
        // Вычисляем желаемую позицию камеры
        Vector3 desiredPosition = transform.position - playerCamera.forward * cameraDistance + Vector3.up * cameraHeight;

        // Плавно перемещаем камеру к желаемой позиции
        playerCamera.position = Vector3.Lerp(playerCamera.position, desiredPosition, Time.deltaTime * 5.0f);

        // Камера смотрит на персонажа
        playerCamera.LookAt(transform.position + Vector3.up * cameraHeight);
    }
}
