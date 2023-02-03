using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed = 5.0f;
    private Rigidbody enemyRb;
    public GameObject player;
    public GameObject focalPoint;
    // Start is called before the first frame update
    void Start()
    {
        enemyRb = GetComponent<Rigidbody>();
        player = GameObject.Find("Player");

    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y <= -16)
            Destroy(gameObject);

        Vector3 lookDirection = (player.transform.position - transform.position).normalized;
        enemyRb.AddForce(lookDirection * speed);
    }
}
