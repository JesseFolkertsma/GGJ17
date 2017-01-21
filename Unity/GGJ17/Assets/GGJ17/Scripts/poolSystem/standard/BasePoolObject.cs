using UnityEngine;
using UnityEngine.Events;

using System.Collections;

namespace CommonAssets.Pool
{
    public class BasePoolObject : MonoBehaviour
    {
        public bool Available = true;
        protected UnityEvent onEnable;

        public virtual void SetEnable () {
            if (onEnable != null)
                onEnable.Invoke();

            Available = false;
            gameObject.SetActive(true);
        }
        //make your object call this.
        public virtual void SetDisable () {
            Available = true;
            gameObject.SetActive(false);
        }
    }
}