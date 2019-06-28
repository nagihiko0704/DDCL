using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Task
{
    //stats that task make player's change
    public float staminaVal;
    public float socialVal;

    //where is task in scedule
    public (Period, Day) scheduleLocation;


    //task's event
    public Event taskEvent;

    public Task()
    {
        this.staminaVal = 0;
        this.socialVal = 0;
        this.scheduleLocation = (0, 0);
        this.taskEvent = null;
    }

    public Task((Period, Day) _scheduleLocation)
    {
        this.scheduleLocation = _scheduleLocation;
    }
}


public class Study : Task
{
    private int _favor;
    private float _score;

    public Study((Period, Day) _scheduleLocation)
    {
        this.staminaVal = -5f;
        this.socialVal = 0;

        this.scheduleLocation = _scheduleLocation;
    }

    public int Favor
    {
        get { return _favor; }

        set
        {
            _favor = value;
        }
    }

    public float Score
    {
        get { return _score; }

        set
        {
            _score = value;
        }
    }
}
public class Club : Task
{
    public Club((Period, Day) _scheduleLocation)
    {
        this.staminaVal = -8f;
        this.socialVal = 0;

        this.scheduleLocation = _scheduleLocation;
    }
}

public class Rest : Task
{
    public Rest((Period, Day) _scheduleLocation)
    {
        this.scheduleLocation = _scheduleLocation;
    }
}