using System.Collections;
using UnityEngine;

public class PlayerCombat : MonoBehaviour
{
    [SerializeField] private Animator playerAnimator;
     private bool isAttacking;
    [SerializeField] private float attackCooldown = 0.5f;

    private PlayerInputHandlerLite playerInputHandler;

    [SerializeField] private GameObject AttackRadius;

    [Header("ComboSetup")]
    private bool canDoNextAttack = false;
    [SerializeField] private int comboStep = 0;
    private float comboResetTimer = 1f;

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
        if (playerInputHandler.AttackTriggered)
        {
            if (!isAttacking )
            {
                isAttacking = true;
                comboStep = 1;
                playerAnimator.SetTrigger("Attack1");
            }
            else if (canDoNextAttack && comboStep == 1)
            {
                canDoNextAttack = false;
                comboStep = 2;
                playerAnimator.SetTrigger("Attack2");
            }
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

    public void EnableNextCombo()
    {
        canDoNextAttack = true;
    }

    public void ResetCombo()
    {
        isAttacking = false;
        canDoNextAttack = false;
        comboStep = 0;
    }

    private IEnumerator ComboResetDelay()
    {
        yield return new WaitForSeconds(comboResetTimer);
        ResetCombo();
    }
}
