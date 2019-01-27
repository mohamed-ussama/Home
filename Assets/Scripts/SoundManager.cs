using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{

    public AudioClip attackHitSound;
    public AudioClip gettingHitSound;
    public AudioClip jumpSound;
    public AudioClip victorySound;

    public static SoundManager inistance = null;

    AudioSource audioSource = null;



    void Awake()
    {
        inistance = this;
        audioSource = this.GetComponent<AudioSource>();
    }


    public void PlayattackHitSound()
    {
        audioSource.PlayOneShot(attackHitSound);
    }

    public void PlaygettingHitSound()
    {
        audioSource.PlayOneShot(gettingHitSound);
    }

    public void PlayjumpSound()
    {
        audioSource.PlayOneShot(jumpSound);
    }

    public void PlayvictorySound()
    {
        audioSource.PlayOneShot(victorySound);
    }
}
