using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    //character's stat
    private float _intelligence;

    private float _maxStamina;
    private float _curStamina;

    private float _fassion;

    private float _maxSociability;
    private float _curSociability;

    //each stat's max value
    private const float MAX_INTELLI = 200f;
    private const float MAX_STAMINA = 200f;
    private const float MAX_FASSION = 50f;
    private const float MAX_SOCIAL = 200f;


    public float Intelli
    {
        get { return _intelligence; }

        set
        {
            _intelligence = value;

            //don't let exceed maximum
            if(_intelligence > MAX_INTELLI)
            {
                _intelligence = MAX_INTELLI;
            }
        }
    }

    public float MaxStamina
    {
        get { return _maxStamina; }

        set
        {
            _maxStamina = value;

            //don't let exceed maximum
            if (_maxStamina > MAX_STAMINA)
            {
                _maxStamina = MAX_STAMINA;
            }
        }
    }

    public float CurStamina
    {
        get { return _curStamina; }

        set
        {
            _curStamina = value;

            //current value can't exceed max value
            if(_curStamina > _maxStamina)
            {
                _curStamina = _maxStamina;
            }
        }
    }

    public float Fassion
    {
        get { return _fassion; }

        set
        {
            _fassion = value;

            //don't let exceed maximum
            if (_fassion > MAX_FASSION)
            {
                _fassion = MAX_FASSION;
            }
        }
    }

    public float MaxSocial
    {
        get { return _maxSociability; }

        set
        {
            _maxSociability = value;

            //don't let exceed maximum
            if (_maxSociability > MAX_SOCIAL)
            {
                _maxSociability = MAX_SOCIAL;
            }
        }
    }

    public float CurSocial
    {
        get { return _curSociability; }

        set
        {
            _curSociability = value;

            //current value can't exceed max value
            if (_curSociability > _maxSociability)
            {
                _curSociability = _maxSociability;
            }
        }
    }
}
