using UnityEngine;

public class PlayerHealth : Health
{
    [SerializeField] PlayerHealthBar healthBar;
    [SerializeField] public int maxHealth;

    private void Awake()
    {
        CurrentHealth = maxHealth;
    }
    public override void TakeDamage(int amount)
    {
        if (isDead) return;

        CurrentHealth -= amount;
        Debug.Log($"{gameObject.name} took {amount} damage! ({CurrentHealth}/{maxHealth})");

        if (CurrentHealth <= 0)
        {
            Die();
        }
            healthBar.HealthBarUpdate();
        
    }
}
