using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class LetterGenerator : MonoBehaviour
{
    [SerializeField] private GameObject[] mailmanLetters;
    [SerializeField] private GameObject officialLetter;
    [SerializeField] private TextMeshPro text;

    private string[] telegrams =
    {
        "ATTENTION ALL UNITS" + "\n" +
        "ENEMY HAS INFILTRATED RADIO COMMUNICATIONS" + "\n" +
        "FULL RADIO SILENCE NOW IN EFFECT" + "\n" +
        "ALL INTERNAL COMMUNICATION BY PHYSICAL MESSAGE" + "\n" +
        "GLORY TO THE NATION" + "\n",

        "ENEMY UNITS CAPTURED PAULEY HILL" + "\n" +
        "ALL CONTACT LOST" + "\n" +
        "CONTINUE TO FIGHT" + "\n",

        "MISSILE BARRAGE IN RESIDENTIAL DISTRICT" + "\n" +
        "INCENDIARY WARHEADS" + "\n" +
        "78 DEAD" + "\n",

        "MARTIAL LAW IS IN EFFECT" + "\n" +
        "LOOTERS WILL BE EXECUTED" + "\n" +
        "DO NOT BETRAY" + "\n",

        "WATER SUPPLIES CUT OFF BY ENEMY" + "\n" +
        "STOCKPILE WATER AND RATION" + "\n" +
        "STAY STRONG" + "\n",

        "HIGHWAY HAS BEEN BOMBED" + "\n" +
        "EVACUATION EFFORTS DELAYED" + "\n" +
        "HOLD OUT" + "\n",

        "THEATER BOMBED" + "\n" +
        "57 DEAD" + "\n" +
        "THEY WILL SEE HELL" + "\n",

        "DOCTORS AND NURSES REFUSE TO EVACUATE" + "\n" +
        "WILL NOT LEAVE WOUNDED" + "\n" +
        "THEY WILL BE REMEMBERED" + "\n",

        "SNIPERS TARGETING CIVILIANS" + "\n" +
        "BEWARE OF OPEN GROUND" + "\n" +
        "WAR CRIMINALS" + "\n",

        "ALL SCHOOLS EVACUATED" + "\n" +
        "CROSSING INTERNATIONAL BORDER" + "\n" +
        "THE CHILDREN WILL NEVER FORGET" + "\n",

        "HOSPITAL BOMBED" + "\n" +
        "WHERE ARE OUR ALLIES" + "\n" +
        "WAR WILL FIND THEM TOO" + "\n",

        "ENEMY IS ASSAULTING VETERAN RIDGE" + "\n" +
        "186 INFANTRY REGIMENT IS ENCIRCLED" + "\n" +
        "FIGHTING TO THE LAST" + "\n",

        "FOOD SUPPLIES CRITICAL" + "\n" +
        "CAN SURVIVE SEVERAL DAYS WITH NO FOOD" + "\n" +
        "STAY STRONG" + "\n",

        "ENEMY HAS BREACHED FORT WOODEN" + "\n" +
        "FIGHTING TO THE LAST" + "\n" +
        "GLORY TO THE NATION" + "\n",

        "8TH RESIDENTIAL BLOCK EVACUATED" + "\n" +
        "THE STREETS ARE EMPTY" + "\n",

        "ENEMY ENTERING SUBURBS" + "\n" +
        "THEY WILL PAY FOR EVERY METER" + "\n" +
        "OUR FINEST HOUR" + "\n",

        "ENEMY IN 17 STREET" + "\n" +
        "BLOCKADES ARE DELAYING INVADERS" + "\n" +
        "ABANDONED CARS AND WAGONS" + "\n",

        "CONSCRIPT BATTALIONS DEPLOYING" + "\n" +
        "FIGHT FOR YOUR FAMILIES" + "\n" +
        "GLORY TO THE NATION" + "\n",

        "NO MORE FRESH WATER" + "\n" +
        "RATION EFFICIENTLY" + "\n" +
        "USE INDUSTRIAL SOURCES" + "\n",

        "CIVILIANS ARE BEING MASSACRED" + "\n" +
        "STAY INDOORS" + "\n" +
        "FIGHT AGAINST EVIL" + "\n",

        "67 VOLUNTEER BRIGADE DESTROYED" + "\n" +
        "ULTIMATE SACRIFICE" + "\n" +
        "GLORY TO THE NATION" + "\n",

        "FIRES ARE ENGULFING CITY HALL" + "\n" +
        "85% BUILDINGS DESTROYED" + "\n" +
        "MONSTERS" + "\n",

        "STATUES AND MEMORIALS DESTROYED" + "\n" +
        "THEY DESTROY EVERYTHING" + "\n" +
        "THEY DESTROY US" + "\n",

        "ENEMY IS HERE" + "\n" +
        "IT WAS AN HONOR" + "\n" +
        "GLORY TO THE NATION" + "\n"
    };
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ShowOfficialLeter(int num)
    {
        officialLetter.SetActive(true);
        text.text = telegrams[num];
    }

    public void ShowMailmanLetter(int num)
    {
        mailmanLetters[num].SetActive(true);
    }

    public void HideAllLetters()
    {
        for (int i = 0; i < mailmanLetters.Length; i++)
        {
            mailmanLetters[i].SetActive(false);
        }
    }
}
