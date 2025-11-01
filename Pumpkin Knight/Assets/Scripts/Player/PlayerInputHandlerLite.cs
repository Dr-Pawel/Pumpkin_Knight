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
    private InputAction PauseAction;

    public Vector2 MoveInput { get; private set; }
    public bool JumpPressed { get; private set; }
    public bool AttackTriggered { get; private set; }
    public bool  RotateLeftTriggered { get; private set; }
    public bool RotateRightTriggered { get; private set; }
    public bool PauseTriggered { get; private set; }


    private void Awake()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;

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
        PauseAction = map.FindAction("Pause");

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

        PauseAction.performed += ctx => PauseTriggered = true;
        PauseAction.canceled += ctx => PauseTriggered = false;
    }

    private void OnEnable()
    {
        moveAction?.Enable();
        jumpAction?.Enable();
        attackAction?.Enable();
        rotateRightAction?.Enable();
        rotateLeftAction?.Enable();
        PauseAction?.Enable();
    }

    private void OnDisable()
    {
        moveAction?.Disable();
        jumpAction?.Disable();
        attackAction?.Disable();
        rotateRightAction?.Disable();
        rotateLeftAction?.Disable();
        PauseAction?.Disable();
    }

    public void ResetJump()
    {
        JumpPressed = false;
    }
    public void ResetPause()
    {
        PauseTriggered = false;
    }
}

