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
    IWeapon currenWeapon = null;
    GameObject target;
    public GameObject weaponInRightHand;
    public Transform rightHand;
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

    public float Range {
        get {
            throw new NotImplementedException();
        }
    }

    public void Die ()
    {
        if (lives <= 0)
        {
            Instantiate(ragdoll, this.transform.position, Quaternion.identity);
            this.gameObject.SetActive(false);
        }
        else if (fear < (kernels.Length - lives))
        {
            Debug.Log(PickupManager.instance);
            if (PickupManager.instance)
            {
                GameObject getHealth = PickupManager.instance.GetPickUp(typeof(HealthPickups));
                if (getHealth)
                {
                    agent.setGoal(getHealth.transform, EvaluateAction);
                    agent.agent.stoppingDistance = 0;
                    Debug.Log("Need Healing");
                }
            }
        }
    }
    //public void SetWeapon (GameObject weapon_)
    //{

    //}

    public void Heal (int amount)
    {
        for (int i = 0; i < kernels.Length; i++)
        {
            if (!kernels[i].available)
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
            Debug.Log("get weapon");

            GameObject location = PickupManager.instance.GetPickUp(typeof(WeaponPickup));
            Debug.Log(location);
            if (location)
            {
                agent.setGoal(location.transform, EvaluateAction);
                agent.agent.stoppingDistance = 0;
                return;
            }
        }
        Debug.Log("Kill target");

        target = EnemyManager.instance.AquireTarget(gameObject);
        agent.setGoal(target.transform, Attack);
        agent.agent.stoppingDistance = currenWeapon.Range;
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
            Debug.Log("get weapon");

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


        agent = GetComponent<BaseAI>();
    }
    void Start ()
    {
        lives = kernelsLocation.Length;
        Debug.Log("start");

        if (currenWeapon == null)
        {
            Debug.Log(PickupManager.instance);
            GameObject location = PickupManager.instance.GetPickUp(typeof(WeaponPickup));
            if (location)
            {
                agent.setGoal(location.transform, EvaluateAction);
                agent.agent.stoppingDistance = 0;
                Debug.Log("get weapon");
            }
            else
            {
                EvaluateAction();
            }

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

    public bool Shoot (Vector3 target)
    {
        throw new NotImplementedException();
    }

    public void Reload ()
    {
        throw new NotImplementedException();
    }

    public void SetLocation (Transform parent)
    {
        throw new NotImplementedException();
    }
    public IWeapon SetWeapon (GameObject go)
    {
        if (weaponInRightHand != null)
        {
            Destroy(weaponInRightHand);
        }
        weaponInRightHand = Instantiate(go);
        currenWeapon = weaponInRightHand.GetComponent<IWeapon>();
        currenWeapon.SetLocation(rightHand);
        print(currenWeapon);
        EvaluateAction();
        return currenWeapon;
    }

    public ILives getLife ()
    {
        return this;
    }
}
