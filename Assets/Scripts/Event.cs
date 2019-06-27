using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Event
{
    private int _eventCode;
    //Probability is in 0-1
    private float _eventProbability;

    private float _staminaVal;
    private float _socialVal;

    public Event()
    {
        this._eventCode = 0;
        this._eventProbability = 0;
        this._staminaVal = 0;
        this._socialVal = 0;
    }

    public Event(float stamina, float social)
    {
        this._eventCode = 0;
        this._eventProbability = 0;
        this._staminaVal = stamina;
        this._socialVal = social;
    }
    
    public int EventCode
    {
        get { return _eventCode; }

        set
        {
            _eventCode = value;
        }
    }

    public float EventProbability
    {
        get { return _eventProbability; }

        set
        {
            _eventProbability = value;
        }
    }

    public float Stamina
    {
        get { return _staminaVal; }

        set
        {
            _staminaVal = value;
        }
    }

    public float Social
    {
        get { return _socialVal; }

        set
        {
            _socialVal = value;
        }
    }
}
