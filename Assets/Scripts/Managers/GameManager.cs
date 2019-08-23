using System.Collections;
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

    public bool isEndingSix = false;

    void Awake()
    {
        player = new Player();

        DontDestroyOnLoad(this.gameObject);

        //acheivement
        for(int i = 0; i < 10; i++)
        {
            acheivemnet[i] = false;
        }
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

        CheckAcheivement();
    }

    private void CheckAcheivement()
    {
        if (eventLog.Contains((3120, 1)))
        {
            acheivemnet[0] = true;
        }

        if (eventLog.Contains((3120, 2)))
        {
            acheivemnet[1] = true;
        }

        if (eventLog.Contains((3130, 2)))
        {
            acheivemnet[2] = true;
        }

        if(eventLog.Contains((1180, 1)))
        {
            acheivemnet[3] = true;
        }

        if(eventLog.Contains((1170, 0)))
        {
            acheivemnet[4] = true;
        }
        for(int i = 0; i < 3; i++)
        {
            if (eventLog.Contains((3170, i)))
            {
                acheivemnet[5] = true;
            }
        }

        if (eventLog.Contains((3142, 0)))
        {
            acheivemnet[6] = true;
        }

        if(eventLog.Contains((3192, 0)))
        {
            acheivemnet[7] = true;
        }
        for (int i = 0; i < 2; i++)
        {
            if (eventLog.Contains((2032, i)))
            {
                acheivemnet[8] = true;
            }
        }
        
        if(eventLog.Contains((2140, 1)))
        {
            acheivemnet[9] = true;
        }
       
    }
}