using UnityEngine;
using System.Collections;
using Corn.Pool;

namespace Corn.Pool
{
    [RequireComponent(typeof(AudioSource))]
    public class SoundObject : BasePoolObject
    {
        public AudioSource src_;


        /*
        public override void SetEnable () {
            base.SetEnable();

        }
        /*
        //make your object call this.
        public override void SetDisable () {
            base.SetDisable();

        }*/
        public void PlaySound (AudioClip clip_)
        {
            src_.clip = clip_;
            src_.Play();
            if (!src_.loop)
                StartCoroutine(WaitAndDiable(clip_.length));
        }

        public IEnumerator WaitAndDiable (float wait_)
        {
            yield return new WaitForSeconds(wait_);
            SetDisable();
        }

        public void Awake ()
        {
            src_ = GetComponent<AudioSource>();
            SetDisable();
        }


    }
}