using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chicken : MonoBehaviour {

    public List<Transform> waypoints;
    public Transform waypoint;
    public int currentWP = 0;
    public float speed = 5;

    void Update()
    {
        FollowWaypoints();
        waypoint = waypoints[0];
    }

    void FollowWaypoints()
    {
        if(waypoints.Count > 0)
        {
            transform.LookAt(waypoint);
            transform.Translate(transform.forward * speed * Time.deltaTime);
        }
    }

    void NextWP()
    {
        currentWP++;
        if(currentWP > waypoints.Count)
        {
            currentWP = 0;
        }
    }

    void OnCollisionEnter(Collision col)
    {
        if (col.collider.tag == "Waypoint")
        {
            NextWP();
        }
    }
}
