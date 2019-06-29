using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainGameUIManager : SingletonBehaviour<MainGameUIManager>
{
    //schedule window
    public GameObject[] scheduleList = new GameObject[6];
    public GameObject taskIndicator;

    //task background
    
    
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        SetScheduleUI();
        SetDoingTaskIndicator();
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
        

        //time ratio of current time and total time
        float timeRatio = currentTime / TOTAL_SCHEDULE_TIME;
        //Debug.Log(timeRatio);

        indicatorX = Mathf.Lerp(START_Y, END_Y, timeRatio);

        Vector3 indicatorLoaction = new Vector3(indicatorX, indicatorY);

        taskIndicator.transform.localPosition = indicatorLoaction;
    }
}
