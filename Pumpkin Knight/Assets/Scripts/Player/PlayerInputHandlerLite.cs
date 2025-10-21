using UnityEngine;

using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInputHandlerLite : MonoBehaviour
{
    public static PlayerInputHandlerLite Instance { get; private set; }

    [Header("Input Asset Setup")]
    [SerializeField] private InputActionAsset controls;
    [SerializeField] private string actionMapName = "Player";

    private InputAction moveAction;
    private InputAction jumpAction;
    private InputAction attackAction;
    private InputAction rotateLeftAction;
    private InputAction rotateRightAction;

    public Vector2 MoveInput { get; private set; }
    public bool JumpPressed { get; private set; }
    public bool AttackTriggered { get; private set; }
    public bool  RotateLeftTriggered { get; private set; }
    public bool RotateRightTriggered { get; private set; }

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;

        var map = controls.FindActionMap(actionMapName);
        moveAction = map.FindAction("Move");
        jumpAction = map.FindAction("Jump");
        attackAction = map.FindAction("Attack");
        rotateLeftAction = map.FindAction("RotateLeft");
        rotateRightAction = map.FindAction("RotateRight");

        // Register actions
        moveAction.performed += ctx => MoveInput = ctx.ReadValue<Vector2>();
        moveAction.canceled += ctx => MoveInput = Vector2.zero;

        jumpAction.performed += ctx => JumpPressed = true;
        jumpAction.canceled += ctx => JumpPressed = false;

        attackAction.performed += ctx => AttackTriggered = true;
        attackAction.canceled += ctx => AttackTriggered = false;

        rotateLeftAction.performed += ctx => RotateLeftTriggered = true;
        rotateLeftAction.canceled += ctx => RotateLeftTriggered = false;

        rotateRightAction.performed += ctx => RotateRightTriggered = true;
        rotateRightAction.canceled += ctx => RotateRightTriggered = false;
    }

    private void OnEnable()
    {
        moveAction?.Enable();
        jumpAction?.Enable();
        attackAction?.Enable();
        rotateRightAction?.Enable();
        rotateLeftAction?.Enable();
    }

    private void OnDisable()
    {
        moveAction?.Disable();
        jumpAction?.Disable();
        attackAction?.Disable();
        rotateRightAction?.Disable();
        rotateLeftAction?.Disable();
    }
}

