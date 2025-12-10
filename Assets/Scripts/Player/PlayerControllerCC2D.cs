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

    private CharacterController controller;
    private PlayerInputHandler input;
    private Vector3 velocity;
    private bool isGrounded;

    void Start()
    {
        controller = GetComponent<CharacterController>();
        input = GetComponent<PlayerInputHandler>();
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
            velocity.y = Mathf.Sqrt(jumpForce * -2f * gravity);
            input.ConsumeJump();
        }

        // GRAVEDAD
        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);
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
