using UnityEngine;

public class tutorialPopUp : MonoBehaviour
{
    [SerializeField] private GameObject Panel;
    private bool isPopupOpen = false;
    [SerializeField] private PlayerMovement playerMovement;

    private void Update()
    {
        ClosePopUp();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            ShowPopUp();
        }
    }

    private void ShowPopUp()
    {
        if(!isPopupOpen)
        {
            Panel.SetActive(true);
            isPopupOpen = true;
            playerMovement.canMove = false;
        }
    }

    private void ClosePopUp()
    {
        var input = PlayerInputHandlerLite.Instance;
        if (isPopupOpen && input.JumpPressed)
        {
            Panel.SetActive(false);
            playerMovement.canMove = true;
        }
    }
}
