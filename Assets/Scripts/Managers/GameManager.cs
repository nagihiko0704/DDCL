using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : SingletonBehaviour<GameManager>
{
    public Player player;
    public Schedule currentSchedule;
    public Task currentTask;

    public List<int> eventLog = new List<int>();
    public List<Task> taskLog = new List<Task>();

    private enum Day { Mon, Tue, Wed, Thu, Fri };
    private enum Period { First, Second, Third, Fourth, Fifth, Sixth };

    //for mentoring
    public Schedule mentorSchedule;

    // Start is called before the first frame update
    void Start()
    {
        player = new Player();

        initMentorSchedule();
        currentSchedule = player.schedules[0];
        currentTask = currentSchedule.taskArray[(int) Period.First, (int) Day.Mon];

        StartCoroutine(DoTask());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void initMentorSchedule()
    {
        Debug.Log("Init mentor schedule");

        mentorSchedule = new Schedule();

        //mon
        mentorSchedule.AddTask(new Study(((int)Period.First, (int)Day.Mon)));
        mentorSchedule.AddTask(new Study(((int)Period.Second, (int)Day.Mon)));
        mentorSchedule.AddTask(new Club(((int)Period.Third, (int)Day.Mon)));
        mentorSchedule.AddTask(new Study(((int)Period.Fourth, (int)Day.Mon)));

        //tue
        mentorSchedule.AddTask(new Study(((int)Period.Second, (int)Day.Tue)));
        mentorSchedule.AddTask(new Study(((int)Period.Third, (int)Day.Tue)));
        mentorSchedule.AddTask(new Club(((int)Period.Fifth, (int)Day.Tue)));
        mentorSchedule.AddTask(new Club(((int)Period.Sixth, (int)Day.Tue)));

        //wed
        mentorSchedule.AddTask(new Study(((int)Period.First, (int)Day.Wed)));
        mentorSchedule.AddTask(new Study(((int)Period.Second, (int)Day.Wed)));
        mentorSchedule.AddTask(new Club(((int)Period.Third, (int)Day.Wed)));
        mentorSchedule.AddTask(new Study(((int)Period.Fourth, (int)Day.Wed)));

        player.schedules[0] = mentorSchedule;
    }

    IEnumerator DoTask()
    {
        while(true)
        {
            int curTaskPeriod;
            int curTaskDay;

            int nextTaskPeriod;
            int nextTaskDay;

            curTaskPeriod = currentTask.scheduleLocation.Item1;
            curTaskDay = currentTask.scheduleLocation.Item2;

            nextTaskPeriod = (curTaskPeriod + 1) % 6;
            nextTaskDay = curTaskDay;
            if (curTaskPeriod == 5)
            {
                nextTaskDay = (curTaskDay + 1) % 5;
            }

            Debug.Log("Period: " + curTaskPeriod + " Day: " + curTaskDay);
            Debug.Log("task: " + currentTask);

            yield return new WaitForSeconds(3.0f);

            currentTask = currentSchedule.taskArray[nextTaskPeriod, nextTaskDay];            
            Debug.Log("Changed period:" + nextTaskPeriod + " Changed day: " + nextTaskDay);
            Debug.Log("---------");
        }
    }
}
