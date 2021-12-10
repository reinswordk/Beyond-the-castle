using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow2 : MonoBehaviour
{
    public float FollowSpeed = 2f;
    public float yoffset = 1f;
    public float xoffset = 1f;
    public Transform target;

    void Update()
    {
        Vector3 newPos = new Vector3(target.position.x + xoffset, target.position.y + yoffset, -10f);
        transform.position = Vector3.Slerp(transform.position, newPos, FollowSpeed * Time.deltaTime);
    }
}
