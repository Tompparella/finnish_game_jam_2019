using UnityEngine.Audio;
using System;
using UnityEngine;

public class AudioManager : MonoBehaviour
{

    public MusicLoop[] loops;

    [HideInInspector]
    public int counter = 0;
    void Awake()
    {
        foreach (MusicLoop l in loops)
        {
            l.source = gameObject.AddComponent<AudioSource>();

            l.source.clip = l.clip;
            l.source.volume = l.volume;
            l.source.loop = l.loop;
            if (l.loop)
            {
                l.source.volume = l.play ? l.volume : 0;
                l.source.Play();
            }
        }
    }

    public void AddLoop(string name)
    {
        MusicLoop l = Array.Find(loops, loop => loop.name == name);
        if (l == null)
        {
            return;
        }

        StartCoroutine (l.FadeIn());
    }

    public void RemoveLoop(string name)
    {
        MusicLoop l = Array.Find(loops, loop => loop.name == name);
        if (l == null)
        {
            return;
        }
        StartCoroutine (l.FadeOut());
    }

    public void PlaySound (string name)
    {
        MusicLoop l = Array.Find(loops, loop => loop.name == name);
        if (l == null)
        {
            return;
        }

        l.PlayEffect();
    }

    public void IterateMusic()
    {
        switch (counter)
        {
            case 0:
                AddLoop("AmbientCalmBass");
                break;
            case 1:
                AddLoop("OverworldStrings");
                break;
            case 2:
                AddLoop("AmbientDrums");
                break;
            case 3:
                RemoveLoop("AmbientCalmBass");
                RemoveLoop("AmbientPianoMain");
                RemoveLoop("AmbientDrums");
                AddLoop("DrumBreakdown");
                break;
            case 4:
                AddLoop("ExplorePianoMain");
                break;
            case 5:
                RemoveLoop("DrumBreakdown");
                AddLoop("ExploreHihat");
                break;
            default:
                print("Error iterating audio.");
                break;
        }
        counter++;
    }


}
