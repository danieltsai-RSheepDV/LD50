using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lever : MonoBehaviour
{
    [SerializeField] public float downSpeed = 5f, upSpeed = 1f, pauseTime = 0.25f;
    [SerializeField] public float upAngle = 345, downAngle = 225;

    public bool leverReady;
    // Start is called before the first frame update
    public void Start()
    {
        this.transform.eulerAngles = new Vector3(upAngle, 0, 0);
        leverReady = true;
    }

    public void pullLever()
    {
        if (leverReady)
        {
            this.transform.eulerAngles = new Vector3(upAngle, 0, 0);
            leverReady = false;
            StartCoroutine(pullAnimation());
        }
    }
    private IEnumerator pullAnimation()
    {
        for(float rot = upAngle; rot > downAngle; rot -= downSpeed)
        {
            this.transform.eulerAngles = new Vector3 (rot, 0, 0);
            yield return null;
        }
        this.transform.eulerAngles = new Vector3(downAngle, 0, 0);
        yield return new WaitForSeconds(pauseTime);
        for (float rot = downAngle; rot < upAngle; rot += upSpeed)
        {
            this.transform.eulerAngles = new Vector3(rot, 0, 0);
            yield return null;
        }
        this.transform.eulerAngles = new Vector3(upAngle, 0, 0);
        leverReady = true;
    }
}
