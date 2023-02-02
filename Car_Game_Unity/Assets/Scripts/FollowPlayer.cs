using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    public GameObject player;
    Vector3 offset = new(0, 5, -7);
    void LateUpdate()
    {
        transform.position = player.transform.position + offset;
    }
}
