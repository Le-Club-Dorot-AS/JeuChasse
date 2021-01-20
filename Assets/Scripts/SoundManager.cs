using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class SoundManager : MonoBehaviour
{
    public static AudioClip MusicNiv1, MusicNiv2, MusicNiv3, MusicFinal;
    static AudioSource audioSrc;
    // Start is called before the first frame update
    void Start()
    {
        MusicNiv1 = Resources.Load<AudioClip>("cgj gr13 etape 1");
        MusicNiv2 = Resources.Load<AudioClip>("cgj gr13 etape 2");
        MusicNiv3 = Resources.Load<AudioClip>("cgj gr13 etape 3");
        MusicFinal = Resources.Load<AudioClip>("cgj gr13 totale");

        audioSrc = GetComponent<AudioSource>();
    }
    public static void PlaySound(string clip)
    {
        switch (clip)
        {
            case "MusicNiv1":
                audioSrc.PlayOneShot(MusicNiv1);
                break;
            case "MusicNiv2":
                audioSrc.PlayOneShot(MusicNiv2);
                break;
            case "MusicNiv3":
                audioSrc.PlayOneShot(MusicNiv3);
                break;
            case "MusicFinal":
                audioSrc.PlayOneShot(MusicFinal);
                break;
        }
    }
}
