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

    private bool _choiced = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Init(Event _taskEvent)
    {
        Debug.Log("event popup init called");

        this.taskEvent = _taskEvent;

        this.textTitle.text = taskEvent.title;
        this.textMessage.text = taskEvent.message;
        this.imageSituation.sprite = taskEvent.situation;
        MakeChoiceButtons(taskEvent.choiceMessage);
    }

    public void MakeChoiceButtons(List<string> _choiceMessage)
    {
        int _choiceCount = _choiceMessage.Count;

        //delete all buttons in choiceArea
        foreach (Transform child in choiceArea.transform)
        {
            Destroy(child.gameObject);
        }

        //instantiate buttons in choiceArea
        //if 1 button -> then instantiate in (0,0)
        //if 2 buttons -> then instantiate in (-200, 0) and (200, 0)
        //change their inner text
        for (int i = 0; i < _choiceCount; i++)
        {
            GameObject _instance;
            GameObject _textChoiceButton;

            _instance = Instantiate(buttonChoice, choiceArea.transform);
            _textChoiceButton = _instance.transform.GetChild(0).gameObject;

            _instance.name = "ButtonChoice" + (i + 1);

            if (_choiceCount > 1)
            {
                _instance.transform.localPosition = new Vector2(-200 + 400 * i, 0);
            }

            _textChoiceButton.GetComponent<Text>().text = _choiceMessage[i];

            int tmp = i;
            _instance.GetComponent<Button>().onClick.AddListener(() => this.OnChoiceButtonClick(tmp));
    }
    }

    public void OnChoiceButtonClick(int _choiceIndex)
    {
        if (!_choiced)
        {
            List<string> _choiceMessage;
            _choiceMessage = new List<string> { "확인" };

            _choiced = true;

            //which choice player selected? = _choiceIndex
            //change character stat
            GameManager.Inst.player.playerCharacter.CurStamina += taskEvent.staminaVal[_choiceIndex];
            GameManager.Inst.player.playerCharacter.CurSocial += taskEvent.socialVal[_choiceIndex];

            //change textMessage, imageSituation
            this.textMessage.text = taskEvent.resultMessage[_choiceIndex];
            this.imageSituation.sprite = taskEvent.resultSituation[_choiceIndex];

            this.imageSituation.transform.localPosition = new Vector2(0, -135);

            //re-make choice buttons like this
            MakeChoiceButtons(_choiceMessage);
        }
        //if "확인" button clicked
        else
        {
            ScheduleManager.Inst.doEvent = false;
            Destroy(this.gameObject);
        }
    }
}
