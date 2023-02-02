using UnityEngine;

public class FollowPlayerX : MonoBehaviour
{
    public GameObject plane;
    private Vector3 offset = new(23.97f, 1.05f, 3.61f);

    void LateUpdate()
    {
        transform.position = plane.transform.position + offset;
    }
}
