using System;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    [Header("Pengaturan Nyawa")]
    [SerializeField] private int maxHealth = 100;
    [SerializeField] private int currentHealth;
    [SerializeField] private int damagePerHit = 20;

    [Header("Referensi UI")]
    [SerializeField] private Slider healthSlider;
    [SerializeField] private GameOverManager gameOverManager;

    void Start()
    {
        currentHealth = maxHealth;

        if (healthSlider != null)
        {
            healthSlider.maxValue = maxHealth;
            healthSlider.value = currentHealth;
        }
    }

    // Deteksi tabrakan fisik 2D (Collider2D tanpa 'Is Trigger')
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Musuh"))
        {
            TakeDamage(damagePerHit);
        }
    }

    // Deteksi sentuhan area 2D (Collider2D dengan 'Is Trigger' dicentang)
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Musuh"))
        {
            TakeDamage(damagePerHit);
        }
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);

        UpdateHealthUI();

        if (currentHealth <= 0)
        {
            gameOverManager.TriggerGameOver();
        }
    }

    private void UpdateHealthUI()
    {
        if (healthSlider != null)
        {
            healthSlider.value = currentHealth;
        }
    }

    private void Die()
    {
        Debug.Log("Player Kalah!");
        // Logika saat nyawa habis
        gameObject.SetActive(false);
    }
}