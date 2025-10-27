using UnityEngine;

public abstract class Health : MonoBehaviour
{
    
    public int CurrentHealth { get; set; }
    public bool isDead { get; set; }

    [SerializeField] public Animator animator;
    
    public abstract void TakeDamage(int amount);

    public void Die()
    {
        isDead = true;
        Debug.Log($"{gameObject.name} died!");

        if (animator != null)
        {
            animator.SetTrigger("Die");
        }
    }


}
