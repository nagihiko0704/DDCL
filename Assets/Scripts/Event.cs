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
    public string message;

    public Sprite situation;

    //TODO: add minigame

    public List<string> choiceMessage;

    public List<string> resultMessage;

    public List<Sprite> resultSituation;

    public List<float> staminaVal;
    public List<float> socialVal;
}
