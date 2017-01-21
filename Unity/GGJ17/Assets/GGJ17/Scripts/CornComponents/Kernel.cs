using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CommonAssets.Pool;

public class Kernel : MonoBehaviour, ILives
{

    public ILives ParentLife;

    private bool available;

    private int lives_ = 3;

    public static PopcornPool pool;

    public int lives {
        get {
            return lives_;
        }

        set {
            lives_ = value;
            Die();
        }
    }

    public void Die ()
    {
        if (lives <= 0)
        {
            available = false;
            PopcornObject corn = pool.GetPooledObject() as PopcornObject;
        }
    }

    public void Heal (int amount)
    {
        available = true;
        lives = 3;
    }
}
