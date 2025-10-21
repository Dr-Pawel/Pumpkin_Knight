using UnityEngine;
using Unity.Cinemachine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private CinemachineOrbitalFollow orbitalFollow;

    private PlayerInputHandlerLite playerInputHandler;

    [SerializeField] float rotationSpeed = 100f;


    private void Start()
    {
        playerInputHandler = PlayerInputHandlerLite.Instance;
    }

    private void Update()
    {
        RotateLeft();
        RotateRight();
    }

    private void RotateLeft()
    {
        if(playerInputHandler.RotateLeftTriggered)
        {
            orbitalFollow.HorizontalAxis.Value += rotationSpeed * Time.deltaTime;

        }
    }

    private void RotateRight()
    {
        if (playerInputHandler.RotateRightTriggered)
        {
            orbitalFollow.HorizontalAxis.Value -= rotationSpeed * Time.deltaTime;

        }
    }
}
