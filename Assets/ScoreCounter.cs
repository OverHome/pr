using UnityEngine;
using TMPro;

public class ScoreCounter : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    private int score = 0;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("ball"))
        {
            score++;
            scoreText.text = "" + score;
        }
    }
}
