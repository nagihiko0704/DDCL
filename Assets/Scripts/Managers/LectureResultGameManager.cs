using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LectureResultGameManager : MonoBehaviour
{
    // Start is called before the first frame update

    void Start()
    {

    }

    public int[] lectureFinalScore = new int[5];
    void SetLecture()
    {
        for (int i = 0; i < 4; i++)
        {
            lectureFinalScore[i] = GameManager.Inst.lectureApplicationScore[i] + GameManager.Inst.lectureChoiceScore[i];
        }
    }

}
