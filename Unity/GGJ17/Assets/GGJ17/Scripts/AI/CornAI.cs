using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Corn.Movement;
using System;
using UnityEngine.AI;

[RequireComponent(typeof(Rigidbody))]
public class CornAI : MonoBehaviour, IMovement, ILives, IEnemy {

    public Transform[] kernelsLocation;
    private Kernel[] kernels;
    public GameObject agentPrefab;
    //public BaseAI agent;
    private Rigidbody rb;
    public Transform player;
    private Vector3 moveDirection;


    private int health;

    public int lives {
        get {
            return health;
        }
        set {
            health = value;
        }
    }

    public void Die ()
    {
        throw new NotImplementedException();
    }

    public void Heal (int amount)
    {
        for (int i = 0; i < kernels.Length; i++)
        {
            if (kernels[i].available)
            {
                kernels[i].Heal(0);
                amount--;
            }
            if (amount == 0)
                break;
        }
    }

    public void Melee ()
    {

    }

    public void Move (Vector2 dir_)
    {
        //moveDirection = (agent.transform.position - transform.position).normalized;
        //moveDirection = new Vector3(moveDirection.x, 0, moveDirection.z);
        //rb.velocity = moveDirection * 5;

    }

    public void Rotate (float x, float y)
    {

        //var localTarget = transform.InverseTransformPoint(agent.transform.position);
        //float angle = Mathf.Atan2(localTarget.x, localTarget.z) * Mathf.Rad2Deg;

        //transform.eulerAngles = new Vector3(0, angle, 0);

        //this.transform.rotation = agent.transform.rotation;

        //float newAngle = Mathf.Atan2(moveDirection.x, moveDirection.z) * Mathf.Rad2Deg;
        //Debug.Log(newAngle);
        //Vector3 wantedYRot = new Vector3(0, 2, 0);
        //rb.MoveRotation(Quaternion.Euler(wantedYRot));
    }

    public bool Run ()
    {
        throw new NotImplementedException();
    }

    public void GoTo (Transform trans_)
    {

    }

    public void EvaluateAction ()
    {

    }

    public void Attack ()
    {

    }

    // Use this for initialization
    void Awake ()
    {
        kernels = new Kernel[kernelsLocation.Length];
        for (int i = 0; i < kernelsLocation.Length; i++)
        {
            Kernel sock = kernelsLocation[i].gameObject.AddComponent<Kernel>();
            kernels[i] = sock;
            kernels[i].ParentLife = this;
            sock.Heal(0);
        }
        lives = kernelsLocation.Length;

        rb = this.GetComponent<Rigidbody>();

        //agent = GameObject.Instantiate(agentPrefab, transform.position, Quaternion.identity).GetComponent<BaseAI>();
        //agent.goal = player.transform;

        //agent = GetComponent<NavMeshAgent>();
        //agent.destination = goal.position;
    }

    void FixedUpdate ()
    {
        //if (agent == null)
        //    return;

        //Move(Vector2.zero);
        //Rotate(0, 0);
        //GoTo(goal);
    }

}
