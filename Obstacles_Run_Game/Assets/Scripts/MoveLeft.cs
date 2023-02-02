using UnityEngine;
using UnityEngine.UI;

public class MoveLeft : MonoBehaviour
{
    float speed = 30f;
    PlayerController playerControllerScript;
    float leftBound = -15;
    private void Start()
    {
        playerControllerScript = GameObject.Find("Player").GetComponent<PlayerController>();
    }
    void Update()
    {
        if (!playerControllerScript.gameOver)
            transform.Translate(speed * Time.deltaTime * Vector3.left);

        if (transform.position.x < leftBound && gameObject.CompareTag("Obstacle"))
            Destroy(gameObject);

    }
}
