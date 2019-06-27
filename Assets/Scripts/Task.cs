using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Task : MonoBehaviour
{
    //stats that task make player's change
    public float staminaVal;
    public float socialVal;

    //where is task in scedule
    public (int, int) scheduleLocation;


    //task's event
    public Event taskEvent;
}


public class Study : Task
{
    public Study((int, int) _scheduleLocation)
    {
        this.staminaVal = -5f;
        this.socialVal = 0;

        this.scheduleLocation = _scheduleLocation;
    }       
}
public class Club : Task
{
    public Club((int, int) _scheduleLocation)
    {
        this.staminaVal = -8f;
        this.socialVal = 0;

        this.scheduleLocation = _scheduleLocation;
    }
}

public class Rest : Task
{
    public Rest((int, int) _scheduleLocation)
    {
        //I don't know
    }
}