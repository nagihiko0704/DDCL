using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LectureResultGameManager : MonoBehaviour
{
    public GameObject[] gameLecture = new GameObject[5];

    public LectureList list = new LectureList();

    private int[] lectureFinalScore = new int[5];
    private string[] lectureFinalGrade = new string[5];
    public string[] finalLecture = new string[5];

    private 

    void Start()
    {
        SetLecture();
    }

    
    void SetLecture()
    {
        for (int i = 0; i < 4; i++)
        {
            lectureFinalScore[i] = GameManager.Inst.lectureApplicationScore[i] + GameManager.Inst.lectureChoiceScore[i];

            if (lectureFinalScore[i] >= 20)
            {
                //s
                foreach(KeyValuePair<string,Task> item in list.lectureList)
                {
                    string found = "S";
                    var lectureS=list.lectureList.Where()


                }
            }
            else if (lectureFinalScore[i] >= 17)
                //a
            else if (lectureFinalScore[i] >= 11)
                //b
            else
                //c

        }
    }

    public void Lecture0()
    {

    }

    public void Lecture1()
    {

    }

    public void Lecture2()
    {

    }

    public void Lecture3()
    {

    }

    public void Lecture4()
    {

    }
}
