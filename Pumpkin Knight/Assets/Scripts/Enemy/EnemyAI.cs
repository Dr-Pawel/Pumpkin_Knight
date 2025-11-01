using System.Collections;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    private GameObject target;
    private Health playerHealth;
    private Transform playerPosition;
    [SerializeField] EnemyHealth health;
    [SerializeField] private float attackDistance;
    [SerializeField] private float ChaseDistance;

    [SerializeField] private NavMeshAgent enemyAgent;
    [SerializeField] private Animator animator;
    private float distanceToPlayer;
    


    private bool isAttacking;
    [SerializeField] private float attackCooldown = 2f;

    private void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player");
        playerPosition = target.transform;
        playerHealth = target.GetComponent<Health>();
    }

    private void Update()
    {
        if (health.isDead) return;
        if (target == null)
        {
            target = GameObject.FindGameObjectWithTag("Player");
            if (target != null) playerPosition = target.transform;
            return;
        }

        distanceToPlayer = Vector3.Distance(enemyAgent.transform.position, playerPosition.position);

        if (distanceToPlayer <= attackDistance)
        {
            AttackPlayer();
        }
        else if (distanceToPlayer < ChaseDistance)
        {
            ChasePlayer();
        }
        else 
        {
            enemyAgent.isStopped = true;
            animator.SetBool("isMoving", false);
        }
    }

    private void ChasePlayer()
    {
        enemyAgent.isStopped = false;
        animator.SetBool("isMoving", true);
        enemyAgent.destination = playerPosition.position;
    }

    private void AttackPlayer()
    {
        if (!isAttacking)
        {
            isAttacking = true;
            int randomAttack = Random.Range(0, 2);
            animator.SetTrigger(randomAttack == 0 ? "Attack1" : "Attack2");
            enemyAgent.isStopped = true;
            Vector3 lookDirection = (playerPosition.position - transform.position).normalized;
            lookDirection.y = 0;
            Quaternion targetRotation = Quaternion.LookRotation(lookDirection);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * 5f);
            if (playerHealth != null && playerHealth.CurrentHealth > 0)
            {
                playerHealth.TakeDamage(5);
            }
            StartCoroutine(ResetAttack());
        }
    }


    private IEnumerator ResetAttack()
    {
        yield return new WaitForSeconds(attackCooldown);
        isAttacking = false;
    }
}
