using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainGameUIManager : MonoBehaviour
{
    //schedule window
    public GameObject[] scheduleList = new GameObject[6];

    //task background
    

    //this game's schedule
    private Task _curTask;
    private Schedule _curSchedule;
    private Period _curPeriod;
    private Day _curDay;
     
    
    // Start is called before the first frame update
    void Start()
    {
        _curTask = GameManager.Inst.currentTask;
        _curSchedule = GameManager.Inst.currentSchedule;
        _curPeriod = _curTask.scheduleLocation.Item1;
        _curDay = _curTask.scheduleLocation.Item2;



    }

    // Update is called once per frame
    void Update()
    {
        if(_curDay != GameManager.Inst.currentTask.scheduleLocation.Item2)
        {
            _curDay = GameManager.Inst.currentTask.scheduleLocation.Item2;
        }

        SetScheduleUI();
    }

    private void SetScheduleUI()
    {
        Task tempTask;
        Color colorTaskBg;
        string taskName;

        //for every task in current schedule
        for (int task = 0; task < 6; task++)
        {
            tempTask = _curSchedule.taskArray[task, (int)_curDay];
            colorTaskBg = new Color(0f, 0f, 0f);
            taskName = "삐\n빅";

            //chage background as task type
            //color change is for test
            if(tempTask.GetType() == typeof(Study))
            {
                colorTaskBg = new Color(0.25f, 0.25f, 0);
                taskName = "학\n\n업";
            }
            else if(tempTask.GetType() == typeof(Club))
            {
                colorTaskBg = new Color(0.25f, 0, 0.25f);
                taskName = "동\n아\n리";
            }
            else if(tempTask.GetType() == typeof(Rest))
            {
                colorTaskBg = new Color(0, 0.25f, 0.25f);
                taskName = "휴\n\n식";
            }

            //applicate background and text
            scheduleList[task].GetComponent<Image>().color = colorTaskBg;
            scheduleList[task].GetComponentInChildren<Text>().text = taskName;
        }
    }

   
}
