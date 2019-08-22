using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class   Score : MonoBehaviour
{
    public static int totalP;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
    }
    public void SetGradeCredit(Study study, int num,int _favor)
    {
        float _score=0f;

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
                            _score = 0f;
                        break;
    
                    case "A":
                        if (_favor >= 80)
                            _score = 4.5f;
                        else if (_favor < 80 && _favor >= 40)
                            _score = 3.5f;
                        else if (_favor < 40 && _favor >= 25)
                            _score = 2f;
                        else
                            _score = 0f;
                        break;

                    case "B":
                        if (_favor >= 85)
                            _score = 4.5f;
                        else if (_favor < 85 && _favor >= 45)
                            _score = 3.5f;
                        else if (_favor < 45 && _favor >= 25)
                            _score = 2f;
                        else
                            _score = 0f;
                        break;

                    case "C":
                        if (_favor >= 85)
                            _score = 4.5f;
                        else if (_favor < 85 && _favor >= 50)
                            _score = 3.5f;
                        else if (_favor < 50 && _favor >= 30)
                            _score = 2f;
                        else
                            _score = 0f;
                        break;
                }

            else if (study.studyType == Type.Sport)
                switch (study.grade)
                {
                    case "S":
                        if (_favor >= 25)
                            GameManager.Inst.totalP++;
                        else
                            _score = 0f;
                        break;

                    case "A":
                        if (_favor >= 27)
                            GameManager.Inst.totalP++;
                        else
                            _score = 0f;
                        break;

                    case "B":
                        if (_favor >= 30)
                            GameManager.Inst.totalP++;
                        else
                            _score = 0f;
                        break;

                    case "C":
                        if (_favor >= 32)
                            GameManager.Inst.totalP++;
                        else
                            _score = 0f;
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
                           _score = 0f;
                        break;

                    case "A":
                        if (_favor >= 75)
                            _score = 4.5f;
                        else if (_favor < 75 && _favor >= 35)
                            _score = 3.5f;
                        else if (_favor < 35 && _favor >= 20)
                            _score = 2f;
                        else
                            _score = 0f;
                        break;

                    case "B":
                        if (_favor >= 85)
                            _score = 4.5f;
                        else if (_favor < 85 && _favor >= 45)
                            _score = 3.5f;
                        else if (_favor < 45 && _favor >= 20)
                            _score = 2f;
                        else
                            _score = 0f;
                        break;

                    case "C":
                        if (_favor >= 85)
                            _score = 4.5f;
                        else if (_favor < 85 && _favor >= 45)
                            _score = 3.5f;
                        else if (_favor < 45 && _favor >= 20)
                            _score = 2f;
                        else
                            _score = 0f;
                        break;
            }



        GameManager.Inst.studyResultArray[num].Score = _score;
    }

}



