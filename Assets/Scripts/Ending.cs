using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ending : MonoBehaviour
{
    Score sscore;

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < 5; i++)
        {
            sscore.SetGradeCredit(GameManager.Inst.studyResultArray[i], i, GameManager.Inst.studyResultArray[i].Favor);
            Debug.Log("과목" + i + ":     " + GameManager.Inst.studyResultArray[i].Score);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
