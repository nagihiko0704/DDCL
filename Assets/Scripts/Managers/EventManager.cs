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

        if(isBulbGamePlaying)
        {
            bulb.transform.Translate(Vector3.right * direction * bulbSpeed * Time.deltaTime);
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


        if(events == null)
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

            if(randomVal <= tempEvent.eventProbability / 100)
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
        else if(selectedEvent.Count == 1)
        {
            Debug.Log("one event selected");

            GameManager.Inst.player.schedules[curWeek].taskArray[curPeriod, curDay].taskEvent = selectedEvent[0];
        }
        //if more than one event selected
        else if(selectedEvent.Count > 1)
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

        for (int day = 0; day < 5; day++)
        {
            for (int period = 0; period < 5; period++)
            {
                //mid
                if (GameManager.Inst.studyResultArray[i].taskName
                .Equals(GameManager.Inst.player.schedules[7].taskArray[period, day].taskName))
                {
                    isMidStudyFinded = true;
                       
                    if(isMidStudyFinded)
                    {
                        GameManager.Inst.player.schedules[7].taskArray[period, day].taskEvent
                        = Resources.Load("Assets/Resources/Events/Study/Major/Enforce/Event1010.asset") as Event;
                    }
                }

                //final
                if (GameManager.Inst.studyResultArray[i].taskName
               .Equals(GameManager.Inst.player.schedules[15].taskArray[period, day].taskName))
                {
                    isFinalStudyFinded = true;

                    if (isFinalStudyFinded)
                    {
                        GameManager.Inst.player.schedules[15].taskArray[period, day].taskEvent
                        = Resources.Load("Assets/Resources/Events/Study/Major/Enforce/Event1020.asset") as Event;
                    }
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

        if(bulbGameNum > 0)
        {
            return;
        }

        buttonBulbCatch.onClick.AddListener(() => OnBulbCatchGameButtonClick());
    }

    private void OnBulbCatchGameButtonClick()
    {
        Debug.Log("bulbGameNum: " + bulbGameNum);

        if(bulbGameNum < 3)
        {
            if (bulb.transform.localPosition.x >= -60 && bulb.transform.localPosition.x <= 60)
            {
                bulbMiniGameScore[bulbGameNum] = 4f;
            }
            else if (bulb.transform.localPosition.x >= -160 && bulb.transform.localPosition.x <= 160)
            {
                bulbMiniGameScore[bulbGameNum] = 2f;
            }
            else
            {
                bulbMiniGameScore[bulbGameNum] = 0f;
            }

            if(bulbGameNum < 2)
            {
                MiniGameBulbCatch();
            }

            bulbGameNum++;
        }
        else
        {
            float result = 0;

            for(int i = 0; i < 3; i++)
            {
                result += bulbMiniGameScore[i];
            }

            if(result >= 10)
            {
                miniGameResult = 0;
            }
            else if(result >= 8)
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
}
