using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] private int maxHealth = 100;
    private int currentHealth;
    private bool isDead = false;

    private Animator animator;

    private void Awake()
    {
        currentHealth = maxHealth;
        animator = GetComponent<Animator>();
    }

    public void TakeDamage(int amount)
    {
        if (isDead) return;

        currentHealth -= amount;
        Debug.Log($"{gameObject.name} took {amount} damage! ({currentHealth}/{maxHealth})");

        if(currentHealth <= 0)
        {
            Die();
        }     
    }
    private void Die()
    {
        isDead = true;
        Debug.Log($"{gameObject.name} died!");

        //if (animator != null)
        //{
        //    animator.SetTrigger("Die");
        //}
        Destroy(gameObject, 2f);
    }


}
