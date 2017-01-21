﻿using System.Collections;
using System.Collections.Generic;
using Corn.Movement;
using UnityEngine;

public class HealthPickups : Pickup {

    public int healAmount;

    public override void PickUp(PlayerController pc)
    {
        base.PickUp(pc);
        pc.Heal(healAmount);
    }
}
