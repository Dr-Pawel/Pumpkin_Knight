using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public List<int> collectedKeyIDs = new List<int>();

    private void OnTriggerEnter(Collider other)
    {
        Key pickedKey = other.GetComponent<Key>();
        if (pickedKey != null)
        {
            collectedKeyIDs.Add(pickedKey.KeyID);
            Destroy(other.gameObject);
        }
        if (other.CompareTag("lock"))
        {
            Lock doorLock = other.GetComponent<Lock>();
            if (doorLock != null)
            {
                foreach (int keyID in collectedKeyIDs)
                {
                    if (doorLock.TryUnlock(keyID))
                    {
                        Debug.Log($"Użyto klucza {keyID}");
                        return;
                    }
                }
            }
        }
    }
}
