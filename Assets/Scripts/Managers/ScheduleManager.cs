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

    public List<int> eventLog = new List<int>();
    public List<Task> taskLog = new List<Task>();

    //for mentoring
    public Schedule mentorSchedule;

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
        InitMentorSchedule();
        StartCoroutine(DoTask());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //for mentoring
    void InitMentorSchedule()
    {
        Debug.Log("Init mentor schedule");

        mentorSchedule = new Schedule();

        //mon
        mentorSchedule.AddTask(new Study((Period.First, Day.Mon)));
        mentorSchedule.AddTask(new Study((Period.Second, Day.Mon)));
        mentorSchedule.AddTask(new Club((Period.Third, Day.Mon)));
        mentorSchedule.AddTask(new Study((Period.Fourth, Day.Mon)));

        //tue
        mentorSchedule.AddTask(new Study((Period.Second, Day.Tue)));
        mentorSchedule.AddTask(new Study((Period.Third, Day.Tue)));
        mentorSchedule.AddTask(new Club((Period.Fifth, Day.Tue)));
        mentorSchedule.AddTask(new Club((Period.Sixth, Day.Tue)));

        GameManager.Inst.player.schedules[0] = mentorSchedule;
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

            yield return new WaitForSeconds(3.0f);
            if (CurrentTask.taskEvent != null)
            {
                yield return StartCoroutine(DoEvent());
            }
            yield return new WaitForSeconds(3.0f);

            currentPeriod = nextTaskPeriod;
            currentDay = nextTaskDay;
            Debug.Log("Changed period:" + nextTaskPeriod + " Changed day: " + nextTaskDay);
            Debug.Log("---------");
        }
    }

    IEnumerator DoEvent()
    {
        Event _curEvent = CurrentTask.taskEvent;

        //do event
        //TODO: learn coroutine
        //1. show event pop-up UI (with MainGameUIManager)
        //2. if button click -> then change character stat & show event result pop-up UI
        //3. if button click -> then close & end this function

        yield return null;
    }
}
