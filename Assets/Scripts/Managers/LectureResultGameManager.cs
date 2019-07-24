using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LectureResultGameManager : MonoBehaviour
{
    public GameObject[] gameLecture = new GameObject[6];

    public LectureList list = new LectureList();
    public List<Study> tempList = new List<Study>();

    private int[] _lectureAppScore = new int[5];
    private int[] _lectureChoScore = new int[5];
    

    private int _lectureFinalScore;

    void Start()
    {
        SetLecture();
    }

    void SetLecture()
    {
        _lectureAppScore = GameManager.lectureApplicationScore;
        _lectureChoScore = GameManager.lectureChoiceScore;
        for (int i = 0; i < 5; i++)
        {

            _lectureFinalScore = _lectureAppScore[i] + _lectureChoScore[i];
            Debug.Log(_lectureAppScore + " " + _lectureChoScore + " " + _lectureFinalScore);

            if (_lectureFinalScore >= 20)
            {
                DecideLectureByGrade(i, "S");

            }
            else if (_lectureFinalScore >= 17 && _lectureFinalScore < 20)
            {
                DecideLectureByGrade(i, "A");

            }

            else if (_lectureFinalScore >= 11 && _lectureFinalScore < 17)
            {
                DecideLectureByGrade(i, "B");
            }

            else
            {
                DecideLectureByGrade(i, "C");
            }
        }
    }

    void DecideLectureByGrade(int i, string grade)
    {
        tempList = list.lectureList[grade];
        var countGrade = tempList.Count;
        int selectedLecture = Random.Range(0, countGrade);

        

        gameLecture[i].GetComponent<Text>().text = tempList[selectedLecture].taskName + "    "+grade+"급";



        GameManager.Inst.studyResultArray[i] = tempList[selectedLecture];
        list.lectureList[grade].RemoveAt(selectedLecture);
    }

    public void CheckButtonOnClick()
    {
        SceneManager.LoadScene(4);
    }

   
}
