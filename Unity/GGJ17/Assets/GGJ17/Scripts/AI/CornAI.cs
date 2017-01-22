using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Corn.Movement;
using System;
using UnityEngine.AI;

public class CornAI : MonoBehaviour, IPickup, ILives
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
    public void Die ()
    {
        if (lives <= 0)
        {
            Instantiate(ragdoll, this.transform.position, Quaternion.identity);
            this.gameObject.SetActive(false);
        }
        else if (fear < (kernels.Length - lives))
        {
            GetHealth();
        }
    }

    public void Heal (int amount)
    {
        Debug.Log("Heals");
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

    public void EvaluateAction ()
    {
        Debug.Log("EVALUATE");
        if (currenWeapon == null)
        {
            GetWeapon();
        }
        else
        {
            SetAttackmode();
        }
    }

    public void Attack ()
    {
        currenWeapon.Shoot(target.transform.position);
        if (target.GetComponent<ILives>().lives > 0)
        {
            StartCoroutine(waitCooldown(currenWeapon.CoolDownTime));
        }
        else
        {
            GetWeapon();
        }
    }
    IEnumerator waitCooldown (float amount)
    {
        yield return new WaitForSeconds(amount);
        Attack();
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
        GetWeapon();
    }
    public bool GetWeapon ()
    {
        Debug.Log("getweapon");
        GameObject location = PickupManager.instance.GetPickUp(typeof(WeaponPickup), gameObject);
        if (location)
        {
            agent.setGoal(location.transform, EvaluateAction);
            agent.agent.stoppingDistance = 0;
            return true;
        }
        return false;
    }
    public bool GetHealth ()
    {
        Debug.Log("gethealth");
        if (PickupManager.instance)
        {
            GameObject getHealth = PickupManager.instance.GetPickUp(typeof(HealthPickups), gameObject);
            if (getHealth)
            {
                agent.setGoal(getHealth.transform, EvaluateAction);
                agent.agent.stoppingDistance = 0;
                return true;
            }
        }
        return false;

    }
    public void SetAttackmode ()
    {
        Debug.Log("attackmode");
        target = EnemyManager.instance.AquireTarget(gameObject);
        agent.setGoal(target.transform, Attack);
        agent.agent.stoppingDistance = currenWeapon.Range;
    }

    public IWeapon SetWeapon (GameObject go)
    {
        try
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
        }
        catch (Exception e)
        {
            Debug.Log(e);
        }

        return currenWeapon;
    }

    public ILives getLife ()
    {
        return this;
    }
}
