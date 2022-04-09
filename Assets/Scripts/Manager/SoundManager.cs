using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public enum SoundType
{
    SE,
    BGM,
    END
}
public class SoundManager : Singleton<SoundManager>
{
    Dictionary<string, AudioClip> sounds = new Dictionary<string, AudioClip>();
    Dictionary<SoundType, float> Volumes = new Dictionary<SoundType, float>() { { SoundType.SE, 1 }, { SoundType.BGM, 1 } };
    Dictionary<SoundType, AudioSource> AudioSources = new Dictionary<SoundType, AudioSource>();

    protected override void Awake()
    {
        GameObject Se = new GameObject();
        Se.transform.parent = transform;
        Se.AddComponent<AudioSource>();
        AudioSources[SoundType.SE] = Se.GetComponent<AudioSource>();

        GameObject Bgm = new GameObject();
        Bgm.transform.parent = transform;
        Bgm.AddComponent<AudioSource>().loop = true;
        AudioSources[SoundType.BGM] = Bgm.GetComponent<AudioSource>();

        AudioClip[] clips = Resources.LoadAll<AudioClip>("Sounds/");
        foreach (AudioClip clip in clips)
            sounds[clip.name] = clip;
    }
    public void PlaySound(string clipName, SoundType ClipType = SoundType.SE, float Volume = 1, float Pitch = 1)
    {
        if (ClipType == SoundType.BGM)
        {
            AudioSources[SoundType.BGM].clip = sounds[clipName];
            AudioSources[SoundType.BGM].volume = Volume * Volumes[SoundType.BGM];
            AudioSources[SoundType.BGM].Play();
        }
        else
        {
            AudioSources[ClipType].volume = Volumes[ClipType];
            AudioSources[ClipType].pitch = Pitch;
            AudioSources[ClipType].PlayOneShot(sounds[clipName], Volume);
        }
    }
}
