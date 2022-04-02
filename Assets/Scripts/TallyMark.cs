using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TallyMark : MonoBehaviour
{
    public static float distBetween = 0.1f;
    public static GameObject origTally = null;
    private static Vector3 size = Vector3.zero;

    public void Start()
    {
        if (origTally == null)
        {
            TallyMark.origTally = this.gameObject;
            TallyMark.size = TallyMark.origTally.GetComponent<Renderer>().bounds.size;
            TallyMark.origTally.GetComponent<Renderer>().enabled = false;
        }
    }

    public static void TallyNextDay()
    {
        int tallyCount = Globals.DayCount - 1; // we wanted to start tallying at stage 2?
        Debug.Log(tallyCount);

        Transform table = GameObject.Find("Table").transform;
        GameObject newTally = Instantiate(origTally, table, true);
        newTally.transform.position += Vector3.right * tallyCount * (distBetween + size.x);
        newTally.transform.Translate(
            new Vector3(Random.Range(-size.x, size.x), Random.Range(-size.y / 4, size.y / 4), 0));

        if (tallyCount % 5 == 0)
        {
            float distTravelled = 5 * (distBetween + size.x);
            newTally.transform.localScale += new Vector3(0, 0, distTravelled/size.z - size.z);
            float angle = -Mathf.Atan(size.z / distTravelled) * 180f / Mathf.PI;
            newTally.transform.rotation = Quaternion.Euler(0, angle, 0);
            newTally.transform.position += Vector3.left * distTravelled / 2;
        }

        newTally.transform.Rotate(0, Random.Range(-5, 5), 0);
        newTally.GetComponent<Renderer>().enabled = true;
    }
}
