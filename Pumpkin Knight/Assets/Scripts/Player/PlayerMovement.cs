using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private CharacterController controller;
    private Vector3 playerVelocity;
    [SerializeField] private bool groundedPlayer;
    [SerializeField] private Animator animator;

    [Header("Movement Settings")]
    public float playerSpeed = 5.0f;
    public float jumpHeight = 1.5f;
    public float gravityValue = -9.81f;
    public bool canMove { get; set; } = true;

    [Header("Grounded settings")]
    [SerializeField] private Transform groundCheck;
    [SerializeField] private float groundDistance = 0.4f;
    [SerializeField] private LayerMask groundMask;

    [Header("Pause")]
    public bool isPaused { get; set; }
    public GameObject pauseMenu;

    [Header("Camera")]
    Vector3 camForward;
    Vector3 camRight;

    private void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    private void Update()
    {
        groundedPlayer = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);
        HandleMovement();
        PauseMenu();
    }

    private void HandleMovement()
    {
        if(!canMove)
        {
            animator.SetBool("isMoving", false);
            return;
        }
        GetCameraDirection();
        var input = PlayerInputHandlerLite.Instance;
        Vector2 moveInput = input.MoveInput;
        //groundedPlayer = controller.isGrounded;

        Vector3 move = camForward * moveInput.y + camRight * moveInput.x;
        move.Normalize();
        Vector3 finalMove = move * playerSpeed + playerVelocity;
        controller.Move(finalMove * Time.deltaTime);


        if (move != Vector3.zero)
        {
            transform.forward = move;
            animator.SetBool("isMoving", true);
        }
        else
        {
            animator.SetBool("isMoving", false);
        }

        if (input.JumpPressed && groundedPlayer)
        {
            animator.SetTrigger("Jump");
            playerVelocity.y = Mathf.Sqrt(jumpHeight * -2f * gravityValue);
            input.ResetJump();
        }

        playerVelocity.y += gravityValue * Time.deltaTime;
    }

    private void GetCameraDirection()
    {
        Transform camTransform = Camera.main.transform;

        camForward = camTransform.forward;
        camRight = camTransform.right;

        camForward.y = 0f;
        camRight.y = 0f;

        camForward.Normalize();
        camRight.Normalize();
    }

    public void PauseMenu()
    {
        var input = PlayerInputHandlerLite.Instance;
        if (input.PauseTriggered)
        {
            if(!isPaused)
            {
                isPaused = true;
                Time.timeScale = 0;
                pauseMenu.SetActive(true);
                Cursor.visible = true;
                Cursor.lockState = CursorLockMode.None;
                input.ResetPause();
            }
            else
            {
                isPaused = false;
                pauseMenu.SetActive(false);
                Time.timeScale = 1;
                Cursor.visible = true;
                Cursor.lockState = CursorLockMode.Locked;
                input.ResetPause();
            }
        }
    }
}
