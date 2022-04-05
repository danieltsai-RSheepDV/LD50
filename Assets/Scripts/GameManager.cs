using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = System.Random;

public class GameManager : MonoBehaviour
{
    [SerializeField] private LetterGenerator letterGenerator;
    [SerializeField] private Animator levelFader;
    [SerializeField] private AmmoDispenser ammoDispenser;
    [SerializeField] private AudioSource screech;
    [SerializeField] private GameObject topLight;
    [SerializeField] private GameObject gun;
    [SerializeField] private Light lampLight;
    [SerializeField] private Radio radio;
    
    private int currentStage = 1;
    
    private const int maxTime = 30;
    
    private int requiredAmmo = 30;
    private bool successfulRequest = false;
    
    private int mailmanLetterNum = 0;
    [SerializeField] private int officialLetterNum = 0;

    private Random random = new Random();
    [SerializeField] private int timeLeft = 30;
    private int ammoLeft = 100;
    
    private static GameManager _instance;

    public static GameManager Instance
    {
        get
        {
            if(_instance == null) Debug.LogError("Game Manager is NULL!");
            return _instance;
        }
    }

    private void Awake()
    {
        _instance = this;

        timeLeft = maxTime;
    }

    // Start is called before the first frame update
    void Start()
    {
        Stage1NextTurn();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    // Functions
    public void Stage2NextTurn()
    {
        if (officialLetterNum > 23)
        {
            gun.SetActive(true);
            lampLight.intensity = 0f;
            radio.PlayStatic();
            return;
        }
        letterGenerator.ShowOfficialLeter(officialLetterNum);
        officialLetterNum++;
        
        
        letterGenerator.HideAllLetters();

        // Determine extra character letter
        if (random.Next(0, 2) == 1 && mailmanLetterNum < 9)
        {
            letterGenerator.ShowMailmanLetter(mailmanLetterNum);
            mailmanLetterNum++;
        }
    }
    
    public void Stage1NextTurn()
    {
        if (timeLeft <= 0)
        {
            screech.PlayDelayed(3);
            Invoke("TurnOffLight", 16);
            Invoke("Stage1to2", 20);
            
            return;
        }
        
        // Decrement time left
        int decrementAmount = random.Next(1, 4);
        if (successfulRequest) decrementAmount = decrementAmount == 1 ? 1 : decrementAmount - 1;
        timeLeft -= decrementAmount;
        
        // If checkpoint day
        if (timeLeft == 20 || timeLeft == 10)
        {
            radio.RequestChannel(successfulRequest, true, 4 - timeLeft/10);
        }
        // Else
        else
        {
            //Create request audio
            
            int requestClipNum = random.Next(1, 4);

            radio.RequestChannel(successfulRequest, false, 0);
            
            // Set request ammo requirement
            
            switch (requestClipNum)
            {
                case 1:
                    requiredAmmo = 0;
                    break;
                case 2:
                    requiredAmmo = 50;
                    break;
                case 3:
                    requiredAmmo = 100;
                    break;
            }

            requiredAmmo += (maxTime - timeLeft) * 4;
            
            // Give bullets

            ammoLeft += (100 - ((maxTime - timeLeft) * 3)) / 10 * 10;
            
            ammoDispenser.UpdateAmmoVisuals();
        }
        
        letterGenerator.HideAllLetters();

        // Determine extra character letter
        if (random.Next(0, 2) == 1 && mailmanLetterNum < 9)
        {
            letterGenerator.ShowMailmanLetter(mailmanLetterNum);
            mailmanLetterNum++;
        }
    }

    public void SubmitAmmo(int amount)
    {
        successfulRequest = amount > requiredAmmo;
        ammoLeft -= amount;
        if (currentStage == 1)
        {
            levelFader.Play("FadeOut");
        }else if (currentStage == 2)
        {
            levelFader.Play("FadeOut2");
        }

        ammoDispenser.ResetAmmo();
    }

    public void Stage1to2()
    {
        levelFader.Play("FadeOut2");
        currentStage = 2;
    }

    public int GetAmmoLeft()
    {
        return ammoLeft;
    }

    public void TurnOffLight()
    {
        topLight.SetActive(false);
        radio.PlayCreepyMusic();
    }
}
