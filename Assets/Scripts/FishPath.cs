using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishPath : MonoBehaviour
{
    [SerializeField] List<Transform> waypoints;

    private void Awake()
    {
        // initialize the list
        waypoints = new List<Transform>();

        foreach (Transform waypoint in transform)
        {
            // add the new waypoints to the list one by one 
            waypoints.Add(waypoint);
        }
    }

    public Transform GetWaypoint(int incomingIndex)
    {
        return waypoints[incomingIndex];
    }

    public int GetNumberOfWaypoints()
    {
        return waypoints.Count;
    }
}
