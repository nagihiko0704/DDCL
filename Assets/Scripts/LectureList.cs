using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LectureList
{
    public Dictionary<string, List<Task>> lectureList = new Dictionary<string, List<Task>>();

    public LectureList()
    {



        this.lectureList.Add("S01", new Study("암벽등반", Type.Sport, "S"));
        this.lectureList.Add("S02", new Study("논리설계", Type.Major, "S"));
        this.lectureList.Add("S03", new Study("현대 시의 탐구와 이해", Type.Discuss, "S"));

        this.lectureList.Add("A01", new Study("컴퓨터 구조", Type.Major, "A"));
        this.lectureList.Add("A02", new Study("회로 이론", Type.Major, "A"));
        this.lectureList.Add("A03", new Study("자유는 정의와 진리를 싣고", Type.Discuss, "A"));
        this.lectureList.Add("A04", new Study("소프트볼", Type.Sport, "A"));
        this.lectureList.Add("A05", new Study("농구", Type.Sport, "A"));

        this.lectureList.Add("B01", new Study("컴퓨터 프로그래밍", Type.Major, "B"));
        this.lectureList.Add("B02", new Study("선형대수학", Type.Major, "B"));
        this.lectureList.Add("B03", new Study("컴퓨터 네트워크", Type.Major, "B"));
        this.lectureList.Add("B04", new Study("현대 철학 입문", Type.Discuss, "B"));
        this.lectureList.Add("B05", new Study("연극 관람과 이해", Type.Discuss, "B"));
        this.lectureList.Add("B06", new Study("축구", Type.Sport, "B"));

        this.lectureList.Add("C01", new Study("데이터 통신", Type.Major, "C"));
        this.lectureList.Add("C02", new Study("법학통론", Type.Discuss, "C"));
        this.lectureList.Add("C03", new Study("스포츠 댄스", Type.Sport, "C"));
        this.lectureList.Add("C04", new Study("피겨 댄스", Type.Sport, "C"));
        
    }

    }

