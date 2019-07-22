using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LectureList
{
	public Dictionary<string, List<Study>> lectureList = new Dictionary<string, List<Study>>();

	public LectureList()
	{
		this.lectureList.Add("S", new List<Study>());
		this.lectureList.Add("A", new List<Study>());
		this.lectureList.Add("B", new List<Study>());
		this.lectureList.Add("C", new List<Study>());

		

		//add lectures here: grade, new Study(name, type, grade)
		//s grade
		AddTaskByGrade("S", new Study("암벽 등반", Type.Sport, "S"));
        AddTaskByGrade("S", new Study("논리설계", Type.Major, "S"));
        AddTaskByGrade("S", new Study("현대 시의 탐구와 이해", Type.Discuss, "S"));


		//a grade
        AddTaskByGrade("A", new Study("컴퓨터 구조", Type.Major, "A"));
        AddTaskByGrade("A", new Study("회로 이론", Type.Major, "A"));
        AddTaskByGrade("A", new Study("자유는 정의와 진리를 싣고", Type.Discuss, "A"));
        AddTaskByGrade("A", new Study("소프트볼", Type.Sport, "A"));
        AddTaskByGrade("A", new Study("농구", Type.Sport, "A"));


		//b grade
        AddTaskByGrade("B", new Study("컴퓨터 프로그래밍", Type.Major, "B"));
        AddTaskByGrade("B", new Study("선형대수학", Type.Major, "B"));
        AddTaskByGrade("B", new Study("컴퓨터 네트워크", Type.Major, "B"));
        AddTaskByGrade("B", new Study("현대 철학 입문", Type.Discuss, "B"));
        AddTaskByGrade("B", new Study("연극 관람과 이해", Type.Discuss, "B"));
        AddTaskByGrade("B", new Study("축구", Type.Sport, "B"));


        //c grade
        AddTaskByGrade("C", new Study("데이터 통신", Type.Major, "C"));
        AddTaskByGrade("C", new Study("법학통론", Type.Discuss, "C"));
        AddTaskByGrade("C", new Study("스포츠 댄스", Type.Sport, "C"));
        AddTaskByGrade("C", new Study("피겨 댄스", Type.Sport, "C"));
	}
	
	public void AddTaskByGrade(string grade, Study study)
	{
		List<Study> tempTaskList = new List<Study>();

        tempTaskList=this.lectureList[grade];
		tempTaskList.Add(study);

		this.lectureList[grade] = tempTaskList;
	}
}