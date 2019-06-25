using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Task : MonoBehaviour
{
    //stats that task make player's change
    public float staminaVal;
    public float socialVal;

    //where is task in scedule
    public (int, int) sceduleLocation; 


    //need to add event
}


public class Study : Task
{
    public Study((int, int) _sceduleLocation)
    {
        this.staminaVal = -5f;
        this.socialVal = 0;

        this.sceduleLocation = _sceduleLocation;
    }       
}
public class Club : Task
{
    public Club((int, int) _sceduleLocation)
    {
        this.staminaVal = -8f;
        this.socialVal = 0;

        this.sceduleLocation = _sceduleLocation;
    }
}

public class Rest : Task
{
    public Rest((int, int) _sceduleLocation)
    {
        //I don't know
    }
}