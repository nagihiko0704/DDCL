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
        SetLecture();
    }

    void SetLecture()
    {
        lectureAppScore = GameManager.lectureApplicationScore;
        lectureChoScore = GameManager.lectureChoiceScore;
        for (int i = 0; i < 5; i++)
        {
        
            lectureFinalScore = lectureAppScore[i]+lectureChoScore[i];
            Debug.Log(lectureAppScore+" "+lectureChoScore+" "+lectureFinalScore);

            if (lectureFinalScore >= 20)
            {
                //s
                
                tempList = list.lectureList["S"];
                var countS = tempList.Count;
                int lectureNumS = Random.Range(0, countS);

                Debug.Log(lectureFinalScore);

                gameLecture[i].GetComponent<Text>().text = tempList[lectureNumS].taskName +"    S급";
                list.lectureList["S"].RemoveAt(lectureNumS);
                
            }
            else if (lectureFinalScore >= 17&&lectureFinalScore<20)
            {
                //a
                tempList = list.lectureList["A"];
                var countA = tempList.Count;
                int lectureNumA = Random.Range(0, countA);

                Debug.Log(lectureFinalScore);


                gameLecture[i].GetComponent<Text>().text = tempList[lectureNumA].taskName + "    A급";
                list.lectureList["A"].RemoveAt(lectureNumA);
            }
                
            else if (lectureFinalScore >= 11&&lectureFinalScore<17)
            {
                //b
                
                tempList = list.lectureList["B"];
                var countB = tempList.Count;
                int lectureNumB = Random.Range(0, countB);

                Debug.Log(lectureFinalScore);

                gameLecture[i].GetComponent<Text>().text = tempList[lectureNumB].taskName + "    B급";
                list.lectureList["B"].RemoveAt(lectureNumB);
            }

            else
            {
                //c
                tempList = list.lectureList["C"];
                var countC = tempList.Count;
                int lectureNumC = Random.Range(0, countC);

                Debug.Log(lectureFinalScore);

                gameLecture[i].GetComponent<Text>().text = tempList[lectureNumC].taskName + "    C급";
                list.lectureList["C"].RemoveAt(lectureNumC);
            }

        }
    }

   
}
