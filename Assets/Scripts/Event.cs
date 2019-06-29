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

    //TODO: add minigame

    public List<string> choice;

    public List<string> result;

    public float staminaVal;
    public float socialVal;
}
