using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Score : MonoBehaviour
{
    public int score = 0;
    public GameObject objekScore;
    private TextMeshProUGUI textScore;

    void Start()
    {
        if (objekScore != null)
        {
            textScore = objekScore.GetComponent<TextMeshProUGUI>();
            textScore.text = score.ToString(); // Menampilkan skor awal saat game mulai
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Musuh"))
        {
            score -= 10; // Mengurangi 10
            UpdateScoreUI();
            Destroy(other.gameObject);
        }
        else if (other.CompareTag("Poin")) // Sebaiknya gunakan tag spesifik, bukan sekadar else
        {
            score += 10; // Menambah 10
            UpdateScoreUI();
            Destroy(other.gameObject);
        }
    }

    void UpdateScoreUI()
    {
        if (textScore != null)
        {
            textScore.text = score.ToString();
        }
    }
}