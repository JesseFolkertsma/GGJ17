using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Corn.Movement;

public class WeaponPickup : Pickup {
    
    public enum Weapon
    {
        HairDryer,
        Microwave
    };

    public Weapon weapon;

    public override void PickUp(PlayerController pc)
    {
        base.PickUp(pc);
        IWeapon newWeapon;
        switch (weapon)
        {
            case Weapon.HairDryer:
                newWeapon = new HairDryer();
                break;
            case Weapon.Microwave:
                newWeapon = new Microwave();
                break;
            default:
                Debug.LogError("Pickup error: WeaponType not found!");
                newWeapon = null;
                break;
        }
        pc.SetWeapon(newWeapon);
    }
}
