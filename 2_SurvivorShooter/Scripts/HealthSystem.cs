using UnityEngine;

public class HealthSystem : MonoBehaviour
{
    [Header("Health Settings")]
    public float maxHealth = 100f;
    public float currentHealth;
    
    [Header("UI")]
    public GameObject deathEffect;
    
    private bool isDead = false;

    void Start()
    {
        currentHealth = maxHealth;
        UpdateHealthUI();
    }

    public void TakeDamage(float damage)
    {
        if (isDead) return;
        
        currentHealth -= damage;
        currentHealth = Mathf.Max(0, currentHealth);
        
        UpdateHealthUI();
        
        if (currentHealth <= 0)
        {
            Die();
        }
    }

    public void Heal(float amount)
    {
        if (isDead) return;
        
        currentHealth += amount;
        currentHealth = Mathf.Min(maxHealth, currentHealth);
        
        UpdateHealthUI();
    }

    void UpdateHealthUI()
    {
        UIManager.Instance?.UpdateHealthUI(currentHealth, maxHealth);
    }

    void Die()
    {
        isDead = true;
        
        if (deathEffect != null)
        {
            Instantiate(deathEffect, transform.position, Quaternion.identity);
        }
        
        AudioManager.Instance?.PlaySFX("Player_Death");
        
        GameManager.Instance?.ChangeState(GameState.GameOver);
        
        // প্লেয়ার ডিসেবল করুন
        GetComponent<PlayerController>().enabled = false;
        GetComponent<PlayerShooting>().enabled = false;
    }
}
