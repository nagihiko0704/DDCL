using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character
{
    public string name;

    //character's stat
    private float _intelligence;

    private float _maxStamina;
    private float _curStamina;

    private float _fassion;

    private float _maxSociability;
    private float _curSociability;

    //character's semester start date
    private int _startSemester;

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

    public int StartSemester
    {
        get { return _startSemester; }

        set
        {
            _startSemester = value;
        }
    }
}

public class Newbie : Character
{
    public Newbie()
    {
        Character character = new Character();

        //set character name
        character.name = "뉴비";

        //set character stat
        character.Intelli = Random.Range(125, 151);
        character.CurStamina = Random.Range(115, 191);
        character.Fassion = Random.Range(10, 36);
        character.CurSocial = Random.Range(50, 176);

        //set character start semester
        character.StartSemester = 1;
    }
}