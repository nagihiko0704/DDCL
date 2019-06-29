using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class MainGameUIManager : MonoBehaviour
{
    //schedule window
    public GameObject[] scheduleList = new GameObject[6];
    public GameObject taskIndicator;

    //task background

    //time ui    
    public GameObject textMonth;
    public GameObject textDay;
    public GameObject textTime;

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
        //SetDateUI();
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


    //private void SetDateUI()
    //{


    //    Debug.Log(textDay.GetComponent<Text>().text.Substring(0, 1));
    //    Debug.Log(textDay.GetComponent<Text>().text.Substring(1, 1));


    //    //int curMonth = Int32.Parse(textMonth.GetComponent<Text>().text.Substring(0, 1)) * 10
    //    //                    + Int32.Parse(textMonth.GetComponent<Text>().text.Substring(1, 1));
    //    //int curDay = Int32.Parse(textDay.GetComponent<Text>().text.Substring(0, 1)) * 10
    //    //                    + Int32.Parse(textDay.GetComponent<Text>().text.Substring(1, 1));

    //    //(int, int) calculatedDate = CalculateDate((curMonth, curDay));

    //    //textMonth.GetComponent<Text>().text = calculatedDate.Item1.ToString();
    //    //textDay.GetComponent<Text>().text = calculatedDate.Item2.ToString();

    //}

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

    //need to change
    //private (int, int) CalculateDate((int, int) date)
    //{
    //    int month = date.Item1;
    //    int day = date.Item2;

    //    //array for month has same days
    //    int[] month31 = { 1, 3, 5, 7, 8, 10, 12 };
    //    int[] month30 = { 4, 6, 9, 11 };
    //    int month28 = 2;

    //    day++;

    //    //if day exceed month's day, change month
    //    if((month31.Contains(month) && day > 31)
    //        || (month30.Contains(month) && day > 30)
    //        || (month28 == month && day > 28))
    //    {
    //        day = 1;
    //        month++;
    //        //month has to be 1-12
    //        month = ((month) % 12) + 1;
    //    }

    //    return (month, day);
    //}

    private void InitDateTimeUI()
    {
        textMonth.GetComponent<Text>().text = "03월";
        textDay.GetComponent<Text>().text = "02일";
        textTime.GetComponent<Text>().text = "AM  10:00";
    }
}
