using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColliderController : MonoBehaviour
{
    private float speed = 1f;
    private float inputSpeed = 3f;
    [SerializeField] Transform waypoint;
    [SerializeField] Transform waypointLeft;
    [SerializeField] Transform waypointRight;

    private void Update()
    {

        if (Input.GetKey(KeyCode.A))
        {
            transform.position = Vector3.MoveTowards(transform.position, waypointLeft.position, inputSpeed * Time.deltaTime);
        }

        else if (Input.GetKey(KeyCode.D))
        {
            transform.position = Vector3.MoveTowards(transform.position, waypointRight.position, inputSpeed * Time.deltaTime);
        }

        else
        {
            transform.position = Vector3.MoveTowards(transform.position, waypoint.position, speed * Time.deltaTime);

        }
    }
}
