using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioListener : MonoBehaviour
{
    AudioSource audioSource;
    public AudioClip[] ad;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
    }
    public void SoundExplosive()
    {
        audioSource = transform.parent.GetComponent<AudioSource>();
        audioSource.clip = ad[0];
        audioSource.Play();
    }
    public void SoundHit()
    {
        audioSource = transform.parent.GetComponent<AudioSource>();
        audioSource.clip = ad[1];
        audioSource.Play();
    }
}
