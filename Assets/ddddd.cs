using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ddddd : MonoBehaviour
{
    [SerializeField] private AudioClip[] clips;
    [SerializeField] private AudioSource audioSource;
    Queue<AudioClip> clipQueue = new Queue<AudioClip>();

    [SerializeField] private GameObject credits;
    // Start is called before the first frame update
    void Start()
    {
        Invoke("ss", 18);
        for(int i = 0; i < clips.Length; i++)
        {
            PlaySound(clips[i]);
            
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (audioSource.isPlaying == false && clipQueue.Count > 0) {
            audioSource.clip = clipQueue.Dequeue();
            audioSource.Play();
        }
    }
    public void PlaySound(AudioClip clip)
    {
        clipQueue.Enqueue(clip);
    }

    public void ss()
    {
        credits.SetActive(true);
    }
    
    
}
