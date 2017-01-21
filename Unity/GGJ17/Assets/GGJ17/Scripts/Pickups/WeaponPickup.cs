using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Corn.Movement;

public class WeaponPickup : Pickup {

    public GameObject weaponPrefab;

    public override void PickUp(PlayerController pc)
    {
        base.PickUp(pc);
        pc.SetWeapon(weaponPrefab);
    }
}
