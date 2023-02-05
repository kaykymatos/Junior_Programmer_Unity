using System.Collections;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 5.0f;
    private Rigidbody playerRb;
    public GameObject focalPoint;
    public bool hasPowerup;
    public GameObject powerUpIndicator;
    public GameObject gameOver;
    public GameObject spanw;
    SpawnManager spanwScript;
    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        focalPoint = GameObject.Find("Focal Point");
        spanwScript = spanw.GetComponent<SpawnManager>();
    }

    public void ResetScene()
    {
        Time.timeScale = 1;
        spanwScript.waveNumber = 0;
        spanwScript.enemyCount = 0;
        GameObject enemy = GameObject.FindGameObjectWithTag("Enemy");
        GameObject powerUp = GameObject.FindGameObjectWithTag("PowerUp");
        if (enemy != null)
            Destroy(enemy.gameObject);

        if (powerUp != null)
            Destroy(powerUp.gameObject);
        playerRb.AddForce(transform.position - transform.position * 1.3f, ForceMode.Impulse);
        gameOver.gameObject.SetActive(false);
        transform.position = new Vector3(0, 0, 0);
    }
    void Update()
    {
        if (transform.position.y <= -16)
        {
            Time.timeScale = 0;
            gameOver.gameObject.SetActive(true);
        }

        float forwardInput = Input.GetAxis("Vertical");
        powerUpIndicator.transform.position = transform.position - new Vector3(0, 0.5f, 0);
        playerRb.AddForce(forwardInput * speed * focalPoint.transform.forward);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("PowerUp"))
        {
            hasPowerup = true;
            Destroy(other.gameObject);
            powerUpIndicator.gameObject.SetActive(true);
            StartCoroutine(PowerupCountdownRoutine());
        }

    }
    IEnumerator PowerupCountdownRoutine()
    {
        yield return new WaitForSeconds(7);
        hasPowerup = false;
        powerUpIndicator.gameObject.SetActive(false);
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy") && hasPowerup)
        {
            Rigidbody enemyRigidBody = collision.gameObject.GetComponent<Rigidbody>();
            Vector3 awayFromPlayer = collision.gameObject.transform.position - transform.position;
            enemyRigidBody.AddForce(awayFromPlayer * 10, ForceMode.Impulse);
            Debug.Log("Collider with" + collision.gameObject.name + "with powerup:" + hasPowerup);
        }
    }
}
