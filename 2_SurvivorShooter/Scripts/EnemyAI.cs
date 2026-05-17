using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    [Header("Stats")]
    public float health = 50f;
    public float damage = 10f;
    public float attackRange = 2f;
    public float attackCooldown = 1f;
    public int scoreValue = 100;

    [Header("Movement")]
    public float stoppingDistance = 1.5f;
    
    [Header("References")]
    public Transform player;
    public NavMeshAgent agent;
    public Animator animator;

    private float lastAttackTime;
    private bool isDead = false;

    void Start()
    {
        if (player == null && GameObject.FindGameObjectWithTag("Player") != null)
            player = GameObject.FindGameObjectWithTag("Player").transform;
        
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
        
        if (agent != null)
            agent.stoppingDistance = stoppingDistance;
    }

    void Update()
    {
        if (isDead) return;
        if (GameManager.Instance.currentState != GameState.Playing) return;
        
        if (player != null)
        {
            float distance = Vector3.Distance(transform.position, player.position);
            
            if (distance <= attackRange)
            {
                Attack();
            }
            else
            {
                Chase();
            }
        }
    }

    void Chase()
    {
        if (agent != null && agent.isActiveAndEnabled)
        {
            agent.SetDestination(player.position);
            if (animator != null)
                animator.SetBool("IsMoving", true);
        }
    }

    void Attack()
    {
        if (agent != null)
            agent.ResetPath();
        
        if (animator != null)
            animator.SetBool("IsMoving", false);
        
        if (Time.time >= lastAttackTime + attackCooldown)
        {
            lastAttackTime = Time.time;
            
            if (animator != null)
                animator.SetTrigger("Attack");
            
            PlayerController playerController = player.GetComponent<PlayerController>();
            if (playerController != null)
            {
                playerController.TakeDamage(damage);
                AudioManager.Instance?.PlaySFX("Enemy_Attack");
            }
        }
    }

    public void TakeDamage(float damageAmount)
    {
        health -= damageAmount;
        AudioManager.Instance?.PlaySFX("Enemy_Hit");
        
        if (health <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        isDead = true;
        
        if (animator != null)
            animator.SetTrigger("Die");
        
        GameManager.Instance?.AddScore(scoreValue);
        AudioManager.Instance?.PlaySFX("Enemy_Death");
        
        if (agent != null)
            agent.isStopped = true;
        
        Destroy(gameObject, 2f);
    }
}
