using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Corn.Movement;
using System;
using UnityEngine.AI;

public class CornAI : MonoBehaviour, IMovement, ILives, IEnemy
{

    public Transform[] kernelsLocation;
    private Kernel[] kernels;
    public BaseAI agent;
    public GameObject ragdoll;
    public Transform player;
    IWeapon currenWeapon;
    GameObject target;
    // private Vector3 moveDirection;

    public float Agression;
    public int fear;


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
            Instantiate(ragdoll, this.transform.position, Quaternion.identity);
            this.gameObject.SetActive(false);
        }
        else if (fear > (kernels.Length - lives))
        {
            GameObject getHealth = PickupManager.instance.GetPickUp(typeof(HealthPickups));
            if (getHealth)
            {
                agent.setGoal(getHealth.transform, EvaluateAction);
                agent.agent.stoppingDistance = 0;
            }
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
        Debug.Log("EVALUATE");
        if (currenWeapon == null)
        {
            GameObject location = PickupManager.instance.GetPickUp(typeof(WeaponPickup));
            agent.setGoal(location.transform, EvaluateAction);
            agent.agent.stoppingDistance = 0;
            return;
        }
        target = EnemyManager.instance.AquireTarget(gameObject);
        agent.setGoal(target.transform, Attack);


    }

    public void Attack ()
    {
        currenWeapon.Shoot(target.transform.position);
        if (target.GetComponent<ILives>().lives > 0)
        {
            //if (!currenWeapon.Shoot(target.transform.position))
            //{

            //}
            //if()
            Attack();
        }
        else
        {
            GameObject location = PickupManager.instance.GetPickUp(typeof(WeaponPickup));
            agent.setGoal(location.transform, EvaluateAction);
            agent.agent.stoppingDistance = 0;
            return;
        }
    }
    IEnumerator waitCooldown ()
    {
        yield return new WaitForSeconds(1);
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
        if (currenWeapon == null)
        {
            Transform location = PickupManager.instance.GetPickUp(typeof(WeaponPickup)).transform;
            agent.setGoal(location, EvaluateAction);
            agent.agent.stoppingDistance = 0;
        }
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
