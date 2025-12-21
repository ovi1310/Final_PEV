using UnityEngine;

public class PlayerStateMachine : MonoBehaviour
{
    // ---------------------------
    //  PUBLIC VARIABLES
    // ---------------------------
    public PlayerState currentState;

    [Header("Movement Settings")]
    public float moveSpeed = 5f;
    public float jumpForce = 10f;

    [Header("Ground Check")]
    public Transform groundCheck;
    public float groundRadius = 0.2f;
    public LayerMask groundLayer;
    public Animator animator;
    public Vector2 moveInput;
    public bool jumpPressed;
    public bool isGrounded;
    public PlayerControls controls;
    public Rigidbody2D rb;

    // ---------------------------
    //  UNITY METHODS
    // ---------------------------
    private void Awake()
    {
        controls = new PlayerControls();

        // MOVE INPUT
        controls.Player.Move.performed += ctx =>
            moveInput = ctx.ReadValue<Vector2>();

        controls.Player.Move.canceled += ctx =>
            moveInput = Vector2.zero;

        // JUMP INPUT
        controls.Player.Jump.performed += ctx =>
        {
            if (isGrounded)
                jumpPressed = true;
        };
    }

    private void OnEnable()
    {
        controls.Enable();
    }

    private void OnDisable()
    {
        controls.Disable();
    }

    private void Start()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();

        ChangeState(PlayerState.Idle);
    }

    private void Update()
    {
        CheckGround();

        // FSM Update Loop
        switch (currentState)
        {
            case PlayerState.Idle: StateIdle(); break;
            case PlayerState.Walk: StateWalk(); break;
            case PlayerState.Jump: StateJump(); break;
            case PlayerState.Fall: StateFall(); break;
            case PlayerState.Crouch: StateCrouch(); break;
            case PlayerState.AttackMelee: StateAttackMelee(); break;
            case PlayerState.AttackRanged: StateAttackRanged(); break;
            case PlayerState.Interact: StateInteract(); break;
            case PlayerState.TakingDamage: StateTakingDamage(); break;
        }
    }

    private void FixedUpdate()
    {
        ApplyMovement();
    }

    // ---------------------------
    //  GROUND CHECK
    // ---------------------------
    void CheckGround()
    {
        isGrounded = Physics2D.OverlapCircle(
            groundCheck.position,
            groundRadius,
            groundLayer
        );
    }

    // ---------------------------
    //  MOVEMENT
    // ---------------------------
    void ApplyMovement()
    {
        // Movimiento horizontal
        rb.linearVelocity = new Vector2(
            moveInput.x * moveSpeed,
            rb.linearVelocity.y
        );
    }

    // ---------------------------
    //  FSM CORE
    // ---------------------------
    public void ChangeState(PlayerState newState)
    {
        OnExitState(currentState);
        currentState = newState;
        OnEnterState(newState);
    }

    void OnEnterState(PlayerState state)
    {
        switch (state)
        {
            case PlayerState.Idle:
                animator.Play("Idle");
                break;

            case PlayerState.Walk:
                animator.Play("Walk");
                break;

            case PlayerState.Jump:
                animator.Play("Jump");
                rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce);
                break;

            case PlayerState.Fall:
                animator.Play("Fall");
                break;

            case PlayerState.Crouch:
                animator.Play("Crouch");
                break;
        }
    }

    void OnExitState(PlayerState state)
    {
        // Lugar para resetear cosas si lo necesitas
    }

    // ---------------------------
    //  STATE LOGIC
    // ---------------------------
    void StateIdle()
    {
        if (Mathf.Abs(moveInput.x) > 0.1f)
            ChangeState(PlayerState.Walk);

        if (jumpPressed && isGrounded)
        {
            ChangeState(PlayerState.Jump);
            jumpPressed = false;
        }
    }

    void StateWalk()
    {
        if (Mathf.Abs(moveInput.x) < 0.1f)
            ChangeState(PlayerState.Idle);

        if (jumpPressed && isGrounded)
        {
            ChangeState(PlayerState.Jump);
            jumpPressed = false;
        }
    }

    void StateJump()
    {
        if (rb.linearVelocity.y < -0.1f)
            ChangeState(PlayerState.Fall);
    }

    void StateFall()
    {
        if (isGrounded)
            ChangeState(PlayerState.Idle);
    }

    void StateCrouch()
    {
        // Aqu� puedes gestionar el input de agachar
        if (Mathf.Abs(moveInput.x) == 0)
            ChangeState(PlayerState.Idle);
    }

    void StateAttackMelee() { }
    void StateAttackRanged() { }
    void StateInteract() { }
    void StateTakingDamage() { }

    // ---------------------------
    //  DEBUG (Opcional)
    // ---------------------------
    private void OnDrawGizmosSelected()
    {
        if (groundCheck != null)
        {
            Gizmos.color = Color.yellow;
            Gizmos.DrawWireSphere(groundCheck.position, groundRadius);
        }
    }

    public BackgroundManager backgroundManager;

void MatarPersonaje()
{
    backgroundManager.MostrarDistopia();
}

void PerdonarPersonaje()
{
    backgroundManager.MostrarUtopia();
}

}