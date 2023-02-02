using UnityEngine;
using UnityEngine.UI;

public class PlayerScoreCounter : MonoBehaviour
{
    public Text playerScoreText;
    int score;
    private void Start()
    {
        score = 0;
    }
    private void Update()
    {
        if (score > 0)
        {
            playerScoreText.color = Color.green;
        }
        else
        {

            playerScoreText.color = Color.red;
        }
    }
    private void OnTriggerEnter(Collider collider)
    {
        if (collider.CompareTag("AddScore"))
        {
            score++;
            playerScoreText.text = score.ToString();
        }

        if (collider.CompareTag("Obstacle"))
        {
            score--;
            playerScoreText.text = score.ToString();
        }

    }
}
