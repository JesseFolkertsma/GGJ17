using UnityEngine;
using Corn.Controller;

namespace Corn.Components
{
    public interface IWeapon
    {
        bool Shoot (Vector3 target);
        void Reload ();
        void SetLocation (Transform parent);
        float Range { get; }
        float CoolDownTime { get; }
        //void SetWeapon (GameObject go, IMovement mov);
        //ILives GetLife ();

    }
}