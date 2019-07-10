using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LectureList
{
    public Dictionary<string, Task> lectureList = new Dictionary<string, Task>();

    public LectureList()
    {
        //add lecture list: name, type, grade

        this.lectureList.Add("S", new Study("암벽등반", Type.Sport, "S"));
        this.lectureList.Add("S", new Study("논리설계", Type.Major, "S"));
        this.lectureList.Add("S", new Study("현대 시의 탐구와 이해", Type.Discuss, "S"));

        this.lectureList.Add("A", new Study("컴퓨터 구조", Type.Major, "A"));
        this.lectureList.Add("A", new Study("회로 이론", Type.Major, "A"));
        this.lectureList.Add("A", new Study("자유는 정의와 진리를 싣고", Type.Discuss, "A"));
        this.lectureList.Add("A", new Study("소프트볼", Type.Sport, "A"));
        this.lectureList.Add("A", new Study("농구", Type.Sport, "A"));

        this.lectureList.Add("B", new Study("컴퓨터 프로그래밍", Type.Major, "B"));
        this.lectureList.Add("B", new Study("선형대수학", Type.Major, "B"));
        this.lectureList.Add("B", new Study("컴퓨터 네트워크", Type.Major, "B"));
        this.lectureList.Add("B", new Study("현대 철학 입문", Type.Discuss, "B"));
        this.lectureList.Add("B", new Study("연극 관람과 이해", Type.Discuss, "B"));
        this.lectureList.Add("B", new Study("축구", Type.Sport, "B"));

        this.lectureList.Add("C", new Study("데이터 통신", Type.Major, "C"));
        this.lectureList.Add("C", new Study("법학통론", Type.Discuss, "C"));
        this.lectureList.Add("C", new Study("스포츠 댄스", Type.Sport, "C"));
        this.lectureList.Add("C", new Study("피겨 댄스", Type.Sport, "C"));
    }
}
