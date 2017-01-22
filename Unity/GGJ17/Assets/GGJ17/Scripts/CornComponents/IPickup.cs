using UnityEngine;

namespace Corn.Components
{
    public interface IPickup
    {
        IWeapon SetWeapon (GameObject go);
        ILives getLife ();
    }

}