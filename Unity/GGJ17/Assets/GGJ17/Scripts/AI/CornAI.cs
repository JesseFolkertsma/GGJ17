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
    bool isDead_ = false;
    private int respawnsleft_ = 5;
    public EnemyManager manager;
    public AudioClip popcornClip;
    public AudioClip[] deadClip;

    // private Vector3 moveDirection;

    //public float Agression;
    public int fear;
    private int health;

    public int lives {
        get {
            return health;
        }
        set {
            health = value;
        }
    }

    public bool isDead {
        get {
            return isDead_;
        }

        set {
            isDead_ = value;
        }
    }

    public int respawnsLeft {
        get {
            return respawnsleft_;
        }

        set {
            respawnsleft_ = value;
        }
    }

    public void Die ()
    {
        if (lives <= 0)
        {
            Instantiate(ragdoll, this.transform.position, Quaternion.identity);
            this.gameObject.SetActive(false);
            isDead = true;
            SoundPool.Instance.PlayAudio(deadClip[UnityEngine.Random.Range(0, deadClip.Length)]);
            SpawnManger.instance.Respawn(this);
            //StartCoroutine(WaitAndRespawn());

        }
        else if (fear > (kernels.Length - lives))
        {
            if (!gettingHealth)
            {
                if (!GetHealth())
                {
                    if (currenWeapon != null)
                        SetAttackmode();
                    else
                        GetWeapon();
                }
            }
        }
        else
        {
            if (currenWeapon != null)
                SetAttackmode();
            else
                GetWeapon();
        }
    }

    public void Heal (int amount)
    {
        for (int i = 0; i < kernels.Length; i++)
        {
            if (!kernels[i].isDead)
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
        if (target != null)
        {
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
            kernels[i].clip = popcornClip;
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
        target = manager.AquireTarget(gameObject);
        if (target)
        {
            agent.setGoal(target.transform, Attack);
            agent.agent.stoppingDistance = currenWeapon.Range;
        }
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

    public void Respawn (Transform loc)
    {
        if (respawnsleft_ > 1)
        {
            respawnsLeft--;
            //getspawnlocation
            //Transform location = SpawnManger.instance.GetSpawnLocation();
            transform.position = loc.position;
            gameObject.SetActive(true);
            isDead = false;
            Heal(400);
            Debug.Log("respawn");

        }
        else
        {
            manager.GetPlayerVictory();
        }
    }
}
