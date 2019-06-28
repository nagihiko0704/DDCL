using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Day { Mon, Tue, Wed, Thu, Fri };
public enum Period { First, Second, Third, Fourth, Fifth, Sixth };

public class GameManager : SingletonBehaviour<GameManager>
{
    public Player player;
    public Schedule currentSchedule;
    public Task currentTask;

    public List<int> eventLog = new List<int>();
    public List<Task> taskLog = new List<Task>();

    //for mentoring
    public Schedule mentorSchedule;

    void Awake()
    {
        player = new Player();

        InitMentorSchedule();
        currentSchedule = player.schedules[0];
        currentTask = currentSchedule.taskArray[(int) Period.First, (int) Day.Mon];

        StartCoroutine(DoTask());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

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

        //wed
        mentorSchedule.AddTask(new Study((Period.First, Day.Wed)));
        mentorSchedule.AddTask(new Study((Period.Second, Day.Wed)));
        mentorSchedule.AddTask(new Club((Period.Third, Day.Wed)));
        mentorSchedule.AddTask(new Study((Period.Fourth, Day.Wed)));

        player.schedules[0] = mentorSchedule;
    }

    IEnumerator DoTask()
    {
        while(true)
        {
            Period curTaskPeriod;
            Day curTaskDay;

            Period nextTaskPeriod;
            Day nextTaskDay;

            curTaskPeriod = currentTask.scheduleLocation.Item1;
            curTaskDay = currentTask.scheduleLocation.Item2;

            nextTaskPeriod = (Period)(((int)curTaskPeriod + 1) % 6);
            nextTaskDay = curTaskDay;
            if (curTaskPeriod == Period.Sixth)
            {
                nextTaskDay = (Day)(((int)curTaskDay + 1) % 5);
            }

            Debug.Log("Period: " + curTaskPeriod + " Day: " + curTaskDay);
            Debug.Log("task: " + currentTask);

            yield return new WaitForSeconds(3.0f);

            currentTask = currentSchedule.taskArray[(int)nextTaskPeriod, (int)nextTaskDay];            
            Debug.Log("Changed period:" + nextTaskPeriod + " Changed day: " + nextTaskDay);
            Debug.Log("---------");
        }
    }
}
