using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace Corn.Movement
{
    [RequireComponent(typeof(Rigidbody))]
    public class PlayerController : MonoBehaviour, IMovement
    {
        #region private fields
        private Rigidbody rb;
        #endregion

        #region public fields
        public float movementSpeed;
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
        void Update ()
        {
            float horizontal = Input.GetAxis("Horizontal");
            float vertical = Input.GetAxis("Vertical");

            Vector2 direction = new Vector2(horizontal, vertical);

            if (direction != Vector2.zero)
            {
                Move(direction);
            }


            float xRotationInput = Input.GetAxis("MouseX");
            float yRotationInput = Input.GetAxis("MouseY");


            Rotate(xRotationInput, yRotationInput);

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
                            rb.velocity = moveDirection * movementSpeed;
        }

        public void Rotate (float xRot_ , float yRot_)
        {
            Debug.Log(xRot_);
            Debug.Log(yRot_);

        }

        public void Run (bool run_)
        {

        }
        #endregion

    }
}