using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class EventManager : SingletonBehaviour<EventManager>
{

    public GameObject eventPopUpWindow;

    //miniGameList[0] => Bulb Catch
    //miniGameList[1] => correct button clicker
    //miniGameList[2] => 이지선다 퀴즈 미로
    //miniGameList[3] => 뒤집힌 카드 맞추기
    //miniGameList[4] => 파이프 게임
    public List<GameObject> miniGameList = new List<GameObject>();

    public int miniGameResult;
    public int eventResultIndex;

    public int choiceNum;

    //bulb catch
    public GameObject bulb;
    public Button buttonBulbCatch;

    public float bulbSpeed = 1000f;
    public float direction = 1f;

    public float[] bulbMiniGameScore = new float[3];

    public int bulbGameNum = 0;

    public bool isBulbGamePlaying = false;

    // Start is called before the first frame update
    void Start()
    {
        eventResultIndex = -1;

        //force event
        //exam
        for (int i = 0; i < 5; i++)
        {
            SetExam(i);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (bulb.transform.localPosition.x > 350f
            || bulb.transform.localPosition.x < -350f)
        {
            direction *= -1;
        }

        if (isBulbGamePlaying)
        {
            bulb.transform.Translate(Vector3.right * direction * bulbSpeed * Time.deltaTime);
        }
        else
        {
            bulbGameNum = 0;
        }

        if (!(ScheduleManager.Inst.doEvent))
        {
            eventResultIndex = -1;
        }
    }

    public void InsertEvent()
    {
        Task curTask = ScheduleManager.Inst.CurrentTask;

        if (curTask.taskEvent != null)
        {
            Debug.Log("this task already have event");

            //hundreds digit of event code
            int eventCode100 = ((curTask.taskEvent.eventCode / 10) / 10) % 10;

            if (eventCode100 != 0)
            {
                Debug.Log("but it was wrong event");

                curTask.taskEvent = null;
            }

            return;
        }

        GetEvent(curTask);
    }

    private void GetEvent(Task curTask)
    {
        string[] events = null;

        List<Event> selectedEvent = new List<Event>();

        //get events in each folder
        if (curTask is Study)
        {
            Debug.Log("this task is study");

            Study curStudy = curTask as Study;

            if (curStudy.studyType == Type.Major)
            {
                Debug.Log("this study is major");

                events = AssetDatabase.FindAssets("Event t:Event", new[] { "Assets/Resources/Events/Study/Major/General" });
            }
            else if (curStudy.studyType == Type.Discuss)
            {
                Debug.Log("this study is discuss");

                events = AssetDatabase.FindAssets("Event t:Event", new[] { "Assets/Resources/Events/Study/Discuss/General" });

            }
            else if (curStudy.studyType == Type.Sport)
            {
                Debug.Log("this study is sport");

                events = AssetDatabase.FindAssets("Event t:Event", new[] { "Assets/Resources/Events/Study/Sport/General" });

            }
            else
            {
                Debug.Log("error study type");
            }
        }
        else if (curTask is Club)
        {
            Debug.Log("this task is club");

            events = AssetDatabase.FindAssets("Event t:Event", new[] { "Assets/Resources/Events/Club/General" });

        }
        else if (curTask is Rest)
        {
            Debug.Log("this task is rest");

            events = AssetDatabase.FindAssets("Event t:Event", new[] { "Assets/Resources/Events/Rest/General" });

        }
        else
        {
            Debug.Log("error type");
        }


        if (events == null)
        {
            Debug.Log("events is null");

            return;
        }

        Debug.Log("length: " + events.Length);

        string[] eventPath = new string[events.Length];

        for (int i = 0; i < events.Length; i++)
        {
            //convert to path string
            eventPath[i] = AssetDatabase.GUIDToAssetPath(events[i]);

            Debug.Log("eventPath: " + eventPath[i]);

            //get event by probability
            Event tempEvent = (Event)AssetDatabase.LoadAssetAtPath(eventPath[i], typeof(Event));
            float randomVal = Random.value;

            if (randomVal <= tempEvent.eventProbability / 100)
            {
                selectedEvent.Add(tempEvent);
            }
        }

        int curWeek = ScheduleManager.Inst.currentWeek;
        int curPeriod = (int)ScheduleManager.Inst.currentPeriod;
        int curDay = (int)ScheduleManager.Inst.currentDay;

        //if no event selected
        if (selectedEvent.Count == 0)
        {
            Debug.Log("no event selected");

            return;
        }
        //if only one event selected
        else if (selectedEvent.Count == 1)
        {
            Debug.Log("one event selected");

            GameManager.Inst.player.schedules[curWeek].taskArray[curPeriod, curDay].taskEvent = selectedEvent[0];
        }
        //if more than one event selected
        else if (selectedEvent.Count > 1)
        {
            Debug.Log("several event selected");

            GameManager.Inst.player.schedules[curWeek].taskArray[curPeriod, curDay].taskEvent = selectedEvent[Random.Range(0, selectedEvent.Count)];

            Debug.Log("selected event: " + GameManager.Inst.player.schedules[curWeek].taskArray[curPeriod, curDay].taskEvent.eventCode);
        }
    }

    private void SetExam(int i)
    {
        bool isMidStudyFinded = false;
        bool isFinalStudyFinded = false;

        bool isMidExamSet = false;
        bool isFinalExamSet = false;

        for (int day = 0; day < 5; day++)
        {
            for (int period = 0; period < 6; period++)
            {
                //mid
                if (GameManager.Inst.studyResultArray[i].taskName
                .Equals(GameManager.Inst.player.schedules[0].taskArray[period, day].taskName))
                {
                    if (isMidStudyFinded && !isMidExamSet)
                    {
                        isMidExamSet = true;

                        Debug.Log("중간고사 설정됨 교시, 날짜 " + period + " " + day + " ");

                        GameManager.Inst.player.schedules[0].taskArray[period, day].taskEvent
                        = Resources.Load("Events/Study/Major/Enforce/Event1010") as Event;
                    }

                    isMidStudyFinded = true;

                    //Debug.Log("중간고사");
                }

                //final
                if (GameManager.Inst.studyResultArray[i].taskName
               .Equals(GameManager.Inst.player.schedules[15].taskArray[period, day].taskName))
                {
                    if (isFinalStudyFinded && !isFinalExamSet)
                    {
                        isFinalExamSet = true;

                        GameManager.Inst.player.schedules[15].taskArray[period, day].taskEvent
                        = Resources.Load("Events/Study/Major/Enforce/Event1020") as Event;
                    }

                    isFinalStudyFinded = true;
                }
            }
        }
    }

    public void ApplyEventEffect(string methodName)
    {
        Invoke(methodName, 0f);
    }

    //Event method

    private void MiniGameBulbCatch()
    {
        miniGameList[0].SetActive(true);

        direction = 1f;

        bulb.transform.localPosition = new Vector2(-350f, 424f);

        isBulbGamePlaying = true;

        if (bulbGameNum > 0)
        {
            return;
        }

        buttonBulbCatch.onClick.AddListener(() => OnBulbCatchGameButtonClick());
    }

    private void OnBulbCatchGameButtonClick()
    {
        bulbGameNum++;

        Debug.Log("bulbGameNum: " + bulbGameNum);

        if (bulbGameNum <= 3)
        {
            if (bulb.transform.localPosition.x >= -60 && bulb.transform.localPosition.x <= 60)
            {
                bulbMiniGameScore[bulbGameNum - 1] = 4f;
            }
            else if (bulb.transform.localPosition.x >= -160 && bulb.transform.localPosition.x <= 160)
            {
                bulbMiniGameScore[bulbGameNum - 1] = 2f;
            }
            else
            {
                bulbMiniGameScore[bulbGameNum - 1] = 0f;
            }

            if (bulbGameNum == 3)
            {
                isBulbGamePlaying = false;
                bulbGameNum = 0;

                float result = 0;

                for (int i = 0; i < 3; i++)
                {
                    result += bulbMiniGameScore[i];
                }

                if (result >= 10)
                {
                    miniGameResult = 0;
                }
                else if (result >= 8)
                {
                    miniGameResult = 1;
                }
                else
                {
                    miniGameResult = 2;
                }

                eventPopUpWindow.GetComponent<EventPopUp>().InitResult();

            }
        }

        if (bulbGameNum <= 2)
        {
            MiniGameBulbCatch();
        }
    }

    private void CheckEvent1010Result()
    {
        Debug.Log("CheckEvent1010Result");

        int result = -1;
        int favor = -1;

        float intelli = GameManager.Inst.player.playerCharacter.Intelli;

        Study curStudy = ScheduleManager.Inst.CurrentTask as Study;

        for (int i = 0; i < 5; i++)
        {
            if (curStudy.taskName.Equals(GameManager.Inst.studyResultArray[i].taskName))
            {
                favor = GameManager.Inst.studyResultArray[i].Favor;
            }
        }

        if ((favor >= 15 && intelli >= 130)
                || intelli >= 175)

        {
            result = 0;
        }
        else if ((favor >= 12 && intelli >= 115)
                        || intelli >= 155)
        {
            result = 1;
        }
        else
        {
            result = 2;
        }

        Debug.Log("1010 result: " + result);

        this.eventResultIndex = result;
    }

    private void CheckEvent1020Result()
    {
        int result = -1;
        int favor = -1;

        float intelli = GameManager.Inst.player.playerCharacter.Intelli;

        Study curStudy = ScheduleManager.Inst.CurrentTask as Study;

        for (int i = 0; i < 5; i++)
        {
            if (curStudy.taskName.Equals(GameManager.Inst.studyResultArray[i].taskName))
            {
                favor = GameManager.Inst.studyResultArray[i].Favor;
            }
        }

        if ((favor >= 50 && intelli >= 130)
                || intelli >= 175)

        {
            result = 0;
        }
        else if ((favor >= 42 && intelli >= 115)
                    || intelli >= 155)
        {
            result = 1;
        }
        else
        {
            result = 2;
        }
        
        this.eventResultIndex = result;
    }

    private void CheckEvent1170Result()
    {
        int result = -1;

        Study curStudy = ScheduleManager.Inst.CurrentTask as Study;
        int favor = curStudy.Favor;

        if(favor >= 25)
        {
            result = 0;
        }
        else
        {
            result = 1;
        }

        this.eventResultIndex = result;
    }

    private void CheckEvent1180Result()
    {
        Debug.Log("CheckEvent1180Result");

        int result = -1;

        Study curStudy = ScheduleManager.Inst.CurrentTask as Study;
        int favor = curStudy.Favor;

        Debug.Log(curStudy.taskName);

        if (favor >= 10)
        {
            result = 0;
        }
        else
        {
            result = 1;
        }

        if(result == 1)
        {
            for(int i = 0; i < 16; i++)
            {
                for(int j = 0; j < 6; j++)
                {
                    for(int k = 0; k < 5; k++)
                    {
                        if(GameManager.Inst.player.schedules[i].taskArray[j, k].taskName == curStudy.taskName)
                        {
                            GameManager.Inst.player.schedules[i].taskArray[j, k] = new Rest(((Period)j, (Day)k));
                        }
                    }
                }
            }
        }

        this.eventResultIndex = result;
    }

    private void CheckEvent1160Result()
    {
        int result = -1;

        float intelli = GameManager.Inst.player.playerCharacter.Intelli;
        float social = GameManager.Inst.player.playerCharacter.CurSocial;

        if (intelli >= 190 && 
            (social >= 130 && social <= 160))
        {
            result = 0;
        }
        else if (social > 160)
        {
            result = 1;
        }
        else if (social < 130)
        {
            result = 2;
        }
        else
        {
            result = 3;
        }

        this.eventResultIndex = result;
    }

    private void CheckEvent2012Result()
    {
        int result = -1;

        float stamina = GameManager.Inst.player.playerCharacter.CurStamina;
        float social = GameManager.Inst.player.playerCharacter.CurSocial;

        if (choiceNum == 0)
        {
            result = 0;

            if (stamina <= 150)
            {
                result = 1;
            }
        }
        else if (choiceNum == 1)
        {
            result = 2;

            if (social <= 130)
            {
                result = 3;
            }
        }

        this.eventResultIndex = result;
    }

    private void CheckEvent2020Result()
    {
        int result = -1;

        float intelli = GameManager.Inst.player.playerCharacter.Intelli;

        result = 1;

        if (intelli <= 110)
        {
            result = 0;
        }

        this.eventResultIndex = result;
    }

    private void CheckEvent2032Result()
    {
        int result = -1;

        float social = GameManager.Inst.player.playerCharacter.CurSocial;

        if (choiceNum == 0)
        {
            result = 1;

            if (social >= 120)
            {
                result = 0;
            }
            else if (social <= 90)
            {
                result = 2;
            }
        }
        else if (choiceNum == 1)
        {
            result = 4;

            if (social >= 150)
            {
                result = 3;
            }
        }

        this.eventResultIndex = result;
    }

    private void CheckEvent2110Result()
    {
        int result = -1;

        float stamina = GameManager.Inst.player.playerCharacter.CurStamina;
        float intelli = GameManager.Inst.player.playerCharacter.Intelli;

        result = 2;

        if (stamina <= 115)
        {
            result = 0;
        }
        else if (stamina >= 130 && intelli >= 150)
        {
            result = 1;
        }

        this.eventResultIndex = result;
    }

    private void CheckEvent2122Result()
    {
        int result = -1;

        float social = GameManager.Inst.player.playerCharacter.CurSocial;
        float stamina = GameManager.Inst.player.playerCharacter.CurStamina;

        if (choiceNum == 0)
        {
            result = 2;

            if (social >= 130 && stamina >= 120)
            {
                result = 0;
            }
            else if (stamina <= 115)
            {
                result = 1;
            }
        }
        else if (choiceNum == 1)
        {
            result = 4;

            if (stamina >= 155)
            {
                result = 3;
            }
        }

        this.eventResultIndex = result;
    }

    private void CheckEvent2130Result()
    {
        int result = -1;

        float social = GameManager.Inst.player.playerCharacter.CurSocial;

        result = 1;

        if (social >= 140)
        {
            result = 0;
        }

        this.eventResultIndex = result;
    }

    private void ChechEvent2140Result()
    {
        int result = -1;

        float social = GameManager.Inst.player.playerCharacter.CurSocial;

        result = 1;

        if (social <= 85)
        {
            result = 0;
        }

        this.eventResultIndex = result;
    }
}
