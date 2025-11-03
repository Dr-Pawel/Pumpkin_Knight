using UnityEngine;

public class Lock : MonoBehaviour
{
    [SerializeField] private int requiredKeyID = 0;
    [SerializeField] private Animator doorAnimator;
    private bool isOpened = false;

    public bool TryUnlock(int keyID)
    {
        if (isOpened) return false;

        if (keyID == requiredKeyID)
        {
            isOpened = true;
            if (doorAnimator != null)
                doorAnimator.SetTrigger("Open");

            Debug.Log("DoorOpen");
            return true;
        }

        Debug.Log("WrongKey");
        return false;
    }
}
