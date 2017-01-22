using UnityEngine;
using Corn.Components;

namespace Corn.Pickup
{
    public class Pickup : MonoBehaviour
    {

        public PickupSpawner attachedSpawner;

        public virtual void PickUp (IPickup pc)
        {
            Destroy(gameObject);
            if (attachedSpawner != null)
                attachedSpawner.PickedUpPickup();
        }

        void OnTriggerEnter (Collider col)
        {
            if (col.tag == "Player")
            {
                PickUp(col.GetComponent<IPickup>());
            }
        }
    }
}