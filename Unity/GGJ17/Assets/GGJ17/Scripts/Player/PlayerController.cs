using System.Collections;
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
        #endregion

        #region public fields
        public float walkSpeed;
        public float runSpeed;
        public float rotationSpeed;

        public Transform[] kernalsLocation;

        #endregion



        #region start
        // Use this for initialization
        void Start ()
        {
            rb = this.GetComponent<Rigidbody>();


        }
        #endregion

        #region Update

        // Update is called once per frame
        void FixedUpdate ()
        {
            float horizontal = Input.GetAxis("Horizontal");
            float vertical = Input.GetAxis("Vertical");

            Vector2 direction = new Vector2(horizontal, vertical);

            if (direction != Vector2.zero)
            {
                Move(direction);
            }

            float yRotationInput = Input.GetAxisRaw("Mouse Y") * Time.fixedDeltaTime * rotationSpeed;
            float xRotationInput = Input.GetAxisRaw("Mouse X") * Time.fixedDeltaTime * rotationSpeed;

            if(xRotationInput != 0 || yRotationInput != 0)
            {
                Rotate(xRotationInput, yRotationInput);
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
            Vector3 wantedRot = new Vector3(0, rb.rotation.y + yRot_, 0);
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
        public void SetWeapon (IWeapon weapon_)
        {

        }
        #endregion
        #region private methods
        private void PlaceKernals ()
        {
            for (int i = 0; i < kernalsLocation.Length; i++)
            {
                Debug.Log(kernalsLocation[i]);
                KernalSocket sock = kernalsLocation[i].gameObject.AddComponent<KernalSocket>();
                sock.available = false;
                sock.location = kernalsLocation[i];
            }
        }
        #endregion
    }
}