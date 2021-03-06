﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Corn.Components;

namespace Corn.Pickup
{
    public class WeaponPickup : Pickup
    {

        public GameObject weaponPrefab;

        public override void PickUp (IPickup pc)
        {
            base.PickUp(pc);
            pc.SetWeapon(weaponPrefab);
        }
    }
}