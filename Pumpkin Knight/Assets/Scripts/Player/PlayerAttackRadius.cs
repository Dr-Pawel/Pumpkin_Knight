using System.Collections.Generic;
using UnityEngine;

public class PlayerAttackRadius : MonoBehaviour
{
    private HashSet<GameObject> hitEnemies = new HashSet<GameObject>();

    private void OnEnable()
    {
        hitEnemies.Clear();
    }


    [SerializeField] private int attackDamage = 20;
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Enemy") && !hitEnemies.Contains(other.gameObject))
        {
            hitEnemies.Add(other.gameObject);
            Health enemyHealth = other.GetComponent<Health>();

            if (enemyHealth != null)
            {
                enemyHealth.TakeDamage(attackDamage);
                Debug.Log($" {other.name} took {attackDamage} damage!");
            }
        }
    }
}
