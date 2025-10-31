using UnityEngine;

public class Key : MonoBehaviour
{
    [SerializeField] public int KeyID;

    private void Update()
    {
        gameObject.transform.Rotate(0, 1, 0);
    }
}
