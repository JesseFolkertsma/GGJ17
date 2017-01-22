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
        Debug.Log("SETTING GOAL");

        goal = loc;
        onComplete = callback;
    }

    void Update ()
    {
        if (goal != null)
        {
            agent.destination = goal.position;
        }
        float dist = agent.remainingDistance;
        if (dist != Mathf.Infinity && agent.pathStatus == NavMeshPathStatus.PathComplete && dist <= agent.stoppingDistance)
        {
            if(onComplete != null)
            {
                Debug.Log("complete "+ dist);
                onComplete.Invoke();
                onComplete = null;
            }
        }
    }
}
