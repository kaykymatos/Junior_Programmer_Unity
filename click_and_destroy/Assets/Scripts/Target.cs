using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Target : MonoBehaviour
{
    private Rigidbody targetRg;
    private float minSpeed = 12;
    private float maxSpeed = 16;
    private float torque = 100;
    private float xRange = 4;
    private float ySpawnPos = -6;
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

    // Update is called once per frame
    void Update()
    {

    }
    private void OnMouseDown()
    {
        Destroy(gameObject);
        Instantiate(explosionParticle,
            transform.position,
            explosionParticle.transform.rotation);
        gameManager.UpdateScore(pointValue);
    }
    private void OnTriggerEnter(Collider other)
    {
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
