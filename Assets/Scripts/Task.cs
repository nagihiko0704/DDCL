using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Task
{
    public string taskName;

    //stats that task make player's change
    public float staminaVal;
    public float socialVal;

    //where is task in scedule
    public (Period, Day) scheduleLocation;


    //task's event
    public Event taskEvent;

    public Task()
    {
        this.taskName = null;
        this.staminaVal = 0;
        this.socialVal = 0;
        this.scheduleLocation = (0, 0);
        this.taskEvent = null;
    }

    public Task(string _taskName)
    {
        this.taskName = _taskName;
        this.staminaVal = 0;
        this.socialVal = 0;
        this.scheduleLocation = (0, 0);
        this.taskEvent = null;
    }

    public Task((Period, Day) _scheduleLocation)
    {
        this.taskName = null;
        this.staminaVal = 0;
        this.socialVal = 0;
        this.scheduleLocation = _scheduleLocation;
        this.taskEvent = null;
    }

    public Task((Period, Day) _scheduleLocation, Event _taskEvent) : this(_scheduleLocation)
    {
        this.taskName = null;
        this.staminaVal = 0;
        this.socialVal = 0;
        this.scheduleLocation = (0, 0);
        this.taskEvent = _taskEvent;
    }
}

public enum Type { Major, Discuss, Sport };

public class Study : Task
{
    public Type studyType;
    public string grade;
        
    private int _favor;
    private float _score;

    private const int MAX_FAVOR = 100;

    public Study(string _taskName, Type _studyType, string _grade) : base(_taskName)
    {
        this.studyType = _studyType;
        this.grade = _grade;

        switch(_studyType)
        {
            case (Type.Major):
                this.staminaVal = -2;
                this.socialVal = 0;
                break;
            case (Type.Discuss):
                this.staminaVal = -3;
                this.socialVal = 0;
                break;
            case (Type.Sport):
                this.staminaVal = -5;
                this.socialVal = 0;
                break;
        }

        switch(_grade)
        {
            case ("S"):
            case ("s"):
                this.staminaVal += 1;
                break;
            case ("A"):
            case ("a"):
                this.staminaVal += 0;
                break;
            case ("B"):
            case ("b"):
                this.staminaVal += -1;
                break;
            case ("C"):
            case ("c"):
                this.staminaVal += -2;
                break;
        }
    }

    public Study((Period, Day) _scheduleLocation) : base(_scheduleLocation)
    {
        this.staminaVal = -5f;
        this.socialVal = 0;
    }

    public Study((Period, Day) _scheduleLocation, Event _taskEvent) : base(_scheduleLocation, _taskEvent)
    {
        this.staminaVal = -5f;
        this.socialVal = 0;
    }

    public int Favor
    {
        get { return _favor; }

        set
        {
            _favor = value;


            //limit favor value at most MAX_FAVOR
            if (_favor > MAX_FAVOR)
            {
                _favor = MAX_FAVOR;
            }
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
    public Club((Period, Day) _scheduleLocation) : base(_scheduleLocation)
    {
        this.staminaVal = -8f;
        this.socialVal = 0;
    }

    public Club((Period, Day) _scheduleLocation, Event _taskEvent) : base(_scheduleLocation, _taskEvent)
    {
        this.staminaVal = -8f;
        this.socialVal = 0;
    }
}

public class Rest : Task
{
    public Rest((Period, Day) _scheduleLocation) : base(_scheduleLocation)
    {

    }

    public Rest((Period, Day) _scheduleLocation, Event _taskEvent) : base(_scheduleLocation, _taskEvent)
    {

    }
}