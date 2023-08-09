using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour, ISoundPlayable
{
    public AudioClip clip;
    private string Key;

    public void PlaySound(string _key)
    {
        SoundManager.Instance.PlayBGM(_key);
    }

    void Start()
    {

        SoundManager.Instance.ADdSoundClip(clip);
        Key = clip.name;
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
            PlaySound(Key);
    }
}