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
    public LayerMask hitCheck;

    // private Vector3 moveDirection;

    public float Agression;
    public int fear;
    Animator anim;
    
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
        if (lives <= 0)
        {
            Instantiate(ragdoll, this.transform.position, Quaternion.identity);
            this.gameObject.SetActive(false);
        }
        else if (fear > (kernels.Length - lives))
        {
            if (!gettingHealth)
            {
                GetHealth();
            }
        }
        else
        {
            SetAttackmode();
        }
    }

    void Update()
    {
        if(agent.goal != null)
        {
            anim.SetFloat("Movement", 1f);
        }
        else
        {
            anim.SetFloat("Movement", 0f);
        }
    }

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

    public void EvaluateAction ()
    {
        gettingHealth = false;
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
        //raycast check obstacle();


        if (target.GetComponent<ILives>().lives > 0)
        {
            float r = UnityEngine.Random.Range(0, (float) 1.80);
            Vector3 aim = new Vector3(target.transform.position.x, target.transform.position.y + r, target.transform.position.z);
            RaycastHit hit;
            if (Physics.Raycast(transform.position, target.transform.position, out hit, 200f, hitCheck))
            {
                if (hit.transform.gameObject.layer == LayerMask.NameToLayer("Terrain"))
                {
                    GetWeapon();
                }
            }
            currenWeapon.Shoot(aim);
            StartCoroutine(waitCooldown(currenWeapon.CoolDownTime));
        }
        else
        {
            GetWeapon();
        }
    }
    IEnumerator waitCooldown (float amount)
    {
        yield return new WaitForSeconds(amount + 1);
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
        anim = GetComponentInChildren<Animator>();
    }
    public bool GetWeapon ()
    {
        print("getweapon");
        GameObject location = PickupManager.instance.GetPickUp(typeof(WeaponPickup), gameObject);
        if (location)
        {
            agent.setGoal(location.transform, EvaluateAction);
            agent.agent.stoppingDistance = 0.5f;
            return true;
        }
        return false;
    }
    bool gettingHealth;
    public bool GetHealth ()
    {
        if (PickupManager.instance)
        {
            GameObject pickUp = PickupManager.instance.GetPickUp(typeof(HealthPickups), gameObject);
            if (pickUp)
            {
                agent.setGoal(pickUp.transform, EvaluateAction);
                agent.agent.stoppingDistance = 0.5f;
                gettingHealth = true;
                return true;
            }
        }
        return false;

    }
    public void SetAttackmode ()
    {
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
