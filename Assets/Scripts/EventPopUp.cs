using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EventPopUp : MonoBehaviour
{
    public Event taskEvent;

    public GameObject buttonChoice;

    public Text textTitle;
    public Text textMessage;
    public Text textResultMessage;

    public Image imageSituation;

    public GameObject choiceArea;

    public GameObject resultWindow;
    public GameObject miniGameWindow;
    public GameObject situationWindow;

    public GameObject eventPopUpWindow;

    private int _choiceIndexNum;

    // Start is called before the first frame update
    void Start()
    {
        resultWindow.SetActive(false);
        miniGameWindow.SetActive(false);
        situationWindow.SetActive(true);
        choiceArea.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void InitSituation(Event _taskEvent)
    {
        Debug.Log("event popup InitSituation called");

        situationWindow.SetActive(true);
        miniGameWindow.SetActive(false);
        resultWindow.SetActive(false);
        choiceArea.SetActive(true);

        this.taskEvent = _taskEvent;

        this.textTitle.text = taskEvent.SelectedTitle;
        this.textMessage.text = taskEvent.SelectedMessage;
        this.imageSituation.sprite = taskEvent.SelectedSituation;

        Debug.Log("랜덤 인트:" + taskEvent.SelectedInt);

        MakeChoiceButtons(taskEvent.choiceMessage);
    }

    public void MakeChoiceButtons(List<string> _choiceMessage)
    {
        int choiceNum = taskEvent.choiceMessage.Count / taskEvent.title.Count;

        //delete all buttons in choiceArea
        foreach (Transform child in choiceArea.transform)
        {
            Destroy(child.gameObject);
        }

        //instantiate buttons in choiceArea
        //if 1 button -> then instantiate in (0,0)
        //if 2 buttons -> then instantiate in (-200, 0) and (200, 0)
        //change their inner text
        for (int i = 0; i < choiceNum; i++)
        {
            Debug.Log("taskEvent.SelectedInt * 2 + i    " + (taskEvent.SelectedInt * 2 + i));

            GameObject _instance;
            GameObject _textChoiceButton;

            int choiceButtonNum = taskEvent.SelectedInt * 2 + i;

            _instance = Instantiate(buttonChoice, choiceArea.transform);
            _textChoiceButton = _instance.transform.GetChild(0).gameObject;

            _instance.name = "ButtonChoice" + (i + 1);


            //if event is select form
            if (taskEvent.eventCode % 10 == 2)
            {
                _instance.transform.localPosition = new Vector2(-200 + 400 * i, 0);
            }

            _textChoiceButton.GetComponent<Text>().text = _choiceMessage[choiceButtonNum];

            _instance.GetComponent<Button>().onClick.AddListener(() => OnChoiceButtonClick(choiceButtonNum));
        }
    }

    public void OnChoiceButtonClick(int _choiceIndex)
    {
        this._choiceIndexNum = _choiceIndex;
        Debug.Log("choice index num: " + _choiceIndexNum);

        //which choice player selected? = _choiceIndex
        //change character stat
        //GameManager.Inst.player.playerCharacter.CurFassion += taskEvent.fassionVal[_choiceIndex];
        //GameManager.Inst.player.playerCharacter.CurStamina += taskEvent.staminaVal[_choiceIndex];
        //GameManager.Inst.player.playerCharacter.CurSocial += taskEvent.socialVal[_choiceIndex];


        //if this event is notice or select form
        if(this.taskEvent.eventCode % 10 == 0 
            || this.taskEvent.eventCode % 10 == 2)
        {
            InitResult();
        }
        //if this event is minigame
        else if(this.taskEvent.eventCode % 10 == 1)
        {
            InitMiniGameExplanation();
        }       
    }

    public void InitMiniGameExplanation()
    {
        situationWindow.SetActive(true);
        miniGameWindow.SetActive(false);
        resultWindow.SetActive(false);
        choiceArea.SetActive(true);

        this.textMessage.text = taskEvent.minigameExplanation[0];
        this.textMessage.fontSize = 40;
        this.imageSituation.sprite = taskEvent.minigameExplanationImage[0];

        //next button for starting minigame
        foreach (Transform child in choiceArea.transform)
        {
            Destroy(child.gameObject);
        }

        GameObject _instance;
        GameObject _textChoiceButton;

        _instance = Instantiate(buttonChoice, choiceArea.transform);
        _textChoiceButton = _instance.transform.GetChild(0).gameObject;

        _instance.name = "ButtonOkay";

        _textChoiceButton.GetComponent<Text>().text = "확인";

        _instance.GetComponent<Button>().onClick.AddListener(() => InitMiniGame());
    }



    public void InitMiniGame()
    {
        Debug.Log("event popup InitMiniGame called");

        choiceArea.SetActive(false);
        situationWindow.SetActive(false);
        miniGameWindow.SetActive(true);
        resultWindow.SetActive(false);

        if (taskEvent.methodName != null)
        {
            EventManager.Inst.ApplyEventEffect(taskEvent.methodName[0]);
        }
    }

    public void InitResult()
    {
        Debug.Log("Init Result");

        string resultText = "";

        int resultIndex = -1;

        float eventResultNum = ScheduleManager.Inst.CurrentTask.taskEvent.resultMessage.Count;
        float eventChoiceNum = ScheduleManager.Inst.CurrentTask.taskEvent.choiceMessage.Count;

        situationWindow.SetActive(true);
        miniGameWindow.SetActive(false);
        resultWindow.SetActive(true);
        choiceArea.SetActive(true);


        //make result text about each value
        MakeStatString(ref resultText);

        Debug.Log(resultText);

        textResultMessage.text = resultText;

        //determine result
        if(eventResultNum / eventChoiceNum > 1
            && ScheduleManager.Inst.CurrentTask.taskEvent.methodName[0] != "")
        {
            //if event is not minigame type, method num must be one
            EventManager.Inst.ApplyEventEffect(ScheduleManager.Inst.CurrentTask.taskEvent.methodName[0]);
            resultIndex = EventManager.Inst.eventResultIndex;

            Debug.Log("결과 받아옴");
        }
        //if special result condition is not exist
        else
        {
            resultIndex = _choiceIndexNum;
        }

        Debug.Log("resultIndex: " + resultIndex);

        if(this.taskEvent.eventCode % 10 == 0
            || this.taskEvent.eventCode % 10 == 2)
        {
            textMessage.GetComponent<Text>().text = taskEvent.resultMessage[resultIndex];
        }
        else if(this.taskEvent.eventCode % 10 == 1)
        {
            textMessage.GetComponent<Text>().text = taskEvent.resultMessage[EventManager.Inst.miniGameResult];
        }
        
        //make okay button
        foreach (Transform child in choiceArea.transform)
        {
            Destroy(child.gameObject);
        }

        GameObject _instance;
        GameObject _textChoiceButton;

        _instance = Instantiate(buttonChoice, choiceArea.transform);
        _textChoiceButton = _instance.transform.GetChild(0).gameObject;

        _instance.name = "ButtonOkay";

        _textChoiceButton.GetComponent<Text>().text = "확인";

        _instance.GetComponent<Button>().onClick.AddListener(() => this.OnOkayButtonClick());
    }

    public void MakeStatString(ref string _str)
    {
        Debug.Log("했냐?");

        int index = 0;

        if (this.taskEvent.eventCode % 10 == 0
            || this.taskEvent.eventCode % 10 == 2)
        {
            index = _choiceIndexNum;
        }
        else if (this.taskEvent.eventCode % 10 == 1)
        {
            index = EventManager.Inst.miniGameResult;
        }

        //value
        if (taskEvent.fassionVal.Count > 0 && taskEvent.fassionVal[index] != 0)
        {

            _str += "열정 ";

            MakeStatNumtoString(ref _str, taskEvent.fassionVal[index]);
        }

        if (taskEvent.staminaVal.Count > 0 && taskEvent.staminaVal[index] != 0)
        {
            _str += "체력 ";

            MakeStatNumtoString(ref _str, taskEvent.staminaVal[index]);
        }

        if (taskEvent.socialVal.Count > 0 && taskEvent.socialVal[index] != 0)
        {
            _str += "친화력 ";

            MakeStatNumtoString(ref _str, taskEvent.socialVal[index]);
        }

        if (taskEvent.favorVal.Count > 0 && taskEvent.favorVal[index] != 0)
        {
            _str += "강의 호감도 ";

            MakeStatNumtoString(ref _str, taskEvent.favorVal[index]);
        }

        //max value
        if (taskEvent.intelliMaxVal.Count > 0 && taskEvent.intelliMaxVal[index] != 0)
        {
            _str += "MAX 지능 ";

            MakeStatNumtoString(ref _str, taskEvent.intelliMaxVal[index]);
        }

        if (taskEvent.fassionMaxVal.Count > 0 && taskEvent.fassionMaxVal[index] != 0)
        {
            _str += "MAX 열정 ";

            MakeStatNumtoString(ref _str, taskEvent.fassionMaxVal[index]);
        }

        if (taskEvent.staminaMaxVal.Count > 0 && taskEvent.staminaMaxVal[index] != 0)
        {
            _str += "MAX 체력 ";

            MakeStatNumtoString(ref _str, taskEvent.staminaMaxVal[index]);
        }

        if (taskEvent.socialMaxVal.Count > 0 && taskEvent.socialMaxVal[index] != 0)
        {
            _str += "MAX 친화력 ";

            MakeStatNumtoString(ref _str, taskEvent.socialMaxVal[index]);
        }
    }


    public void MakeStatNumtoString(ref string _str, float _stat)
    {
        if(_stat >= 0)
        {
            _str += "+";
        }

        _str = _str + _stat + "\n\n";
    }

    public void OnOkayButtonClick()
    {
        eventPopUpWindow.SetActive(false);
        ScheduleManager.Inst.doEvent = false;
    }
}
