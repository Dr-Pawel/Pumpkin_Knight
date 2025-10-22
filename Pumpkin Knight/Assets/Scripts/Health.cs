using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] private int maxHealth = 100;
    public int CurrentHealth { get; private set; }
    private bool isDead = false;

    private Animator animator;

    private void Awake()
    {
        CurrentHealth = maxHealth;
        animator = GetComponent<Animator>();
    }

    public void TakeDamage(int amount)
    {
        if (isDead) return;

        CurrentHealth -= amount;
        Debug.Log($"{gameObject.name} took {amount} damage! ({CurrentHealth}/{maxHealth})");

        if(CurrentHealth <= 0)
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
