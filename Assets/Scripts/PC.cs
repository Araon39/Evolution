using UnityEngine;

public class P� : MonoBehaviour
{
    // �������� �������� ���������
    public float speed = 5.0f;

    // ���������������� ���� ��� ���������� �������
    public float mouseSensitivity = 2.0f;

    // ����������, ����������� � ���������
    public float gravity = -9.8f;

    // ������ ������ ���������
    public float jumpHeight = 2.0f;

    // ��������� ������ ������
    public Transform playerCamera;

    // ���������� �� ��������� �� ������
    public float cameraDistance = 5.0f;

    // ������ ������ ������������ ���������
    public float cameraHeight = 2.0f;

    // ��������� CharacterController ��� ���������� ������� ���������
    private CharacterController characterController;

    // �������� ���������
    private Vector3 velocity;

    // ����, �����������, ��������� �� �������� �� �����
    private bool isGrounded;

    // ���� ������� ������ �� ��������� � �����������
    private float cameraVerticalAngle;
    private float cameraHorizontalAngle;

    void Start()
    {
        // �������� ��������� CharacterController
        characterController = GetComponent<CharacterController>();

        // ��������� ������ � ������ ������
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        // ������������ �������� ���������
        HandleMovement();

        // ������������ ���������� ������� �����
        HandleMouseLook();

        // ��������� ������� ������
        UpdateCameraPosition();
    }

    void HandleMovement()
    {
        // ���������, ��������� �� �������� �� �����
        isGrounded = characterController.isGrounded;

        // ���� �������� �� ����� � ������, ���������� ������������ ��������
        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        // �������� ���� � ���������� ��� �������� ������/����� � �����/������
        float moveForwardBack = Input.GetAxis("Vertical") * speed;
        float moveLeftRight = Input.GetAxis("Horizontal") * speed;

        // ��������� ������ �������� �� ������ ����������� ������
        Vector3 move = playerCamera.forward * moveForwardBack + playerCamera.right * moveLeftRight;
        move.y = 0; // ���������, ��� �������� ������ �� �����������

        // ���� �������� ��������, ��������� ��� �����������
        if (move != Vector3.zero)
        {
            transform.forward = move;
        }

        // ���������� ���������
        characterController.Move(move * Time.deltaTime);

        // ������������ ������
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }

        // ��������� ����������
        velocity.y += gravity * Time.deltaTime;
        characterController.Move(velocity * Time.deltaTime);
    }

    void HandleMouseLook()
    {
        // �������� ���� � ���� ��� ���������� �������
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity;

        // ��������� ���� ������� ������
        cameraHorizontalAngle += mouseX;
        cameraVerticalAngle -= mouseY;

        // ������������ ������������ ���� ������� ������
        cameraVerticalAngle = Mathf.Clamp(cameraVerticalAngle, -90f, 90f);

        // ��������� ���� �������� ������
        playerCamera.localEulerAngles = new Vector3(cameraVerticalAngle, cameraHorizontalAngle, 0);
    }

    void UpdateCameraPosition()
    {
        // ��������� �������� ������� ������
        Vector3 desiredPosition = transform.position - playerCamera.forward * cameraDistance + Vector3.up * cameraHeight;

        // ������ ���������� ������ � �������� �������
        playerCamera.position = Vector3.Lerp(playerCamera.position, desiredPosition, Time.deltaTime * 5.0f);

        // ������ ������� �� ���������
        playerCamera.LookAt(transform.position + Vector3.up * cameraHeight);
    }
}
