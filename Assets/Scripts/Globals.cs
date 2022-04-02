using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Globals : MonoBehaviour
{
    public static int DayCount = 1;
    public static int StageNum = 0;     // for ease of accessing arrays stagenum 0 will be stage 1

    public static void NextDay()
    {
        DayCount++;
        TallyMark.TallyNextDay();
        StageNum = (int)(DayCount / 30) + 1;
    }
}
