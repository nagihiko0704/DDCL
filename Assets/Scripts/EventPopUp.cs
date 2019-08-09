using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EventPopUp : MonoBehaviour
{
    public Event taskEvent;

    public GameObject buttonChoice;

    public Text textTitle;
    public Text textMessage;
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

        this.taskEvent = _taskEvent;

        this.textTitle.text = taskEvent.SelectedTitle;
        this.textMessage.text = taskEvent.SelectedMessage;
        this.imageSituation.sprite = taskEvent.SelectedSituation;
        MakeChoiceButtons(taskEvent.choiceMessage);
    }

    public void MakeChoiceButtons(List<string> _choiceMessage)
    {
        //delete all buttons in choiceArea
        foreach (Transform child in choiceArea.transform)
        {
            Destroy(child.gameObject);
        }

        //instantiate buttons in choiceArea
        //if 1 button -> then instantiate in (0,0)
        //if 2 buttons -> then instantiate in (-200, 0) and (200, 0)
        //change their inner text
        for (int i = 0; i < 2; i++)
        {
            GameObject _instance;
            GameObject _textChoiceButton;

            _instance = Instantiate(buttonChoice, choiceArea.transform);
            _textChoiceButton = _instance.transform.GetChild(0).gameObject;

            _instance.name = "ButtonChoice" + (i + 1);


            //if event is select form
            if (taskEvent.eventCode % 10 == 2)
            {
                _instance.transform.localPosition = new Vector2(-200 + 400 * i, 0);
            }

            _textChoiceButton.GetComponent<Text>().text = _choiceMessage[taskEvent.SelectedInt * 2 + i];

            _instance.GetComponent<Button>().onClick.AddListener(() => this.OnChoiceButtonClick(taskEvent.SelectedInt * 2 + i));
    }
    }

    public void OnChoiceButtonClick(int _choiceIndex)
    {
        //which choice player selected? = _choiceIndex
        //change character stat
        GameManager.Inst.player.playerCharacter
        GameManager.Inst.player.playerCharacter.CurStamina += taskEvent.staminaVal[_choiceIndex];
        GameManager.Inst.player.playerCharacter.CurSocial += taskEvent.socialVal[_choiceIndex];

        //change textMessage, imageSituation
        this.textMessage.text = taskEvent.resultMessage[_choiceIndex];
        this.imageSituation.sprite = taskEvent.resultSituation[_choiceIndex];

        this.imageSituation.transform.localPosition = new Vector2(0, -135);

        //if this event is notice or select form
        if(this.taskEvent.eventCode % 10 == 0 
            || this.taskEvent.eventCode % 10 == 2)
        {
            InitResult();
        }
        //if this event is minigame
        else if(this.taskEvent.eventCode % 10 == 1)
        {
            InitMiniGame();
        }


        //ScheduleManager.Inst.doEvent = false;
        //Destroy(this.gameObject);
        
    }

    public void InitMiniGame()
    {
        Debug.Log("event popup InitMiniGame called");

        situationWindow.SetActive(false);
        miniGameWindow.SetActive(true);
        resultWindow.SetActive(false);
    }

    public void InitResult()
    {
        string resultText = "";

        situationWindow.SetActive(true);
        miniGameWindow.SetActive(false);
        resultWindow.SetActive(true);


        //make result text about each value
        if(taskEvent.intelliMaxVal.Count > 0 && taskEvent.IntelliVal != 0)
        {
            resultText += "지능 ";

            MakeStatString(resultText, taskEvent.IntelliVal);
        }

        if(taskEvent.fassionVal.Count > 0 && taskEvent.FassionVal != 0)
        {
            resultText += "열정 ";

            MakeStatString(resultText, taskEvent.fassionVal[taskEvent.SelectedInt]);
        }

        if(taskEvent.staminaVal.Count > 0 && taskEvent.StaminaVal != 0)
        {
            resultText += "체력 ";

            MakeStatString(resultText, taskEvent.StaminaVal);
        }

        if(taskEvent.socialVal.Count > 0 && taskEvent.SocialVal != 0)
        {
            resultText += "친화력 ";

            MakeStatString(resultText, taskEvent.SocialVal);
        }

        if(taskEvent.favorVal.Count > 0 && taskEvent.FavorVal != 0)
        {
            resultText += "강의 호감도 ";

            MakeStatString(resultText, taskEvent.FavorVal);
        }

        resultWindow.GetComponentInChildren<Text>().text = resultText;

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

    public void MakeStatString(string _str, float _stat)
    {
        if(_stat >= 0)
        {
            _str += "+";
        }
        else
        {
            _str += "-";
        }

        _str = _str + _stat + "\n";
    }

    public void OnOkayButtonClick()
    {
        eventPopUpWindow.SetActive(false);
    }
}
