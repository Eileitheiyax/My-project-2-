using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public AudioSource audioSource;

    public AudioClip[] audioList;

    public void PlayOneShotAudio(int index, float volume = 1)
    {
        audioSource.PlayOneShot(audioList[index], volume);
    }
}
