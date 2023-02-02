using UnityEngine;

public class PlayerController : MonoBehaviour
{

    float speed = 20f;
    float maxRangeX = 10;
    public GameObject projectilePrefab;

    private void Start()
    {

    }
    void Update()
    {
        if (transform.position.x < -maxRangeX)
            transform.position = new Vector3(-maxRangeX, transform.position.y, transform.position.z);

        if (transform.position.x > maxRangeX)
            transform.position = new Vector3(maxRangeX, transform.position.y, transform.position.z);

        float horizontalInput = Input.GetAxis("Horizontal");

        transform.Translate(horizontalInput * speed * Vector2.right * Time.deltaTime);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Instantiate(projectilePrefab, transform.position, projectilePrefab.transform.rotation);
        }
    }
}
