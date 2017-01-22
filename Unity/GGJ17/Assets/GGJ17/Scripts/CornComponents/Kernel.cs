using System;
using UnityEngine;
using Corn.Pool;

namespace Corn.Components
{
    public class Kernel : MonoBehaviour, ILives
    {
        public ILives ParentLife;

        public AudioClip[] clip;

        bool isDead_;

        private int lives_ = 3;

        public static PopcornPool pool;

        public int lives {
            get {
                return lives_;
            }

            set {
                lives_ = value;
                if (lives_ <= 0)
                {
                    Die();
                }
            }
        }

        public bool isDead {
            get {
                return isDead_;
            }

            set {
                isDead_ = value;
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

        public Kernel[] GetKernals {
            get {
                throw new NotImplementedException();
            }
        }

        public void Die ()
        {
            ParentLife.lives--;
            isDead = true;
            PopcornObject corn = pool.GetPooledObject() as PopcornObject;
            ParentLife.Die();
            corn.pop(this.transform);
            corn.SetEnable();
            int rng = UnityEngine.Random.Range(0, clip.Length - 1);
            SoundObject obj = SoundPool.Instance.PlayAudio(clip[rng]);
            obj.transform.position = this.transform.position;
            this.gameObject.SetActive(false);

        }

        public void Heal (int amount)
        {
            isDead = false;
            lives = 3;
            this.gameObject.SetActive(true);
            ParentLife.lives++;
        }

        public void Respawn (Transform lol)
        {
            throw new NotImplementedException();
        }
    }
}