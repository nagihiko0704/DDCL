using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public enum Day { Mon, Tue, Wed, Thu, Fri };
public enum Period { First, Second, Third, Fourth, Fifth, Sixth };

public class ScheduleManager : SingletonBehaviour<ScheduleManager>
{
    public int currentWeek;
    public Period currentPeriod;
    public Day currentDay;

    public float curTime;

    public bool doEvent;

    public float TASK_TIME;

    //public List<Study> lectureList = new List<Study>();

    //for schedule form
    //public Schedule[] playerSchedule;
    public Study[] studyResult;

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
        TASK_TIME = GameManager.TASK_TIME;

        currentWeek = 0;
        currentPeriod = Period.First;
        currentDay = Day.Mon;

        curTime = 0;

        doEvent = false;

        DontDestroyOnLoad(this.gameObject);
    }

    // Update is called once per frame
    void Update()
    {   
        if(!doEvent)
        {
            curTime += Time.deltaTime;
        }
    }


    public void InitSchedule()
    {
        Debug.Log("스케쥴 설정됨");

        Schedule tempSchedule = new Schedule();

        studyResult = GameManager.Inst.studyResultArray;

        Debug.Log("type: " + studyResult[0].studyType);

        int randomNum = Random.Range(1, 5);
        switch(randomNum)
        {
            case (1):
                InitScheduleType1(tempSchedule);
                break;
            case (2):
                InitScheduleType2(tempSchedule);
                break;
            case (3):
                InitScheduleType3(tempSchedule);
                break;
            case (4):
                InitScheduleType4(tempSchedule);
                break;
        }

        for (int i = 0; i < 16; i++)
        {
            GameManager.Inst.player.schedules[i] = tempSchedule;
            GameManager.Inst.player.schedules[i].scheduleWeek = i + 1;
        }
    }
    
        

    private void InitScheduleType1(Schedule schedule)
    {
        //Mon
        schedule.AddTask(studyResult[0].Clone(), Period.First, Day.Mon);
        schedule.AddTask(studyResult[1].Clone(), Period.Second, Day.Mon);
        schedule.AddTask(new Club((Period.Third, Day.Mon)));
        schedule.AddTask(studyResult[2].Clone(), Period.Fourth, Day.Mon);

        //Tue
        schedule.AddTask(studyResult[2].Clone(), Period.Second, Day.Tue);
        schedule.AddTask(studyResult[2].Clone(), Period.Third, Day.Tue);
        schedule.AddTask(new Club((Period.Fifth, Day.Tue)));
        schedule.AddTask(new Club((Period.Sixth, Day.Tue)));

        //Wed
        schedule.AddTask(studyResult[0].Clone(), Period.First, Day.Wed);
        schedule.AddTask(studyResult[1].Clone(), Period.Second, Day.Wed);
        schedule.AddTask(studyResult[4].Clone(), Period.Fourth, Day.Wed);
        schedule.AddTask(new Club((Period.Fifth, Day.Wed)));

        //Thu
        schedule.AddTask(new Club((Period.Second, Day.Thu)));
        schedule.AddTask(studyResult[2].Clone(), Period.Third, Day.Thu);
        schedule.AddTask(studyResult[4].Clone(), Period.Fifth, Day.Thu);

        //Fri
        schedule.AddTask(studyResult[3].Clone(), Period.Second, Day.Fri);
        schedule.AddTask(studyResult[3].Clone(), Period.Third, Day.Fri);
        schedule.AddTask(new Club((Period.Fifth, Day.Fri)));
    }

    private void InitScheduleType2(Schedule schedule)
    {
        //Mon
        schedule.AddTask(studyResult[0].Clone(), Period.Second, Day.Mon);
        schedule.AddTask(studyResult[1].Clone(), Period.Third, Day.Mon);
        schedule.AddTask(new Club((Period.Fifth, Day.Mon)));
        schedule.AddTask(new Club((Period.Sixth, Day.Mon)));

        //Tue
        schedule.AddTask(studyResult[2].Clone(), Period.Fourth, Day.Tue);
        schedule.AddTask(studyResult[2].Clone(), Period.Third, Day.Tue);
        schedule.AddTask(new Club((Period.Sixth, Day.Tue)));

        //Wed
        

        //Thu
        schedule.AddTask(new Club((Period.Second, Day.Thu)));
        schedule.AddTask(studyResult[4].Clone(), Period.Fourth, Day.Thu);
        schedule.AddTask(studyResult[4].Clone(), Period.Fifth, Day.Thu);
        schedule.AddTask(new Club((Period.Sixth, Day.Thu)));

        //Fri
        schedule.AddTask(studyResult[0].Clone(), Period.Second, Day.Fri);
        schedule.AddTask(studyResult[1].Clone(), Period.Third, Day.Fri);
        schedule.AddTask(new Club((Period.Fourth, Day.Fri)));
        schedule.AddTask(studyResult[3].Clone(), Period.Fifth, Day.Fri);
        schedule.AddTask(studyResult[3].Clone(), Period.Sixth, Day.Fri);
    }

    private void InitScheduleType3(Schedule schedule)
    {
        //Mon
        schedule.AddTask(studyResult[0].Clone(), Period.Third, Day.Mon);
        schedule.AddTask(studyResult[1].Clone(), Period.Fourth, Day.Mon);
        schedule.AddTask(new Club((Period.Fifth, Day.Mon)));

        //Tue
        schedule.AddTask(studyResult[2].Clone(), Period.Second, Day.Tue);
        schedule.AddTask(new Club((Period.Fifth, Day.Tue)));
        schedule.AddTask(studyResult[4].Clone(), Period.Sixth, Day.Tue);

        //Wed
        schedule.AddTask(studyResult[0].Clone(), Period.Third, Day.Wed);
        schedule.AddTask(studyResult[1].Clone(), Period.Fourth, Day.Wed);
        schedule.AddTask(new Club((Period.Fifth, Day.Wed)));
        schedule.AddTask(new Club((Period.Sixth, Day.Wed)));

        //Thu
        schedule.AddTask(studyResult[2].Clone(), Period.Second, Day.Thu);
        schedule.AddTask(new Club((Period.Fifth, Day.Thu)));
        schedule.AddTask(studyResult[4].Clone(), Period.Sixth, Day.Thu);

        //Fri
        schedule.AddTask(studyResult[3].Clone(), Period.Fourth, Day.Fri);
        schedule.AddTask(studyResult[3].Clone(), Period.Fifth, Day.Fri);
        schedule.AddTask(new Club((Period.Sixth, Day.Fri)));
    }

    private void InitScheduleType4(Schedule schedule)
    {
        //Mon
        schedule.AddTask(new Club((Period.First, Day.Mon)));
        schedule.AddTask(new Club((Period.Second, Day.Mon)));
        schedule.AddTask(studyResult[2].Clone(), Period.Fifth, Day.Mon);

        //Tue
        schedule.AddTask(studyResult[0].Clone(), Period.Second, Day.Tue);
        schedule.AddTask(studyResult[1].Clone(), Period.Third, Day.Tue);
        schedule.AddTask(new Club((Period.Fifth, Day.Tue)));
        schedule.AddTask(studyResult[4].Clone(), Period.Sixth, Day.Tue);

        //Wed
        schedule.AddTask(studyResult[3].Clone(), Period.Fourth, Day.Wed);
        schedule.AddTask(studyResult[2].Clone(), Period.Fifth, Day.Wed);

        //Thu
        schedule.AddTask(studyResult[0].Clone(), Period.Second, Day.Thu);
        schedule.AddTask(studyResult[1].Clone(), Period.Third, Day.Thu);
        schedule.AddTask(new Club((Period.Fifth, Day.Thu)));
        schedule.AddTask(studyResult[4].Clone(), Period.Sixth, Day.Thu);

        //Fri
        schedule.AddTask(new Club((Period.First, Day.Fri)));
        schedule.AddTask(new Club((Period.Second, Day.Fri)));
        schedule.AddTask(studyResult[3].Clone(), Period.Fourth, Day.Fri);
    }


    public IEnumerator DoTask()
    {
        while (true)
        {
            Period nextTaskPeriod;
            Day nextTaskDay;
            int nextWeek;

            float recoverStamina;
                     
            nextTaskPeriod = (Period)(((int)currentPeriod + 1) % 6);
            nextTaskDay = currentDay;
            nextWeek = currentWeek;

            recoverStamina = 0;

            if (currentPeriod == Period.Sixth)
            {
                Debug.Log("day 바뀔 예정");

                nextTaskDay = (Day)(((int)currentDay + 1) % 5);

                recoverStamina = 10f;
            }

            if(currentDay == Day.Fri && currentPeriod == Period.Sixth)
            {
                Debug.Log("week 바뀔 예정");

                nextWeek = currentWeek + 1;
            }

            //Debug.Log("Period: " + currentPeriod + " Day: " + currentDay);
            //Debug.Log("task: " + CurrentTask);

            //apply stat change
            GameManager.Inst.player.playerCharacter.ChangeStat(CurrentTask);

            //insert event
            EventManager.Inst.InsertEvent();

            yield return new WaitForSeconds(TASK_TIME / 2);

            //Debug.Log("이벤트 시간");

            if (CurrentTask.taskEvent != null)
            {
                yield return StartCoroutine(DoEvent());
            }
            yield return new WaitForSeconds(TASK_TIME / 2);

            currentPeriod = nextTaskPeriod;
            currentDay = nextTaskDay;
            currentWeek = nextWeek;

            //if day passed, recover 10 stamina
            GameManager.Inst.player.playerCharacter.ChangeStat("stamina", recoverStamina);

            //Debug.Log("Changed period:" + nextTaskPeriod + " Changed day: " + nextTaskDay);
            //Debug.Log("---------");

            //plus favor
            if(CurrentTask is Study)
            {
                for(int i = 0; i< 5; i++)
                {
                    if (GameManager.Inst.studyResultArray[i].taskName.Equals(CurrentTask.taskName))
                    {
                        //Debug.Log("디용");

                        GameManager.Inst.studyResultArray[i].Favor++;
                        Debug.Log("study favor: " + GameManager.Inst.studyResultArray[i].Favor);
                        break;
                    }
                }
            }

            //for time correction
            curTime = Mathf.Floor(curTime);
        }
    }

    IEnumerator DoEvent()
    {
        Debug.Log("do event");

        Event _curEvent = CurrentTask.taskEvent;

        if(_curEvent == null)
        {
            Debug.Log("에러 병시나");
        }

        doEvent = true;

        MainGameUIManager.Inst.MakeEventPopUp(_curEvent);

        //if(_curEvent.methodName != null)
        //{
        //    EventManager.Inst.ApplyEventEffect(_curEvent.SelectedMethod);
        //}

        while (doEvent)
        {
            yield return null;
        }
    }
}
