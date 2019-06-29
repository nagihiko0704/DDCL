using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Event", menuName = "Event")]
public class Event : ScriptableObject
{
    public int eventCode;
    //Probability is in 0-1
    public float eventProbability;

    public string title;
    public string explanation;

    public Sprite situation;

    public List<string> choice;

    public float staminaVal;
    public float socialVal;

    


    /*public Event()
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
    }*/
}
