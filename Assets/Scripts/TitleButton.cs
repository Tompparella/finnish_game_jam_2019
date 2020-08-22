using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;

public class TitleButton : MonoBehaviour
{

    public string text;
    public AudioClip clip;
    [HideInInspector]
    public AudioSource confirmAudio;

    private void Awake()
    {
        confirmAudio = gameObject.AddComponent<AudioSource>();
        confirmAudio.clip = clip;
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonUp(0)) 
        {
            confirmAudio.Play();
            SceneManager.LoadScene("EetuYrittääKarttaa");
        }
    }

}
