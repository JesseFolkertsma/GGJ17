using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Corn.Movement
{
    public interface IMovement
    {
        void Move (Vector2 dir_);

        void Rotate (float x, float y);

        void Run (bool run_);

        void Melee ();
    }
}