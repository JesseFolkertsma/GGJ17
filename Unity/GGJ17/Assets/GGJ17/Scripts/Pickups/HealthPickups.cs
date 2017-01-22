using System.Collections;
using System.Collections.Generic;
using Corn.Controller;
using UnityEngine;
using Corn.Components;

namespace Corn.Pickup
{
    public class HealthPickups : Pickup
    {

        public int healAmount;

        public override void PickUp (IPickup pc)
        {
            base.PickUp(pc);
            pc.getLife().Heal(healAmount);
        }
    }
}