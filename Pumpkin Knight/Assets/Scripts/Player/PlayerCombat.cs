using System.Collections;
using UnityEngine;

public class PlayerCombat : MonoBehaviour
{
    [SerializeField] private Animator playerAnimator;
     private bool isAttacking;
    [SerializeField] private float attackCooldown = 0.5f;

    private PlayerInputHandlerLite playerInputHandler;

    [SerializeField] private GameObject AttackRadius;

    private void Start()
    {
        playerInputHandler = PlayerInputHandlerLite.Instance;
    }

    private void Update()
    {
        Attack();
    }

    private void Attack()
    {
        if(playerInputHandler.AttackTriggered && !isAttacking)
        {
            IsAttacking();
            playerAnimator.SetTrigger("Attack");
        }
    }

    public IEnumerator AttackCooldown()
    {
        yield return new WaitForSeconds(attackCooldown);
        IsNotAttacking();
    }

    public void StartAttackCooldown()
    {
        StartCoroutine(AttackCooldown());
    }

    public void IsAttacking()
    {
        isAttacking = true;
    }
    private void IsNotAttacking()
    {
        isAttacking = false;
    }
    private void AttackRadiusON()
    {
        AttackRadius.SetActive(true);
    }
    private void AttackRadiusOFF()
    {
        AttackRadius.SetActive(false);
    }
}
