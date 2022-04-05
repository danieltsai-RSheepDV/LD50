using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TallyMark : MonoBehaviour
{
    private static int numTallies = 0;
    public static float distBetween = 0.1f;
    public static GameObject origTally = null;
    private static Vector3 size = Vector3.zero;
    private static int wrapTallies = 10;
    private static int StartDay;
    [SerializeField] int startDay = 1;

    public void Start()
    {
        if (origTally == null)
        {
            TallyMark.origTally = this.gameObject;
            TallyMark.size = TallyMark.origTally.GetComponent<Renderer>().bounds.size;
            TallyMark.origTally.GetComponent<Renderer>().enabled = false;
            TallyMark.StartDay = this.startDay;
        }

    }

    public static void TallyNextDays(int numDays)
    {
        for(int i = 0; i < numDays; i++)
        {
            TallyNextDay();
        }
    }

    public static void TallyNextDay()
    {
        numTallies++;
        if (numTallies < TallyMark.StartDay)
            return;
        int tallyCount = (numTallies - TallyMark.StartDay) % wrapTallies; // we wanted to start tallying at stage 2?
        float increment = distBetween + size.x;
        float angle = -Mathf.Atan(size.z / 3 / increment);

        Transform table = GameObject.Find("TallyMarks").transform;
        GameObject newTally = Instantiate(origTally, table, true);
        newTally.transform.position += Vector3.right * tallyCount * increment
            + new Vector3(Random.Range(-size.x, size.x), Random.Range(-size.y / 4, size.y / 4), 0);

        if (tallyCount % 5 == 0)
        {
            newTally.transform.position += Vector3.left * 2.5f * increment;
            newTally.transform.rotation = Quaternion.Euler(0, angle * 180 / Mathf.PI - 0.05f, 0);
            Vector3 scale = newTally.transform.localScale;
            scale.z /= Mathf.Sin(angle) + Random.Range(0, 0.2f);
            newTally.transform.localScale = scale;
        }
        if (tallyCount == 0)
        {
            newTally.transform.position += Vector3.right * wrapTallies * increment;
            origTally.transform.position += Vector3.back * (size.z + distBetween);
        }

        newTally.transform.Rotate(0, Random.Range(-5, 5), 0);
        newTally.GetComponent<Renderer>().enabled = true;
    }
}
