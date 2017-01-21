using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public interface IWeapon {
    void Shoot(Vector3 target);
    void Reload();
    GameObject GetProp();
    void SetLocation(Transform parent);
}
