using UnityEngine;
using System;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour
{
    public Sound[] sounds;

    public static AudioManager instance;

    void Awake() {
        if(instance == null) 
            instance = this;
        else {
            Destroy(gameObject);
            return;
        }

        DontDestroyOnLoad(this.gameObject);

        foreach (Sound s in sounds) {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;

            s.source.volume = s.volume;
        }
    }

    public void Play(string name) {
        Sound s = Array.Find(sounds, sounds => sounds.soundName == name);
        if(s == null) return;
        s.source.Play();
    }
}
