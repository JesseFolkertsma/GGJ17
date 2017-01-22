using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace Corn.Movement
{
    [RequireComponent(typeof(Rigidbody))]
    public class PlayerController : MonoBehaviour, IPickup, ILives
    {
        #region private fields
        private Rigidbody rb;
        private Animator anim;
        private int health = 5;
        float xRotationInput;
        float yRotationInput;
        float vertical;
        float horizontal;
        IWeapon currenWeapon;
        [SerializeField]
        Transform rightHand;
        [SerializeField]
        GameObject ragdoll;
        GameObject weaponInRightHand;
        bool isDead_ = false;
        private int respawnsleft_ = 5;
        #endregion

        #region public fields
        public LayerMask mask;
        public float walkSpeed;
        public float runSpeed;
        public float rotationSpeed;
        public bool grounded;
        public CameraController cam;

        public Transform[] kernelsLocation;
        private Kernel[] kernels;

        #endregion



        #region start
        // Use this for initialization
        void Awake ()
        {
            rb = this.GetComponent<Rigidbody>();
            anim = this.GetComponent<Animator>();
            PlaceKernals();
        }
        #endregion

        #region Update

        // Update is called once per frame
        void Update ()
        {
            grounded = Physics.Raycast(transform.position, -transform.up, .1f, mask);
            //MovementInput
            horizontal = Input.GetAxis("Horizontal");
            vertical = Input.GetAxis("Vertical");

            yRotationInput = Input.GetAxis("Mouse Y")  * rotationSpeed;
            xRotationInput = Input.GetAxis("Mouse X")  * rotationSpeed;

            //Weapon
            if(currenWeapon != null)
            {
                if (Input.GetButton("Left Mouse"))
                {
                    if (currenWeapon.Shoot(cam.GetTarget()))
                    {
                        anim.SetTrigger("Shoot");
                    }
                }
            }

            //Anim
            SetupAnim(vertical);
        }
        void FixedUpdate ()
        {
            if (xRotationInput != 0 || yRotationInput != 0)
            {
                Rotate(xRotationInput * Time.fixedDeltaTime, yRotationInput * Time.fixedDeltaTime);
            }
            Vector2 direction = new Vector2(horizontal, vertical);

            if (direction != Vector2.zero && grounded)
            {
                Move(direction);
            }
        }
        #endregion

        #region public methods
        void SetupAnim(float mov)
        {
            anim.SetFloat("Movement", mov);
        }

        public void Move (Vector2 dir_)
        {
            Vector3 moveDirection = new Vector3(dir_.x, 0, dir_.y);
            moveDirection = transform.TransformDirection(moveDirection);
            rb.velocity = moveDirection * (Run() ? runSpeed : walkSpeed);
        }

        public void Rotate (float xRot_ , float yRot_)
        {
            //Debug.Log(yRot_);
            Vector3 wantedYRot = new Vector3(0, yRot_, 0);
            rb.MoveRotation(rb.rotation * Quaternion.Euler(wantedYRot));
            Vector3 wantedXRot = new Vector3(xRot_, 0, 0);
            cam.Rotate(-wantedXRot * Time.deltaTime * rotationSpeed);
        }

        public bool Run ()
        {
            return Input.GetAxis("Sprint") == 1 ? true : false;
        }

        public int lives {
            get {
                return health;
            }

            set
            {
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
            if (!isDead)
            {
                if (health < 1)
                {
                    if (ragdoll != null)
                    {
                        Instantiate(ragdoll, transform.position, transform.rotation);
                        Destroy(gameObject);
                        isDead = true;
                        Debug.Log("Die");
                    }
                    else
                    {
                        Debug.LogWarning("Cant die because ragdoll is not setup!");
                    }
                }
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
            return currenWeapon;
        }
        public ILives getLife ()
        {
            return this;
        }
        #endregion

        #region private methods
        private void PlaceKernals ()
        {
            kernels = new Kernel[kernelsLocation.Length];
            for (int i = 0; i < kernelsLocation.Length; i++)
            {
                Kernel sock = kernelsLocation[i].gameObject.AddComponent<Kernel>();
                kernels[i] = sock;
                kernels[i].ParentLife = this;
                sock.Heal(0);
            }
            print(kernelsLocation.Length);
            lives = kernelsLocation.Length;
        }

        public void Respawn (Transform loc)
        {
           if(respawnsleft_ > 1)
            {
                respawnsLeft--;
                transform.position = loc.position;
                gameObject.SetActive(true);
                isDead = false;
                Heal(400);    
            }
            else
            {
                GameManager.instance.LoadDefeatScreen();
            }
        }
        #endregion
    }
}