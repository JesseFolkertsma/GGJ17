using UnityEngine;
using System.Collections.Generic;
using System;

namespace Corn.Pool
{
    public class PoolManager : MonoBehaviour {

        public List<BasePool> PoolList = new List<BasePool>();

        static PoolManager instance = null;
        public static PoolManager Instance
        {
            get {
                return instance;
            }
            set {
                instance = value;
            }
        }

        protected void Awake () {
            if (Instance == null) {
                Instance = this;
            }
            else if (Instance != this) {
                Destroy(this.gameObject);
                Debug.LogError("there where multiple instances off poolmanager in this scene");
            }
        }

        public BasePool GetPool (string name_) {
            for (int i = 0; i < PoolList.Count; i++) {
                if (PoolList[i].PoolName == name_) {
                    return PoolList[i];
                }
            }
            throw new NullReferenceException(name_ +  " not in list");
        }
    }
}