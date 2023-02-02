using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    float speed = 20f;
    float turnSpeed = 45f;
    float horizontalInput;
    float verticalInput;
    public Transform gameOver;
    public Text buttonText;


    void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");
        transform.Translate(verticalInput * speed * Time.deltaTime * Vector3.forward);
        transform.Rotate(horizontalInput * turnSpeed * Time.deltaTime * Vector3.up);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("GameOverFloor"))
        {
            gameOver.gameObject.SetActive(true);
            buttonText.text = "Restart";
            Pause();
        }
    }
    public void Pause()
    {
        Time.timeScale = 0;
    }

}
