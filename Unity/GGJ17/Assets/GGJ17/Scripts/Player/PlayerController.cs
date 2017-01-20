using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace Corn.Movement
{
    public class PlayerController : MonoBehaviour, IMovement
    {

        public void Melee ()
        {

        }

        public void Move (Vector2 dir_)
        {

        }

        public void Rotate (float rot_)
        {

        }

        public void Run (bool run_)
        {

        }


        // Use this for initialization
        void Start ()
        {
            float horizontal = Input.GetAxis("Horizontal");
            float vertical = Input.GetAxis("Vertical");

            Vector2 direction = new Vector2(horizontal, vertical);

            if(direction != Vector2.zero)
            {
                Debug.Log(direction);
         
            }


        }

        // Update is called once per frame
        void Update ()
        {



        }
    }
}