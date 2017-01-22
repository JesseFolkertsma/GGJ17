using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Corn.Movement
{
    public interface IPickup
    {
        IWeapon SetWeapon (GameObject go);
        ILives getLife ();
    }
}