using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInputHandler : MonoBehaviour
{
    public InputActionAsset inputActions;

    private InputActionMap playerMap;
    private InputAction moveAction;
    private InputAction jumpAction;
    private InputAction attackMeleeAction;
    private InputAction attackRangedAction;
    private InputAction crouchAction;

    public Vector2 MoveInput { get; private set; }
    public bool JumpPressed { get; private set; }
    public bool AttackMeleePressed { get; private set; }
    public bool AttackRangedPressed { get; private set; }
    public bool CrouchPressed { get; private set; }

    void Awake()
    {
        playerMap = inputActions.FindActionMap("Player");

        moveAction = playerMap.FindAction("Move");
        jumpAction = playerMap.FindAction("Jump");
        attackMeleeAction = playerMap.FindAction("AttackMelee");
        attackRangedAction = playerMap.FindAction("AttackRanged");
        crouchAction = playerMap.FindAction("Crouch");
    }

    void OnEnable()
    {
        playerMap.Enable();

        moveAction.performed += ctx => MoveInput = ctx.ReadValue<Vector2>();
        moveAction.canceled += ctx => MoveInput = Vector2.zero;

        jumpAction.performed += ctx => JumpPressed = true;

        attackMeleeAction.performed += ctx => AttackMeleePressed = true;
        attackRangedAction.performed += ctx => AttackRangedPressed = true;

        crouchAction.performed += ctx => CrouchPressed = true;
        crouchAction.canceled += ctx => CrouchPressed = false;
    }

    void OnDisable()
    {
        playerMap.Disable();
    }

    public void ConsumeJump() => JumpPressed = false;
    public void ConsumeMelee() => AttackMeleePressed = false;
    public void ConsumeRanged() => AttackRangedPressed = false;
    public void ConsumeCrouch() => CrouchPressed = false;
}
