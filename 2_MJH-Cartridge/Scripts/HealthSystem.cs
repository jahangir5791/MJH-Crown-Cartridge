using UnityEngine;
using UnityEngine.UI;

public class HealthSystem : MonoBehaviour
{
    public int maxHealth = 100;
    public int currentHealth;
    public Image healthBar;
    
    void Start()
    {
        currentHealth = maxHealth;
    }
    
    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        UpdateHealthBar();
        
        if (currentHealth <= 0)
        {
            Die();
        }
    }
    
    void UpdateHealthBar()
    {
        if (healthBar != null)
        {
            healthBar.fillAmount = (float)currentHealth / maxHealth;
        }
    }
    
    void Die()
    {
        AudioManager.Instance?.PlaySFX("GameOver");
        
        if (gameObject.CompareTag("Player"))
        {
            GameManager.Instance?.PauseGame();
            UIManager.Instance?.ShowPauseMenu();
        }
        else
        {
            Destroy(gameObject);
            GameManager.Instance?.AddScore(10);
        }
    }
}
