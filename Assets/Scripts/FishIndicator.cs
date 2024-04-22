using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class FishIndicator : MonoBehaviour
{
    Rigidbody rigidbody;
    [SerializeField] float speed = 1.0f;
    [SerializeField] float speedChangeInterval;
    [SerializeField] float speedChangeTimer;

    [SerializeField] Transform waypointLeft;
    [SerializeField] Transform waypointRight;

    [SerializeField] Fish fish;


    public void RandomizeSpeed()
    {
      speed = Random.Range(-1.5f, 1.5f);
    }

    public void RandomizeSpeedChangeInterval()
    {
        speedChangeInterval = Random.Range(2f, 4f);
    }

    public void MoveRandomly()
    { 
        speedChangeTimer += Time.deltaTime;

        if (speedChangeTimer < speedChangeInterval)
        {
            rigidbody.MovePosition(transform.position + transform.forward*speed*Time.fixedDeltaTime);
        }
        else 
        {
            speedChangeTimer = 0f;            
            RandomizeSpeedChangeInterval();
            RandomizeSpeed();

        }

        if (Vector3.Distance(transform.position, waypointLeft.position) < 0.1f)
        {
            speed = Random.Range(-1.5f, -0.5f);
        }
        if (Vector3.Distance(transform.position, waypointRight.position) < 0.1f)
        {
            speed = Random.Range(0.5f, 1.5f);
        }

    }

    private void Start()
    {
        RandomizeSpeed();
        RandomizeSpeedChangeInterval();
        rigidbody = GetComponent<Rigidbody>();
    }
    private void FixedUpdate()
    {
     
            MoveRandomly();
        
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log($"Colliders colliding!");     //the debug is debugging
        fish.isReelable = true;                 //but the bool not updating
    }
    private void OnTriggerExit(Collider other)
    {
        fish.isReelable = false;
    }
}
