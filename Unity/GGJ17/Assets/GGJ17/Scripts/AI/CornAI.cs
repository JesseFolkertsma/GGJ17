using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Corn.Movement;
using System;
using UnityEngine.AI;

public class CornAI : MonoBehaviour, IMovement, ILives, IEnemy {

    public Transform[] kernelsLocation;
    private Kernel[] kernels;
    public BaseAI agent;
    public GameObject ragdoll;
    public Transform player;
   // private Vector3 moveDirection;


    private int health;

    public int lives {
        get {
            return health;
        }
        set {
            health = value;
            Die();
        }
    }

    public void Die ()
    {
        if (lives <= 0)
        {
            Instantiate(ragdoll, this.transform.position, transform.rotation);
            this.gameObject.SetActive(false);

        }
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

    public void Rotate (float x, float y)
    {
        throw new NotImplementedException();
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

        agent = GetComponent<BaseAI>();

    }
    void start ()
    {
        GoTo(player);

    }

    public void Move (Vector2 dir_)
    {
        throw new NotImplementedException();
    }

    public void Melee ()
    {
        throw new NotImplementedException();
    }

    public bool Run ()
    {
        throw new NotImplementedException();
    }

    public void GoTo (Transform trans_)
    {
        agent.agent.destination = trans_.position;
    }
}
