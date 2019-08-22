﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : SingletonBehaviour<GameManager>
{
    public Player player;

    //for acheivement
    public List<(int, int)> eventLog = new List<(int, int)>();
    public List<Task> taskLog = new List<Task>();
    public bool[] acheivemnet = new bool[10];

    //for lecture choice score
    public static int[] lectureChoiceScore = new int[5];
    
    //for lecture Application score
    public static int[] lectureApplicationScore = new int[5];

    //for lecture supplement scene, schedule manager
    public Study[] studyResultArray = new Study[5];

    public int[] lectureCredit = new int[5];
    //public LectureList lectureList = new LectureList();

    public const float TASK_TIME = 4f;

    public bool isMainSceneStart = false;

    public bool isSemesterEnd = false;

    void Awake()
    {
        player = new Player();

        DontDestroyOnLoad(this.gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        if(isMainSceneStart)
        {
            Debug.Log("메인 게임 시작");

            StartCoroutine(ScheduleManager.Inst.DoTask());
            ScheduleManager.Inst.curTime = 0;

            isMainSceneStart = false;
        }
    }
}
