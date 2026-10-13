using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerFallDetector : MonoBehaviour
{
    [Header("Batas Bawah (Ketinggian Air)")]
    [Tooltip("Jika Posisi Y Player kurang dari angka ini, maka dianggap masuk air/jatuh.")]
    [SerializeField] private float fallThresholdY = -2.5f;

    [Header("Aksi Game Over")]
    [SerializeField] private GameObject gameOverPanel;
    [SerializeField] private bool restartSceneOnDeath = true;

    private bool isDead = false;

    void Update()
    {
        // Cek posisi Y player setiap frame
        if (transform.position.y < fallThresholdY && !isDead)
        {
            Die();
        }
    }

    private void Die()
    {
        isDead = true;
        Debug.Log("Player masuk air / jatuh ke bawah!");

        if (gameOverPanel != null)
        {
            gameOverPanel.SetActive(true);
            Time.timeScale = 0f;
        }

        if (restartSceneOnDeath)
        {
            Time.timeScale = 1f;
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }

    // Biar kelihatan batas garisnya di jendela Scene Unity
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawLine(new Vector3(-100, fallThresholdY, 0), new Vector3(100, fallThresholdY, 0));
    }
}