using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class NewCharacterManager : MonoBehaviour
{
    public GameObject[] clickArea = new GameObject[2];//0:left 1:right
    public GameObject choiceCharacter;
    public GameObject popUpCharacter;
    /**
     * 0:none
     * 1:freshmen
     **/
    
    public Sprite[] characterSprite = new Sprite[2];
    public Sprite[] characterExplain = new Sprite[2];

    public GameObject explainChoiceButton;
    public GameObject explainImage;

    public GameObject[] canvas = new GameObject[2];

    private int _nowChracter;
    private int _maxCharacter =1;//now is 1, when we have more character...add the num.


    // Start is called before the first frame update
    void Start()
    {
        canvas[0].SetActive(true);
        canvas[1].SetActive(false);

        choiceCharacter.GetComponent<Image>().sprite=characterSprite[0];
        explainChoiceButton.GetComponent<Image>().sprite = characterExplain[0];

    }

    // Update is called once per frame
    void Update()
    {
        popUpCharacter.GetComponent<Image>().sprite = characterSprite[_nowChracter];
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
        canvas[0].SetActive(false);
        canvas[1].SetActive(true);
        Debug.Log("넘어간다ㅏㅏ");
    }

    /********** H   E   L   P   ***********/
    public void OnClickYes()
    {
        switch (_nowChracter)
        {
            case 0:
                Debug.Log("ㅈㅅ 이거 임시라 걍 봐줘요^^");
                canvas[0].SetActive(true);
                canvas[1].SetActive(false);
                break;
            case 1:
                Debug.Log("새내기");
                GameManager.Inst.player.playerCharacter =new Newbie();
                SceneManager.LoadScene(1);
                break;
        }
    }

    /*********  H   E   L   P   **********/
    public void OnClickNo()
    {
        canvas[0].SetActive(true);
        canvas[1].SetActive(false);
        Debug.Log("돌아간다 ㅂㅅ아");
    }
}


