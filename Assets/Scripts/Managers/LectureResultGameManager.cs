using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LectureResultGameManager : MonoBehaviour
{
    public GameObject[] gameLecture = new GameObject[5];

    public LectureList list = new LectureList();
    public List<Task> tempList = new List<Task>();

    private int[] lectureAppScore = new int[5];
    private int[] lectureChoScore = new int[5];
    

    //private int[] lectureFinalScore = new int[5];
    private int lectureFinalScore;

    void Start()
    {
        lectureAppScore = GameManager.lectureApplicationScore;
        lectureChoScore = GameManager.lectureChoiceScore;
        SetLecture();
    }

    void SetLecture()
    {
        for (int i = 0; i < 5; i++)
        {
            //lectureAppScore = GameManager.lectureApplicationScore;
            //lectureChoScore = GameManager.lectureChoiceScore;
            lectureFinalScore = lectureAppScore[i]+lectureChoScore[i];
            Debug.Log(lectureAppScore+" "+lectureChoScore+" "+lectureFinalScore);

            if (lectureFinalScore >= 20)
            {
                //s
                
                tempList = list.lectureList["S"];
                var countS = tempList.Count;
                int lectureNumS = Random.Range(0, countS);

                Debug.Log(countS+"  "+lectureNumS);


                gameLecture[i].GetComponent<Text>().text = tempList[lectureNumS].taskName +"    S급";
            }
            else if (lectureFinalScore >= 17&&lectureFinalScore<20)
            {
                //a
                tempList = list.lectureList["A"];
                var countA = tempList.Count;
                int lectureNumA = Random.Range(0, countA);

                Debug.Log(countA + "  " + lectureNumA);


                gameLecture[i].GetComponent<Text>().text = tempList[lectureNumA].taskName + "    A급";
            }
                
            else if (lectureFinalScore >= 11&&lectureFinalScore<17)
            {
                //b
                
                tempList = list.lectureList["B"];
                var countB = tempList.Count;
                int lectureNumB = Random.Range(0, countB);

                Debug.Log(countB + "  " + lectureNumB);

                gameLecture[i].GetComponent<Text>().text = tempList[lectureNumB].taskName + "    B급";
            }

            else
            {
                //c
                tempList = list.lectureList["C"];
                var countC = tempList.Count;
                int lectureNumC = Random.Range(0, countC);

                Debug.Log(countC + "  " + lectureNumC);


                gameLecture[i].GetComponent<Text>().text = tempList[lectureNumC].taskName + "    C급";
            }

        }
    }

   
}
