using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LectureList
{
    public Dictionary<string, List<Task>> lectureList = new Dictionary<string, List<Task>>();

    public LectureList()
    {
        this.lectureList.Add("S", new List<Task>());
        this.lectureList.Add("A", new List<Task>());
        this.lectureList.Add("B", new List<Task>());
        this.lectureList.Add("C", new List<Task>());


        //add lectures here: grade, new Study(name, type, grade)
        //s grade
        AddTaskByGrade("S", new Study("암벽 등반", Type.Sport, "S"));

        //a grade

        //b grade

        //c grade
    }

    public void AddTaskByGrade(string grade, Task task)
    {
        List<Task> tempTaskList = new List<Task>();

        this.lectureList[grade] = tempTaskList;
        tempTaskList.Add(task);

        this.lectureList[grade] = tempTaskList;
    }
}
