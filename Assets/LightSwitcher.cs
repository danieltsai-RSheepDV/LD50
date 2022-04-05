using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightSwitcher : MonoBehaviour
{
    public bool on = true;
    public void turnSwitch()
    {
        on = !on;
        this.GetComponent<Light>().range = on ? 150 : 0;
    }
}
