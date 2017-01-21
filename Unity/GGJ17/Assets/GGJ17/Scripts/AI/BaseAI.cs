using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class BaseAI : MonoBehaviour {

    public NavMeshAgent agent;
    public Transform goal;

    void Start ()
    {
        agent = this.GetComponent<NavMeshAgent>();
        agent.destination = goal.position;

    }
    void Update ()
    {
        if (goal != null)
        {
            agent.destination = goal.position;
        }
    }
}
