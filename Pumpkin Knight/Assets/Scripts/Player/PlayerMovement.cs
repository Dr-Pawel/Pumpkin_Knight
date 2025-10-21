using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private CharacterController controller;
    private Vector3 playerVelocity;
    private bool groundedPlayer;

    [Header("Movement Settings")]
    public float playerSpeed = 5.0f;
    public float jumpHeight = 1.5f;
    public float gravityValue = -9.81f;

    [Header("Camera")]
    Vector3 camForward;
    Vector3 camRight;

    private void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    private void Update()
    {
        HandleMovement();
    }

    private void HandleMovement()
    {
        GetCameraDirection();
        var input = PlayerInputHandlerLite.Instance;
        Vector2 moveInput = input.MoveInput;
        groundedPlayer = controller.isGrounded;

        Vector3 move = camForward * moveInput.y + camRight * moveInput.x;
        move.Normalize();
        Vector3 finalMove = move * playerSpeed + playerVelocity;
        controller.Move(finalMove * Time.deltaTime);

        if (move != Vector3.zero)
        {
            transform.forward = move;
        }

        if (input.JumpPressed && groundedPlayer)
        {
            playerVelocity.y = Mathf.Sqrt(jumpHeight * -2f * gravityValue);
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
}
