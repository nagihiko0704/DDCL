using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Ending : MonoBehaviour
{

    public int totalP;
    public int totalF;

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < 5; i++)
        {
            SetGradeCredit(GameManager.Inst.studyResultArray[i], i, GameManager.Inst.studyResultArray[i].Favor);
            Debug.Log("과목" + i + ":     " + GameManager.Inst.studyResultArray[i].Score);
        }
        EndCheck();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void EndCheck()
    {
        if (totalP >= 3)
            PlayerPrefs.SetInt("ending", 5);
        else if (totalF >= 2)
            PlayerPrefs.SetInt("ending", 2);
        else
        {
            int num = Random.Range(0, 100);
            if(num<=5)
                PlayerPrefs.SetInt("ending", 7);
            PlayerPrefs.SetInt("ending", 0);
        }
    }

    public void SetGradeCredit(Study study, int num, int _favor)
    {
        float _score = 0f;

        if (study.studyType == Type.Major)
            switch (study.grade)
            {
                case "S":
                    if (_favor >= 75)
                        _score = 4.5f;
                    else if (_favor < 75 && _favor >= 35)
                        _score = 3.5f;
                    else if (_favor < 35 && _favor > 0)
                        _score = 2f;
                    else
                    {
                        totalF++;
                        _score = 0f;
                    }
                    break;

                case "A":
                    if (_favor >= 80)
                        _score = 4.5f;
                    else if (_favor < 80 && _favor >= 40)
                        _score = 3.5f;
                    else if (_favor < 40 && _favor >= 25)
                        _score = 2f;
                    else
                    {
                        totalF++;
                        _score = 0f;
                    }
                    break;

                case "B":
                    if (_favor >= 85)
                        _score = 4.5f;
                    else if (_favor < 85 && _favor >= 45)
                        _score = 3.5f;
                    else if (_favor < 45 && _favor >= 25)
                        _score = 2f;
                    else
                    {
                        totalF++;
                        _score = 0f;
                    }
                    break;

                case "C":
                    if (_favor >= 85)
                        _score = 4.5f;
                    else if (_favor < 85 && _favor >= 50)
                        _score = 3.5f;
                    else if (_favor < 50 && _favor >= 30)
                        _score = 2f;
                    else
                    {
                        totalF++;
                        _score = 0f;
                    }
                    break;
            }

        else if (study.studyType == Type.Sport)
            switch (study.grade)
            {
                case "S":
                    if (_favor >= 25)
                        totalP++;
                    else
                    {
                        totalF++;
                        _score = 0f;
                    }
                    break;

                case "A":
                    if (_favor >= 27)
                        totalP++;
                    else
                    {
                        totalF++;
                        _score = 0f;
                    }
                    break;

                case "B":
                    if (_favor >= 30)
                        totalP++;
                    else
                    {
                        totalF++;
                        _score = 0f;
                    }
                    break;

                case "C":
                    if (_favor >= 32)
                        totalP++;
                    else
                    {
                        totalF++;
                        _score = 0f;
                    }
                    break;
            }

        else if (study.studyType == Type.Discuss)
            switch (study.grade)
            {
                case "S":
                    if (_favor >= 70)
                        _score = 4.5f;
                    else if (_favor < 70 && _favor >= 30)
                        _score = 3.5f;
                    else if (_favor < 30 && _favor > 0)
                        _score = 2f;
                    else
                    {
                        totalF++;
                        _score = 0f;
                    }
                    break;

                case "A":
                    if (_favor >= 75)
                        _score = 4.5f;
                    else if (_favor < 75 && _favor >= 35)
                        _score = 3.5f;
                    else if (_favor < 35 && _favor >= 20)
                        _score = 2f;
                    else
                    {
                        totalF++;
                        _score = 0f;
                    }
                    break;

                case "B":
                    if (_favor >= 85)
                        _score = 4.5f;
                    else if (_favor < 85 && _favor >= 45)
                        _score = 3.5f;
                    else if (_favor < 45 && _favor >= 20)
                        _score = 2f;
                    else
                    {
                        totalF++;
                        _score = 0f;
                    }
                    break;

                case "C":
                    if (_favor >= 85)
                        _score = 4.5f;
                    else if (_favor < 85 && _favor >= 45)
                        _score = 3.5f;
                    else if (_favor < 45 && _favor >= 20)
                        _score = 2f;
                    else
                    {
                        totalF++;
                        _score = 0f;
                    }
                    break;
            }



        GameManager.Inst.studyResultArray[num].Score = _score;
    }
}
