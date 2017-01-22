﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public interface IWeapon {
    bool Shoot(Vector3 target);
    void Reload();
    void SetLocation(Transform parent);
    float Range { get; }
}
