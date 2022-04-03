using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MorseCode : MonoBehaviour
{
    public static Dictionary<char, string> morseCode = new Dictionary<char, string>();
    public bool on = false;

    // I made this because I am bored, we probably won't even use this -_-
    static MorseCode()
    {
        string letters = "abcdefghijklmnopqrstuvwxyz1234567890";
        string codes = ".-/-.../-.-./-.././..-./--./..../../.---/-.-/.-../--/-./---/.--./--.-/.-./.../-/" +
            "..-/...-/.--/-..-/-.--/--../.----/..---/...--/....-/...../-..../--.../---../----./-----/";
        int index = -1;
        foreach(char letter in letters)
        {
            string code = "";
            while (codes[++index] != '/')
                code += codes[index];
            morseCode.Add(letter, code);
        }
    }

    // Start is called before the first frame update
    private void Start()
    {
        on = false;
    }

    // Update is called once per frame
    void showMessage(string message)
    {
        message = message.ToLower();
        foreach(char letter in message)
        {
            if (letter == ' ' || letter == '.')
                StartCoroutine(pause(4));
            else
            {
                string code = morseCode[letter];
                foreach(char ch in code)
                {
                    on = true;
                    StartCoroutine(pause(ch == '-' ? 3 : 1));
                }
            }
        }
    }

    public IEnumerator pause(float seconds)
    {
        yield return new WaitForSeconds(seconds);
        on = false;
        yield return new WaitForSeconds(3);
    }
}
