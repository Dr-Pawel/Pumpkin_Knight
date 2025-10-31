using UnityEngine;
using TMPro;

public class PlayerHealth : Health
{
    [SerializeField] PlayerHealthBar healthBar;
    [SerializeField] public int maxHealth;
    [SerializeField] TextMeshProUGUI healthNumber;

    private void Awake()
    {
        CurrentHealth = maxHealth;
    }
    public override void TakeDamage(int amount)
    {
        if (isDead) return;

        CurrentHealth -= amount;
        Debug.Log($"{gameObject.name} took {amount} damage! ({CurrentHealth}/{maxHealth})");
        healthNumber.text = CurrentHealth.ToString();

        if (CurrentHealth <= 0)
        {
            Die();
        }
            healthBar.HealthBarUpdate();
        
    }
}
