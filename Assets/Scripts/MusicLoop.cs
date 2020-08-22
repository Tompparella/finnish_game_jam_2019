using UnityEngine.Audio;
using UnityEngine;
using System.Collections;


[System.Serializable]
public class MusicLoop
{
    public AudioClip clip;

    public string name;


    [Range(0f, 1f)]
    public float volume;

    public bool play;
    public bool loop;

    [HideInInspector]
    public AudioSource source;

    public IEnumerator FadeOut()
    {
        float startVolume = this.source.volume;

        while (this.source.volume > 0)
        {
            this.source.volume -= startVolume * Time.deltaTime / 3;

            yield return null;
        }

    }
    public IEnumerator FadeIn()
    {
        float startVolume = volume;

        Debug.Log(source.volume + volume);

        while (source.volume < volume)
        {
            source.volume += startVolume * Time.deltaTime / 10;
            yield return null;
        }

    }
    
    public void PlayEffect()
    {
        if (!(this.loop))
        {
            this.source.Play();
        }
        return;
    }
}
