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
    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SwitchChannels(int channel)
    {
        switch (channel)
        {
            case 0:
                //play news
                break;
            case 1:
                //play orders
                //RequestChannel(/*pass fail bool*/);
                break;
            case 2:
                //play music
                break;
        }
    }

    void RequestChannel(bool passFail, bool isCheckpoint, int checkPoint)
    {
        if (isCheckpoint)
        {
            audioSource.Pause();
            audioSource.clip = checkPoints[checkPoint - 1];
            audioSource.Play();
            
        }
        else
        {
            //play intro
            audioSource.clip = intro;
            audioSource.Play();

            //if pass:
            if (passFail)
            {
                audioSource.Pause();
                audioSource.clip = UpdateP[Random.Range(0, 3)];
                audioSource.Play();
            }
            //if fail:
            else
            {
                audioSource.Pause();
                audioSource.clip = UpdateF[Random.Range(0, 3)];
                audioSource.Play();
            }
            audioSource.Pause();
            audioSource.clip = requests[Random.Range(0, 8)];
            audioSource.Play();

            audioSource.Pause();
            audioSource.clip = closing[Random.Range(0, 2)];
            audioSource.Play();
        }
    }
}
