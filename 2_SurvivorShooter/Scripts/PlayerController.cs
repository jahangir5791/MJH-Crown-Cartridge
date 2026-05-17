using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("Movement")]
    public float moveSpeed = 5f;
    public float mouseSensitivity = 2f;

    [Header("References")]
    public Camera playerCamera;
    public Transform weaponHolder;

    private float verticalRotation = 0f;
    private CharacterController characterController;
    private Vector3 moveDirection;
    private HealthSystem healthSystem;

    void Start()
    {
        characterController = GetComponent<CharacterController>();
        healthSystem = GetComponent<HealthSystem>();
        
        if (playerCamera == null)
            playerCamera = Camera.main;
            
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        if (GameManager.Instance.currentState != GameState.Playing)
            return;

        HandleMouseLook();
        HandleMovement();
    }

    void HandleMouseLook()
    {
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity;
        
        // horizontal rotation
        transform.Rotate(0, mouseX, 0);
        
        // উল্লম্ব রোটেশন (ক্যামেরা)
        verticalRotation -= mouseY;
        verticalRotation = Mathf.Clamp(verticalRotation, -90f, 90f);
        playerCamera.transform.localRotation = Quaternion.Euler(verticalRotation, 0, 0);
    }

    void HandleMovement()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        
        Vector3 move = transform.right * horizontal + transform.forward * vertical;
        characterController.Move(move * moveSpeed * Time.deltaTime);
    }

    public void TakeDamage(float damage)
    {
        healthSystem?.TakeDamage(damage);
    }
}
