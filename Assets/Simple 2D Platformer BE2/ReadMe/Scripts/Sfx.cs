using UnityEngine;

public class Sfx : MonoBehaviour
{
    [Header("Audio")]
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip pointSound;
    [SerializeField] private AudioClip enemySound; // Suara saat kena musuh

    [Header("Skor")]
    [SerializeField] private int currentScore = 0;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Poin"))
        {
            // Tambah poin
            currentScore += 10;

            // Putar sound effect poin
            if (audioSource != null && pointSound != null)
            {
                audioSource.PlayOneShot(pointSound);
            }

            // Hancurkan objek koin
            Destroy(other.gameObject);
        }
        else if (other.CompareTag("Musuh"))
        {
            // Putar sound effect musuh
            if (audioSource != null && enemySound != null)
            {
                audioSource.PlayOneShot(enemySound);
            }

            // Opsional: tambahkan aksi lain di sini (misal mengurangi darah/skor)
        }
    }
}