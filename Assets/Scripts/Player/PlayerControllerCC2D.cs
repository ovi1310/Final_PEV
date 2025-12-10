using UnityEngine;

[RequireComponent(typeof(CharacterController))]
[RequireComponent(typeof(PlayerInputHandler))]
public class PlayerControllerCC2D : MonoBehaviour
{
    public float moveSpeed = 6f;

    [Header("Salto")]
    public float jumpForce = 8f;
    public float gravity = -20f;

    [Header("Ground Check")]
    public Transform groundCheck;
    public float groundDistance = 0.1f;
    public LayerMask groundLayer;

    [Header("Crouch")]
    public float crouchHeight = 1f;      // Altura al agacharse
    private float originalHeight;


    private CharacterController controller;
    private PlayerInputHandler input;
    private Vector3 velocity;
    private bool isGrounded;

    void Start()
    {
        controller = GetComponent<CharacterController>();
        input = GetComponent<PlayerInputHandler>();
        originalHeight = controller.height;
    }

    void Update()
    {
        // GROUND CHECK
        isGrounded = Physics.Raycast(groundCheck.position, Vector3.down, groundDistance, groundLayer);

        if (isGrounded && velocity.y < 0)
            velocity.y = -2f;

        // MOVIMIENTO 2D (solo X)
        float moveX = input.MoveInput.x;
        Vector3 move = new Vector3(moveX, 0f, 0f);

        controller.Move(move * moveSpeed * Time.deltaTime);

        // SALTO
        if (input.JumpPressed && isGrounded)
        {
            // Reseteamos velocidad vertical para cancelar el salto previo
            velocity.y = 0f;

            // Aplicamos la fuerza de salto
            velocity.y = Mathf.Sqrt(jumpForce * -2f * gravity);
            input.ConsumeJump();
        }


        // GRAVEDAD
        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);

        // CROUCH
        if (input.CrouchPressed && isGrounded)
        {
            controller.height = crouchHeight;
            controller.center = new Vector3(0, crouchHeight / 2f, 0); // centro ajustado
        }
        else
        {
            if (CanStandUp())
            {
                controller.height = originalHeight;
                controller.center = new Vector3(0, originalHeight / 100f, 0);
            }
        }

        float speed = input.CrouchPressed ? moveSpeed * 0.5f : moveSpeed;
        controller.Move(move * speed * Time.deltaTime);

    }

    private bool CanStandUp()
    {
        float castDistance = originalHeight - crouchHeight;
        return !Physics.Raycast(transform.position, Vector3.up, castDistance, groundLayer);
    }

    void OnDrawGizmosSelected()
    {
        if (groundCheck != null)
        {
            Gizmos.color = Color.red;
            Gizmos.DrawLine(groundCheck.position, groundCheck.position + Vector3.down * groundDistance);
        }
    }
}
