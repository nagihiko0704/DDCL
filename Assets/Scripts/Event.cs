using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Event", menuName = "Event")]
public class Event : ScriptableObject
{
    public int eventCode;
    //Probability is in 0-1
    public float eventProbability;

    public List<string> title;
    [TextArea]
    public List<string> message;

    public List<Sprite> situation;

    //TODO: add minigame
    [TextArea]
    public List<string> minigameExplanation;

    public List<Sprite> minigameExplanationImage;

    public List<string> choiceMessage;

    [TextArea]
    public List<string> resultMessage;

    public List<Sprite> resultSituation;


    public List<float> fassionVal;
    public List<float> staminaVal;
    public List<float> socialVal;
    public List<float> favorVal;

    public List<float> intelliMaxVal;
    public List<float> fassionMaxVal;
    public List<float> staminMaxVal;
    public List<float> socialMaxVal;

    public List<string> methodName;

    private int _randomInt = -1;

    public string SelectedTitle
    {
        get
        {
            if (_randomInt < 0)
                _randomInt = Random.Range(0, title.Count);

            return title[_randomInt];
        }
    }
    public string SelectedMessage
    {
        get
        {
            if (_randomInt < 0)
                _randomInt = Random.Range(0, title.Count);

            return message[_randomInt];
        }
    }
    public Sprite SelectedSituation
    {
        get
        {
            if (_randomInt < 0)
                _randomInt = Random.Range(0, title.Count);

            return situation[_randomInt];
        }
    }

    public string SelectedMethod
    {
        get
        {
            if (_randomInt < 0)
                _randomInt = Random.Range(0, title.Count);

            return methodName[_randomInt];
        }
    }

    public float IntelliVal
    {
        get
        {
            if (_randomInt < 0)
                _randomInt = Random.Range(0, title.Count);

            return intelliMaxVal[_randomInt];
        }
    }

    public float FassionVal
    {
        get
        {
            if (_randomInt < 0)
                _randomInt = Random.Range(0, title.Count);

            return fassionVal[_randomInt];
        }
    }

    public float StaminaVal
    {
        get
        {
            if (_randomInt < 0)
                _randomInt = Random.Range(0, title.Count);

            return staminaVal[_randomInt];
        }
    }

    public float SocialVal
    {
        get
        {
            if (_randomInt < 0)
                _randomInt = Random.Range(0, title.Count);

            return socialVal[_randomInt];
        }
    }

    public float FavorVal
    {
        get
        {
            if (_randomInt < 0)
                _randomInt = Random.Range(0, title.Count);

            return favorVal[_randomInt];
        }
    }

    public int SelectedInt
    {
        get
        {
            return _randomInt;
        }
    }
}

public class ConditionEvent : Event
{

}
