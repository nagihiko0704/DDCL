using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventPopUp : MonoBehaviour
{
    public GameObject buttonChoice;

    public GameObject textTitle;
    public GameObject textMessage;
    public GameObject imageSituation;

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

    public void Init(Event _tastEvent)
    {
        //init with event's properties
    }

    public void MakeChoiceButtons(List<string> _choiceMessage)
    {
        //delete all buttons in choiceArea

        //instantiate buttons in choiceArea
        //if 1 button -> then instantiate in (0,0)
        //if 2 buttons -> then instantiate in (-200, 0) and (200, 0)
        //change their inner text
    }

    public void OnChoiceButtonClick(int _choiceIndex)
    {
        if (!_choiced)
        {
            List<string> _choiceMessage;
            _choiceMessage = new List<string> { "확인" };

            _choiced = true;

            //which choice player selected?
            //change character stat
            //change textMessage, imageSituation

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
