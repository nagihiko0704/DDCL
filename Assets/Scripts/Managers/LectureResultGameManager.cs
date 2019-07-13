using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LectureResultGameManager : MonoBehaviour
{
    public GameObject[] gameLecture = new GameObject[5];

    public LectureList list = new LectureList();
    public List<Task> tempList = new List<Task>();

    private int[] lectureFinalScore = new int[5];


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
                var countS = list.lectureList["S"].Count;
                int lectureNumS = Random.Range(0, countS);
                tempList = list.lectureList["S"];


                gameLecture[i].GetComponent<Text>().text = tempList[lectureNumS].taskName +"    S급";
            }
            else if (lectureFinalScore[i] >= 17)
            {
                //a
                var countA = list.lectureList["A"].Count;
                int lectureNumA = Random.Range(0, countA);
                tempList = list.lectureList["A"];


                gameLecture[i].GetComponent<Text>().text = tempList[lectureNumA].taskName + "    A급";
            }
                
            else if (lectureFinalScore[i] >= 11)
            {
                //b
                var countB = list.lectureList["B"].Count;
                int lectureNumB = Random.Range(0, countB);
                tempList = list.lectureList["B"];


                gameLecture[i].GetComponent<Text>().text = tempList[lectureNumB].taskName + "    B급";
            }

            else
            {
                //c
                var countC = list.lectureList["C"].Count;
                int lectureNumC = Random.Range(0, countC);
                tempList = list.lectureList["C"];


                gameLecture[i].GetComponent<Text>().text = tempList[lectureNumC].taskName + "    C급";
            }

        }
    }

   
}
