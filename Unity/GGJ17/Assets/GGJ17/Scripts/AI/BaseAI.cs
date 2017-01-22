using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class BaseAI : MonoBehaviour {

    public NavMeshAgent agent;
    public Transform goal;
    public delegate void OnCompleteAction ();
    OnCompleteAction onComplete;

    void Awake ()
    {
        agent = this.GetComponent<NavMeshAgent>();
        //agent.destination = goal.position;
    }

    public void setGoal (Transform loc, OnCompleteAction callback)
    {
        goal = loc;
        onComplete = callback;
    }

    void Update ()
    {
        if (goal != null)
        {
            agent.destination = goal.position;
        }
        else
        {
            if (onComplete != null)
            {
                onComplete.Invoke();
                onComplete = null;
            }
        }
        float dist = agent.remainingDistance;
        if (dist != Mathf.Infinity && agent.pathStatus == NavMeshPathStatus.PathComplete && dist <= agent.stoppingDistance)
        {
            if(onComplete != null)
            {
                onComplete.Invoke();
                onComplete = null;
            }
        }
    }
}
