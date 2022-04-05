using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Radio : MonoBehaviour
{
    [SerializeField] private AudioClip[] UpdateP;
    [SerializeField] private AudioClip[] UpdateF;
    [SerializeField] private AudioClip intro;
    [SerializeField] private AudioClip[] requests;
    [SerializeField] private AudioClip[] closing;
    [SerializeField] private AudioClip[] checkPoints;
    [SerializeField] private AudioSource audioSource;

    [SerializeField] private AudioClip music;
    [SerializeField] private AudioClip musicl;
    [SerializeField] private AudioClip statics;
    
    Queue<AudioClip> clipQueue = new Queue<AudioClip>();
    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (audioSource.isPlaying == false && clipQueue.Count > 0) {
            audioSource.clip = clipQueue.Dequeue();
            audioSource.Play();
        }
    }

    public void PlayCreepyMusic()
    {
        audioSource.clip = musicl;
        audioSource.Play();
        audioSource.loop = true;
    }

    public void RequestChannel(bool passFail, bool isCheckpoint, int checkPoint)
    {
        audioSource.Stop();
        
        if (isCheckpoint)
        {
            audioSource.Pause();
            audioSource.clip = checkPoints[checkPoint - 1];
            audioSource.Play();
            
        }
        else
        {
            //play intro
            PlaySound(intro);

            //if pass:
            if (passFail)
            {
                PlaySound(UpdateP[Random.Range(0, 3)]);
            }
            //if fail:
            else
            {
                PlaySound(UpdateF[Random.Range(0, 3)]);
            }
            PlaySound(requests[Random.Range(0, 8)]);

            PlaySound(closing[Random.Range(0, 2)]);
        }
        
        PlaySound(statics);
        
        PlaySound(music);
    }

    public void PlayStatic()
    {
        PlaySound(statics);
    }
    
    public void PlaySound(AudioClip clip)
    {
        clipQueue.Enqueue(clip);
    }
}
