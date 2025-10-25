using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] public int maxHealth  = 100;
    public int CurrentHealth { get; private set; }
    public bool isDead { get; set; }
    [SerializeField] private bool isAPlayer = false;

    [SerializeField]private Animator animator;
    [SerializeField] PlayerHealthBar healthBar;

    private void Awake()
    {
        CurrentHealth = maxHealth;
    }

    public void TakeDamage(int amount)
    {
        if (isDead) return;

        CurrentHealth -= amount;
        Debug.Log($"{gameObject.name} took {amount} damage! ({CurrentHealth}/{maxHealth})");
        if(!isAPlayer)
        {
            animator.SetTrigger("TakeDamage");
        }
        if(isAPlayer)
        {
            healthBar.HealthBarUpdate();
        }

        if (CurrentHealth <= 0)
        {
            Die();
        }     
    }
    private void Die()
    {
        isDead = true;
        Debug.Log($"{gameObject.name} died!");

        if (animator != null)
        {
            animator.SetTrigger("Die");
        }
    }


}
