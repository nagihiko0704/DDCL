using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Day { Mon, Tue, Wed, Thu, Fri };
public enum Period { First, Second, Third, Fourth, Fifth, Sixth };

public class ScheduleManager : SingletonBehaviour<ScheduleManager>
{
    public int currentWeek = 0;
    public Period currentPeriod = Period.First;
    public Day currentDay = Day.Mon;

    public float curTime = 0;

    public bool doEvent = false;

    public float TASK_TIME;

    public List<Task> lectureList = new List<Task>();

    //for mentoring
    public Schedule mentorSchedule;
    public Event firstEvent;
    public Event secondEvent;

    public Schedule CurrentSchedule
    {
        get { return GameManager.Inst.player.schedules[currentWeek]; }
    }
    public Task CurrentTask
    {
        get { return CurrentSchedule.taskArray[(int)currentPeriod, (int)currentDay]; }
    }

    // Start is called before the first frame update
    void Start()
    {
        TASK_TIME = GameManager.TASK_TIME;

        for(int i = 0; i < 5; i++)
        {
            lectureList[i] = null;
        }

        //InitMentorSchedule();
        StartCoroutine(DoTask());
    }

    // Update is called once per frame
    void Update()
    {   
        if(!doEvent)
        {
            float tempTime = Time.deltaTime;
            curTime += tempTime;
        }
    }

    //for mentoring
    //void InitMentorSchedule()
    //{
    //    Debug.Log("Init mentor schedule");

    //    mentorSchedule = new Schedule();

    //    //mon
    //    mentorSchedule.AddTask(new Study((Period.First, Day.Mon)));
    //    mentorSchedule.AddTask(new Study((Period.Second, Day.Mon)));
    //    mentorSchedule.AddTask(new Club((Period.Third, Day.Mon)));
    //    mentorSchedule.AddTask(new Study((Period.Fourth, Day.Mon), firstEvent));

    //    //tue
    //    mentorSchedule.AddTask(new Study((Period.Second, Day.Tue)));
    //    mentorSchedule.AddTask(new Study((Period.Third, Day.Tue)));
    //    mentorSchedule.AddTask(new Club((Period.Fifth, Day.Tue)));
    //    mentorSchedule.AddTask(new Club((Period.Sixth, Day.Tue), secondEvent));

    //    GameManager.Inst.player.schedules[0] = mentorSchedule;
    //}

    private void InitSchedule()
    {

    }

    private void InitScheduleType1()
    {

    }

    private void GetLecture(int lectureNum)
    {
        int lectureScore = GameManager.Inst.lectureScore[lectureNum];
        string lectureGrade = null;
        Task lecture;

        if(lectureScore >= 20)
        {
            lectureGrade = "S";
        }
        else if(lectureScore >= 17 && lectureScore < 20)
        {
            lectureGrade = "A";
        }
        else if(lectureScore >= 11 && lectureScore < 17)
        {
            lectureGrade = "B";
        }
        else if(lectureScore < 11)
        {
            lectureGrade = "C";
        }


        List<Study> taskList = GameManager.Inst.lectureList.lectureList[lectureGrade];

        lecture = taskList[Random.Range(0, 6)];

        if(lectureList.Contains(lecture))
        {
            GetLecture(lectureNum);
            return;
        }

        lectureList.Add(lecture);
    }

    IEnumerator DoTask()
    {
        while (true)
        {
            Period nextTaskPeriod;
            Day nextTaskDay;
                     
            nextTaskPeriod = (Period)(((int)currentPeriod + 1) % 6);
            nextTaskDay = currentDay;
            if (currentPeriod == Period.Sixth)
            {
                nextTaskDay = (Day)(((int)currentDay + 1) % 5);
            }

            Debug.Log("Period: " + currentPeriod + " Day: " + currentDay);
            Debug.Log("task: " + CurrentTask);

            yield return new WaitForSeconds(TASK_TIME / 2);
            if (CurrentTask.taskEvent != null)
            {
                yield return StartCoroutine(DoEvent());
            }
            yield return new WaitForSeconds(TASK_TIME / 2);

            currentPeriod = nextTaskPeriod;
            currentDay = nextTaskDay;
            Debug.Log("Changed period:" + nextTaskPeriod + " Changed day: " + nextTaskDay);
            Debug.Log("---------");
        }
    }

    IEnumerator DoEvent()
    {
        Event _curEvent = CurrentTask.taskEvent;

        doEvent = true;

        MainGameUIManager.Inst.MakeEventPopUp(_curEvent);

        while (doEvent)
        {
            yield return null;
        }
    }
}
