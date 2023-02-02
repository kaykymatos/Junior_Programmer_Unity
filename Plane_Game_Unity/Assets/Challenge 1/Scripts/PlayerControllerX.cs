using UnityEngine;
using UnityEngine.UI;

public class PlayerControllerX : MonoBehaviour
{
    public float speed;
    public float rotationSpeed;
    float verticalInput;

    public Text scoreText;
    int score;


    // Update is called once per frame
    void FixedUpdate()
    {
        // get the user's vertical input
        verticalInput = Input.GetAxis("Vertical");

        // move the plane forward at a constant rate
        transform.Translate(verticalInput * Time.deltaTime * Vector3.up);
        transform.Translate(speed * Time.deltaTime * Vector3.forward);

        // tilt the plane up/down based on up/down arrow keys
        // transform.Rotate(Vector3.right * rotationSpeed * Time.deltaTime);
        transform.Rotate(verticalInput * rotationSpeed * Time.deltaTime * -Vector3.right);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Obstacles"))
        {
            score--;
            if (score <= 0)
                scoreText.color = Color.red;
            scoreText.text = score.ToString();
        }

        if (other.CompareTag("Point"))
        {
            score++;

            if (score > 0)
                scoreText.color = Color.green;
            scoreText.text = score.ToString();
        }
    }
}
