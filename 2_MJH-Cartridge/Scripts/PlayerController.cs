using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float jumpForce = 7f;
    private Rigidbody rb;
    private bool isGrounded;
    
    void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }
    
    void Update()
    {
        if (PlatformDetector.IsMobile())
        {
            HandleMobileInput();
        }
        else
        {
            HandlePCInput();
        }
    }
    
    void HandleMobileInput()
    {
        Vector2 input = CrossPlatformInput.GetInput();
        Move(input);
        
        if (CrossPlatformInput.GetInputButton() && isGrounded)
        {
            Jump();
        }
    }
    
    void HandlePCInput()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        Move(new Vector2(horizontal, vertical));
        
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            Jump();
        }
    }
    
    void Move(Vector2 input)
    {
        Vector3 movement = new Vector3(input.x, 0, input.y);
        rb.velocity = new Vector3(movement.x * moveSpeed, rb.velocity.y, movement.y * moveSpeed);
    }
    
    void Jump()
    {
        rb.velocity = new Vector3(rb.velocity.x, jumpForce, rb.velocity.z);
        isGrounded = false;
    }
    
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }
}
