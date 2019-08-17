using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class NewCharacterManager : MonoBehaviour
{
    public GameObject[] clickArea = new GameObject[2];//0:left 1:right
    public GameObject choiceCharacter;
    /**
     * 0:none
     * 1:freshmen
     **/
    
    public Sprite[] characterSprite = new Sprite[2];
    public Sprite[] characterExplain = new Sprite[2];

    public GameObject explainChoiceButton;
    public GameObject explainImage;

    public GameObject panel;
    public GameObject panelYes;
    public GameObject panelNo;

    private int _nowChracter;
    private int _maxCharacter = 1;//now is 2, when we have more character...add the num.


    // Start is called before the first frame update
    void Start()
    {
        panel.SetActive(false);

        choiceCharacter.GetComponent<Image>().sprite=characterSprite[0];
        explainChoiceButton.GetComponent<Image>().sprite = characterExplain[0];

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //leftArea
    public void OnClickLeftArea()
    {
        if (_nowChracter == 0)
            _nowChracter = _maxCharacter;
        else
            _nowChracter--;

        choiceCharacter.GetComponent<Image>().sprite = characterSprite[_nowChracter];
        explainImage.GetComponent<Image>().sprite = characterExplain[_nowChracter];
    }

    //rightArea
    public void OnClickRightArea()
    {
        if (_nowChracter == _maxCharacter)
            _nowChracter = 0;
        else
            _nowChracter++;

        choiceCharacter.GetComponent<Image>().sprite = characterSprite[_nowChracter];
        explainImage.GetComponent<Image>().sprite = characterExplain[_nowChracter];
    }

    //explainChoiceButton+choiceCharacterButton
    public void OnClickECB()
    {
        panel.SetActive(true);
    }

    /********** H   E   L   P   ***********/
    public void OnClickYes()
    {
        //HELP ME!!!!!!!
    }

    /*********  H   E   L   P   **********/
    public void OnClickNo()
    {
        panel.SetActive(false);
    }
}
