using UnityEngine;

public class Target : MonoBehaviour
{
    private Rigidbody targetRg;
    private readonly float minSpeed = 12;
    private readonly float maxSpeed = 16;
    private readonly float torque = 100;
    private readonly float xRange = 4;
    private readonly float ySpawnPos = -6;
    private GameManager gameManager;
    public int pointValue;
    public ParticleSystem explosionParticle;
    // Start is called before the first frame update
    void Start()
    {
        targetRg = GetComponent<Rigidbody>();
        targetRg.AddForce(RandomForce(), ForceMode.Impulse);
        targetRg.AddTorque(RandomTorque(), RandomTorque(), RandomTorque(), ForceMode.Impulse);
        transform.position = RandonSpawnPos();
        gameManager = GameObject.FindGameObjectWithTag("Game Manager")
            .GetComponent<GameManager>();
    }
    private void OnMouseDown()
    {
        if (gameManager.isGameActive)
        {
            Destroy(gameObject);
            Instantiate(explosionParticle,
                transform.position,
                explosionParticle.transform.rotation);
            gameManager.UpdateScore(pointValue);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (!gameObject.CompareTag("Bad"))
            gameManager.GameOver();

        Destroy(gameObject);

    }
    Vector3 RandomForce()
    {
        return Vector3.up * Random.Range(minSpeed, maxSpeed);
    }
    float RandomTorque()
    {
        return Random.Range(-torque * Time.deltaTime, torque * Time.deltaTime);
    }
    Vector3 RandonSpawnPos()
    {
        return new Vector3(Random.Range(-xRange, xRange), ySpawnPos); ;
    }
}
