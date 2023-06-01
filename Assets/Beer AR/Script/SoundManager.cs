using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class SoundManager : MonoBehaviour
{
    private AudioSource audioSource;

    [SerializeField]
    private List<AudioClip> audioClips = new List<AudioClip>();

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void BeerSound()
    {
        audioSource.PlayOneShot(audioClips[0]);
    }

    public void UISound()
    {
        audioSource.PlayOneShot(audioClips[1]);
    }

    public void SnackSound()
    {
        audioSource.PlayOneShot(audioClips[2]);
    }

}
