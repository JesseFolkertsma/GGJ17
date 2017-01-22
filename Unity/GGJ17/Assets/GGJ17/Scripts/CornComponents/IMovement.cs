using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Corn.Movement
{
    public interface IMovement
    {
        void Move (Vector2 dir_);

        void Rotate (float x, float y);

        void Melee ();

        bool Run();

        IWeapon SetWeapon (GameObject go);
        ILives getLife ();

    }
}