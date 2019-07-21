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

    public Schedule playerSchedule;

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


    private void InitSchedule()
    {

    }

    private void InitScheduleType1()
    {

    }

    private void InitScheduleType2()
    {

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
