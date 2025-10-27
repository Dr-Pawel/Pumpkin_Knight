using UnityEngine;

public class EnemyHealth : Health
{
    [SerializeField] private int maxHealth; 

    private void Awake()
    {
        CurrentHealth = maxHealth;
    }
    public override void TakeDamage(int amount)
    {
        if (isDead) return;

        CurrentHealth -= amount;
        Debug.Log($"{gameObject.name} took {amount} damage! ({CurrentHealth}/{maxHealth})");
        animator.SetTrigger("TakeDamage");      

        if (CurrentHealth <= 0)
        {
            Die();
        }
    }
}
