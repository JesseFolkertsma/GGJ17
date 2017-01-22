using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Corn.Movement;

public interface IWeapon {
    bool Shoot(Vector3 target);
    void Reload();
    void SetLocation(Transform parent);
    float Range { get; }
    float CoolDownTime { get; }
    //void SetWeapon (GameObject go, IMovement mov);
    //ILives GetLife ();

}
