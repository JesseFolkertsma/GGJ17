using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace CommonAssets.Pool
{

    public class BasePool : MonoBehaviour {

        public GameObject PoolObject;
        public int PooledAmount;
        public bool WillGrow;
        public string PoolName;
        public Transform PoolParent;

        List<BasePoolObject> objPool = new List<BasePoolObject>();

        public virtual void Start () {
            for (int i = 0; i < PooledAmount; i++) {
                AddPoolObject();
            }
        }
        public virtual BasePoolObject GetPooledObject () {
            for (int i = 0; i < objPool.Count; i++) {
                if (objPool[i].Available)
                    return objPool[i];
            }
            if (WillGrow) {
                return AddPoolObject();
            }
            else {
                return null;
            }
        }

        public virtual BasePoolObject AddPoolObject () {
            GameObject goObj = GameObject.Instantiate(PoolObject);
            BasePoolObject poolObj = goObj.GetComponent<BasePoolObject>();
            goObj.transform.SetParent(PoolParent);
            objPool.Add(poolObj);
            return poolObj;
        }
    }
}