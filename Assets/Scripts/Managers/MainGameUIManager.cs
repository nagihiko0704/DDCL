using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

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
    public GameObject textPeriod;

    //main game canvas
    public GameObject mainGameCanvas;

    //event popup
    public GameObject eventPopUp;

    public GameObject[] statList = new GameObject[4];

    public float TASK_TIME;
    public float SCHEDULE_TIME;

    // Start is called before the first frame update
    void Start()
    {
        TASK_TIME = GameManager.TASK_TIME;
        SCHEDULE_TIME = TASK_TIME * 6;

        InitDateTimeUI();

        eventPopUp.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        SetScheduleUI();
        SetDoingTaskIndicator();
        SetTimeUI();
        SetDateUI();
        SetPeriodUI();
        SetStatUI();
    }

    private void SetScheduleUI()
    {
        Schedule _curSchedule = ScheduleManager.Inst.CurrentSchedule;
        Day _curDay = ScheduleManager.Inst.currentDay;

        Task tempTask;
        string taskName;

        //for every task in current schedule
        for (int task = 0; task < 6; task++)
        {
            tempTask = _curSchedule.taskArray[task, (int)_curDay];
            taskName = tempTask.taskName;

            //applicate background and text
            scheduleList[task].GetComponentInChildren<Text>().text = taskName;
        }
    }

    private void SetDoingTaskIndicator()
    {
        const float START_Y = -660f;
        const float END_Y = 660f;
        float currentTime = ScheduleManager.Inst.curTime;

        float indicatorX;
        float indicatorY = taskIndicator.transform.localPosition.y;
        
        //set currentTime period as schedule time
        if(currentTime > SCHEDULE_TIME)
        {
            currentTime %= SCHEDULE_TIME;
        }

        //time ratio of current time and total time
        float timeRatio = currentTime / SCHEDULE_TIME;

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

        int passedDayNum =(int)((ScheduleManager.Inst.curTime) / SCHEDULE_TIME );

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

        hour =  (int)(curTime / (TASK_TIME / 2)) % 12;
        minute = (int)((curTime * 1.5) % 3);

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

    private void SetPeriodUI()
    {
        int curPeriod = (int)ScheduleManager.Inst.currentPeriod + 1;

        textPeriod.GetComponent<Text>().text = curPeriod.ToString();
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
        eventPopUp.SetActive(true);
        eventPopUp.GetComponent<EventPopUp>().InitSituation(_curEvent);
    }

    private void SetStatUI()
    {
        /*
         * [0]:intell
         * [1]:fassion
         * [2]:stamina
         * [3]:social
         */
        statList[0].GetComponent<Text>().text = GameManager.Inst.player.playerCharacter.Intelli.ToString();
        statList[1].GetComponent<Text>().text = GameManager.Inst.player.playerCharacter.CurFassion.ToString() + " / " + GameManager.Inst.player.playerCharacter.MaxFassion.ToString();
        statList[2].GetComponent<Text>().text = GameManager.Inst.player.playerCharacter.CurStamina.ToString() + " / " + GameManager.Inst.player.playerCharacter.MaxStamina.ToString();
        statList[3].GetComponent<Text>().text = GameManager.Inst.player.playerCharacter.CurSocial.ToString() + " / " + GameManager.Inst.player.playerCharacter.MaxSocial.ToString();
    }

    public void OnClickChallenge()
    {
        SceneManager.LoadScene(6);
    }

    public void OnClickSetting()
    {
        SceneManager.LoadScene(8);
    }
}
