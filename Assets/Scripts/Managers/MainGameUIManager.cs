using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class MainGameUIManager : SingletonBehaviour<MainGameUIManager>
{
    //schedule window
    public GameObject[] scheduleList = new GameObject[6];
    public GameObject taskIndicator;

    //task background

    //time ui    
    public GameObject textMonth;
    public GameObject textDay;
    public GameObject textTime;

    //main game canvas
    public GameObject mainGameCanvas;

    //event popup
    public GameObject eventPopUp;

    // Start is called before the first frame update
    void Start()
    {
        InitDateTimeUI();
    }

    // Update is called once per frame
    void Update()
    {
        SetScheduleUI();
        SetDoingTaskIndicator();
        SetTimeUI();
        SetDateUI();
    }

    private void SetScheduleUI()
    {
        Schedule _curSchedule = ScheduleManager.Inst.CurrentSchedule;
        Day _curDay = ScheduleManager.Inst.CurrentTask.scheduleLocation.Item2;

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

    private void SetDoingTaskIndicator()
    {
        const float TOTAL_SCHEDULE_TIME = 36f;
        const float START_Y = -600f;
        const float END_Y = 600f;
        float currentTime = ScheduleManager.Inst.curTime;

        float indicatorX;
        float indicatorY = taskIndicator.transform.localPosition.y;
        
        //set currentTime period 36s
        if(currentTime > 36f)
        {
            currentTime %= 36;
        }

        //time ratio of current time and total time
        float timeRatio = currentTime / TOTAL_SCHEDULE_TIME;

        indicatorX = Mathf.Lerp(START_Y, END_Y, timeRatio);

        Vector3 indicatorLoaction = new Vector3(indicatorX, indicatorY);

        taskIndicator.transform.localPosition = indicatorLoaction;
    }


    //need to change
    //TODO:
    //1. character has start date
    //2. SetDateUI and CalculateDate should be changed


    private void SetDateUI()
    {
        (int, int) startDate;
        (int, int) resultDate;

        int passedDayNum =(int)((ScheduleManager.Inst.curTime) / 36f);

        string resultMonth;
        string resultDay;

        if(passedDayNum < 1)
        {
            return;
        }

        switch (GameManager.Inst.player.playerCharacter.StartSemester)
        {
            case (1):
                startDate = (3, 2);
                break;
            case (2):
                startDate = (9, 1);
                break;

            default:
                startDate = (0, 0);
                break;
        }

        resultDate = startDate;

        for (int day = passedDayNum; day > 0; day--)
        {
            resultDate = CalculateDate((resultDate));
        }

        resultMonth = resultDate.Item1.ToString();
        resultDay = resultDate.Item2.ToString();

        if(resultMonth.Length < 2)
        {
            resultMonth = "0" + resultMonth;
        }

        if(resultDay.Length < 2)
        {
            resultDay = "0" + resultDay;
        }

        textMonth.GetComponent<Text>().text = resultMonth + "월";
        textDay.GetComponent<Text>().text = resultDay + "일";
    }

    private void SetTimeUI()
    {
        float curTime = ScheduleManager.Inst.curTime;

        int hour;
        int minute;
        string hourString;
        string minString;
        string dayAndNight;

        hour =  (((int)curTime) / 3) % 12;
        minute = ((int)curTime) % 3;

        //Debug.Log(hour);

        if(hour > 1)
        {
            dayAndNight = "PM";
        }
        else
        {
            dayAndNight = "AM";
        }
      
        minString = (minute * 20).ToString();
        //if state for int 0 -> string '00'
        if (minString.Length < 2)
        {
            minString = "00";
        }


        hourString = ((hour + 10) % 12).ToString();
        //if state for PM 12:00
        if(hour == 2)
        {
            hourString = "12";
        }
        
        if(hourString.Length < 2)
        {
            hourString = '0' + hourString;
        }

        textTime.GetComponent<Text>().text = dayAndNight + "  " + hourString + ":" + minString;
    }

    private (int, int) CalculateDate((int, int) date)
    {
        int month = date.Item1;
        int day = date.Item2;

        //array for month has same days
        int[] month31 = { 1, 3, 5, 7, 8, 10, 12 };
        int[] month30 = { 4, 6, 9, 11 };
        int month28 = 2;

        day++;

        //if day exceed month's day, change month
        if ((month31.Contains(month) && day > 31)
            || (month30.Contains(month) && day > 30)
            || (month28 == month && day > 28))
        {
            day = 1;
            month++;
            //month has to be 1-12
            month = ((month) % 12) + 1;
        }

        return (month, day);
    }

    private void InitDateTimeUI()
    {
        //set start date depend on start semester
        switch(GameManager.Inst.player.playerCharacter.StartSemester)
        {
            case (1):
                textMonth.GetComponent<Text>().text = "03월";
                textDay.GetComponent<Text>().text = "02일";
                break;
            case (2):
                textMonth.GetComponent<Text>().text = "09월";
                textDay.GetComponent<Text>().text = "01일";
                break;
        }

        textTime.GetComponent<Text>().text = "AM  10:00";
    }
    
    public void MakeEventPopUp(Event _curEvent)
    {
        GameObject _instance;
        _instance = Instantiate(eventPopUp, mainGameCanvas.transform);
        _instance.GetComponent<EventPopUp>().Init(_curEvent);
    }
}
