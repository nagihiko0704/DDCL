using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="New Lecture", menuName ="Lecture")]
public class Lecture : ScriptableObject
{
    public string lectureName;
    public string lectureClassification;
    public string lectureRating;
}
