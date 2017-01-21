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
    //public Transform goal;
    public BaseAI agent;
    private Rigidbody rb;

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
        throw new NotImplementedException();
    }

    public void Move (Vector2 dir_)
    {
        throw new NotImplementedException();
    }

    public void Rotate (float x, float y)
    {
        throw new NotImplementedException();
    }

    public bool Run ()
    {
        throw new NotImplementedException();
    }

    // Use this for initialization
    void Start ()
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

        transform.position = agent.gameObject.transform.position;

        rb = this.GetComponent<Rigidbody>();
        //agent = GetComponent<NavMeshAgent>();
        //agent.destination = goal.position;
    }

    void FixedUpdate ()
    {

        Vector3 moveDirection = (transform.position - agent.gameObject.transform.position).normalized;

        moveDirection = transform.TransformDirection(moveDirection);
        rb.velocity = moveDirection * 5;
        //GoTo(goal);
    }
    public void GoTo (Transform trans_)
    {

    }

    public void EvaluateAction ()
    {
        throw new NotImplementedException();
    }

    public void Attack ()
    {
        throw new NotImplementedException();
    }
}
