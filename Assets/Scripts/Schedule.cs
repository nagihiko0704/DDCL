using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Schedule
{
    //Schedule has tasks and nth week num
    public Task[,] taskArray = new Task[6, 5];
    public int scheduleWeek;

    public Schedule()
    {
        scheduleWeek = 1;
        
        //intiate with rest task
        for(int row = 0; row < 6; row++)
        {
            for(int col = 0; col < 5; col++)
            {
                this.taskArray[row, col] = new Rest(((Period)row, (Day)col));
            }
        }
    }

    public void AddTask(Player player, Task taskType)
    {
        Period period = taskType.scheduleLocation.Item1;
        Day day = taskType.scheduleLocation.Item2;

        for(int week = 1; week <= 16; week++)
        {
            taskType.scheduleLocation = (period, day);
            player.schedules[week - 1].taskArray[(int)period, (int)day] = taskType;
            player.schedules[week - 1].scheduleWeek = week;
        }
    }

    public void AddTask(Schedule schedule, Task taskType)
    {
        Period period = taskType.scheduleLocation.Item1;
        Day day = taskType.scheduleLocation.Item2;

        taskType.scheduleLocation = (period, day);
        schedule.taskArray[(int)period, (int)day] = taskType;
    }

    public void AddTask(Task taskType)
    {
        Period period = taskType.scheduleLocation.Item1;
        Day day = taskType.scheduleLocation.Item2;

        taskType.scheduleLocation = (period, day);
        this.taskArray[(int)period, (int)day] = taskType;
    }

    public void AddTask(Task taskType, Period period, Day day)
    {
        if(taskType == null)
        {
            Debug.Log("에러 병시나");
        }

        taskType.scheduleLocation = (period, day);
        this.taskArray[(int)period, (int)day] = taskType;
    }
}
