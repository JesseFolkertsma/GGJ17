using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CommonAssets.Pool;

public class Kernel : MonoBehaviour, ILives
{
    public ILives ParentLife;

    public AudioClip clip;

    bool available;

    private int lives_ = 3;

    public static PopcornPool pool;

    public int lives {
        get {
            return lives_;
        }

        set {
            lives_ = value;
            if(lives_ <= 0)
            {
                Die();
            }
        }
    }

    public bool isDead {
        get {
            return available;
        }

        set {
            available = value;
        }
    }

    public int respawnsLeft {
        get {
            throw new NotImplementedException();
        }

        set {
            throw new NotImplementedException();
        }
    }

    public void Die ()
    {
        ParentLife.lives--;
        available = false;
        PopcornObject corn = pool.GetPooledObject() as PopcornObject;
        ParentLife.Die();
        corn.pop(this.transform);
        corn.SetEnable();
        //SoundPool.Instance.PlayAudio(clip);
        this.gameObject.SetActive(false);

    }

    public void Heal (int amount)
    {
        available = true;
        lives = 3;
        this.gameObject.SetActive(true);
        ParentLife.lives++;
    }

    public void Respawn (Transform lol)
    {
        throw new NotImplementedException();
    }
}
