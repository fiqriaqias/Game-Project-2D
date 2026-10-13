using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverManager : MonoBehaviour
{
    [SerializeField] private GameObject gameOverPanel;

    public void TriggerGameOver()
    {
        if (gameOverPanel != null)
        {
            gameOverPanel.SetActive(true);
        }
        // Hentikan waktu permainan
        Time.timeScale = 0f;
    }

    // Fungsi untuk tombol RETRY
    public void RestartGame()
    {
        // Kembalikan waktu berjalan normal sebelum reload
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    // Fungsi untuk tombol MAIN MENU
    public void GoToMainMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("SceneMenu"); // Sesuaikan dengan nama scene menu Anda
    }
}