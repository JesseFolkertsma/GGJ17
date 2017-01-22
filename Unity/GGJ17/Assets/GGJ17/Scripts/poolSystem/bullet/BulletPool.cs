using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Corn.Pool
{
    public class BulletPool : BasePool
    {

        public bool dontDestroyOnLoad = false;
        private static BulletPool instance = null;
        public static BulletPool Instance {
            get {
                return instance;
            }
            set {
                instance = value;
            }
        }

        void Awake ()
        {
            if (Instance == null)
            {
                Instance = this;
                if (dontDestroyOnLoad)
                    DontDestroyOnLoad(this);
            }
            else if (Instance != this)
            {
                Destroy(this.gameObject);
            }

        }
    }
}