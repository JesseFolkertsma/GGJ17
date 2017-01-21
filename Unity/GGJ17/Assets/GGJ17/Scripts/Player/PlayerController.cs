﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace Corn.Movement
{
    [RequireComponent(typeof(Rigidbody))]
    public class PlayerController : MonoBehaviour, IMovement, ILives
    {
        #region private fields
        private Rigidbody rb;
        private int health;
        float xRotationInput;
        float yRotationInput;
        IWeapon currenWeapon;
        [SerializeField]
        Transform rightHand;
        GameObject weaponInRightHand;
        #endregion

        #region Weapons
        public GameObject hairDryer;
        public GameObject microWave;
        #endregion

        #region public fields
        public float walkSpeed;
        public float runSpeed;
        public float rotationSpeed;

        public CameraController cam;

        public Transform[] kernalsLocation;

        #endregion



        #region start
        // Use this for initialization
        void Start ()
        {
            rb = this.GetComponent<Rigidbody>();
            PlaceKernals();
        }
        #endregion

        #region Update

        // Update is called once per frame
        void Update ()
        {
            float horizontal = Input.GetAxis("Horizontal");
            float vertical = Input.GetAxis("Vertical");

            Vector2 direction = new Vector2(horizontal, vertical);

            if (direction != Vector2.zero)
            {
                Move(direction);
            }

            yRotationInput = Input.GetAxis("Mouse Y")  * rotationSpeed;
            xRotationInput = Input.GetAxis("Mouse X")  * rotationSpeed;

            //Weapon
            if(currenWeapon != null)
            {
                if (Input.GetButtonDown("Left Mouse"))
                {
                    print("Shoot!");
                    currenWeapon.Shoot(cam.GetTarget());
                }
            }
        }
        void FixedUpdate ()
        {
            if (xRotationInput != 0 || yRotationInput != 0)
            {
                Rotate(xRotationInput * Time.fixedDeltaTime, yRotationInput * Time.fixedDeltaTime);
            }
        }
        #endregion

        #region public methods
        public void Melee ()
        {

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
            Vector3 wantedRot = new Vector3(0, yRot_, 0);
            rb.MoveRotation(rb.rotation * Quaternion.Euler(wantedRot));
            
        }

        public bool Run ()
        {
            return Input.GetAxis("Sprint") == 1 ? true : false;
        }

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
            lives += 100;
        }
        public void SetWeapon (GameObject weapon_)
        {
            weaponInRightHand = Instantiate(weapon_);
            currenWeapon = weaponInRightHand.GetComponent<IWeapon>();
            currenWeapon.SetLocation(rightHand);
            print(currenWeapon);
        }
        #endregion
        #region private methods
        private void PlaceKernals ()
        {
            for (int i = 0; i < kernalsLocation.Length; i++)
            {
                Kernel sock = kernalsLocation[i].gameObject.AddComponent<Kernel>();
                sock.Heal(0);
            }
        }
        #endregion
    }
}