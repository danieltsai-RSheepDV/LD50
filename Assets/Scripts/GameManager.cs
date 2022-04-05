using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = System.Random;

public class GameManager : MonoBehaviour
{
    private const int maxTime = 30;
    
    private int requiredAmmo = 30;
    private bool successfulRequest = false;
    
    private bool mailmanLetter = false;
    private int mailmanLetterNum = 0;

    private Random random = new Random();
    private int timeLeft = 30;
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
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    // Functions

    public void NextTurn()
    {
        // Decrement time left
        int decrementAmount = random.Next(1, 3);
        if (successfulRequest) decrementAmount = decrementAmount == 1 ? 1 : decrementAmount - 1;
        timeLeft -= decrementAmount;
        
        // Generate next request
        
        // If checkpoint day
        if (timeLeft == 20 || timeLeft == 10 || timeLeft == 0)
        {
            
        }
        // Else
        else
        {
            //Create request audio
            
            int updateClipNum = random.Next(1, 5);
            int requestClipNum = random.Next(1, 5);
            int conclusionClipNum = random.Next(1, 5);
            
            // Update audio clips
            
            // Set request ammo requirement
            
            switch (requestClipNum)
            {
                case 1:
                    requiredAmmo = 0;
                    break;
                case 2:
                    requiredAmmo = 5;
                    break;
                case 3:
                    requiredAmmo = 12;
                    break;
                case 4:
                    requiredAmmo = 15;
                    break;
                case 5:
                    requiredAmmo = 30;
                    break;
            }

            requiredAmmo += (maxTime - timeLeft) * 4;
            
            // Give bullets

            ammoLeft += 100 - ((maxTime - timeLeft) * 3);
        }

        // Determine extra character letter
        if (random.Next(0, 1) == 1)
        {
            
        }
    }

    public void SubmitAmmo(int amount)
    {
        successfulRequest = amount > requiredAmmo;
    }

    public int GetAmmoLeft()
    {
        return ammoLeft;
    }
}
