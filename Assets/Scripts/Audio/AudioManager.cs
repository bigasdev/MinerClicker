using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    private static AudioManager instance;
    public static AudioManager Instance
    {
        get
        {
            if(instance == null)
            {
                instance = FindObjectOfType<AudioManager>();
            }
            return instance;
        }
    }

    public AudioSource musicSource, sfxSource;

    public AudioClip themeMusic, fightMusic, bossFightMusic;
    public Dictionary<string, AudioClip> musics = new Dictionary<string, AudioClip>();

    private void Start() {
        musics.Add("Theme", themeMusic);
        musics.Add("Fight", fightMusic);
        musics.Add("Boss", bossFightMusic);
    }

    public void ChangeMusic(string music)
    {
        //StartCoroutine(Fade(musicSource, music));
        musicSource.clip = musics[music];
        musicSource.Play();
    }

    /*IEnumerator Fade(AudioSource source, string music)
    {
        source.volume -= .005f;
        yield return source.volume <= 0;
        source.clip = musics[music];
        source.volume += .005f;
        yield return source.volume >= 0.015f;
    }*/
}

