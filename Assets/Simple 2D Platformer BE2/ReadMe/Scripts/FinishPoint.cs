using UnityEngine;
using UnityEngine.SceneManagement; // Dibutuhkan jika ingin pindah Scene

public class FinishPoint : MonoBehaviour
{
    [Header("Pengaturan Finish")]
    [Tooltip("Nama Tag dari GameObject Pemain")]
    [SerializeField] private string playerTag = "Player";

    [Tooltip("Nama Scene yang akan dimuat saat finish (Opsional)")]
    [SerializeField] private string nextSceneName = "";

    [Tooltip("Panel UI Selesai / Game Over (Opsional)")]
    [SerializeField] private GameObject finishUIPanel;

    private bool isFinished = false;

    private void OnTriggerEnter(Collider other)
    {
        // Mengecek apakah yang menyentuh adalah Pemain dan game belum selesai
        if (other.CompareTag(playerTag) && !isFinished)
        {
            CompleteGame();
        }
    }

    // Gunakan fungsi ini jika game kamu berbentuk 2D
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag(playerTag) && !isFinished)
        {
            CompleteGame();
        }
    }

    private void CompleteGame()
    {
        isFinished = true;
        Debug.Log("Selamat! Game Selesai.");

        // Pilihan 1: Tampilkan UI Selesai jika ada
        if (finishUIPanel != null)
        {
            finishUIPanel.SetActive(true);
            Time.timeScale = 0f; // Menghentikan pergerakan game
        }

        // Pilihan 2: Pindah ke Scene Berikutnya (jika nama scene diisi)
        if (!string.IsNullOrEmpty(nextSceneName))
        {
            Time.timeScale = 1f; // Pastikan timeScale kembali normal sebelum pindah scene
            SceneManager.LoadScene(nextSceneName);
        }
    }
}