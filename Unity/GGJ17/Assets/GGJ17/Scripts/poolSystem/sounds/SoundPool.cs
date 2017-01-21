using UnityEngine;
using System.Collections;
using CommonAssets.Pool;

public class SoundPool : BasePool {

    public bool dontDestroyOnLoad = false;
    static SoundPool instance = null;
    public static SoundPool Instance
    {
        get {
            return instance;
        }
        set {
            instance = value;
        }
    }

    void Awake () {
        if (Instance == null) {
            Instance = this;
            if (dontDestroyOnLoad)
                DontDestroyOnLoad(this);
        }
        else if (Instance != this) {
            Destroy(this.gameObject);
        }
        
    }

    public SoundObject PlayAudio (AudioClip clip_, float volume = 1f, bool looping = false) {
        SoundObject soundplayer = GetPooledObject() as SoundObject;
        soundplayer.SetEnable();

        soundplayer.src_.volume = volume;
        soundplayer.src_.loop = looping;
        soundplayer.PlaySound(clip_);

        return soundplayer;
    }
}
