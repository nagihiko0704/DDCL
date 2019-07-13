using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LectureChoiceGameManager : MonoBehaviour
{
    //TODO: change lecture button's background and text
    //      save scores in _lectureChoiceSocre array


    //3. implement time limit with using TIME_LIMIT
    //3-1. note that if time limit is over, score must be stored as 1
    //5. then change to lecture apllication scene

    //set each button.
    public GameObject[] buttonLectures = new GameObject[4];

    //background image for lecture buttons
    public Sprite[] spriteLectureButtonBackground = new Sprite[4];

    //array element value is decending order of goodness
    //value range: 0-3
    //if array elemnt value is 2, it is 3rd best choice
    private int[] _goodLectureOrder = new int[4];

    //for choice count
    //if lecture choiced, _choiceNum++
    //choiceNumNow to check the _choiceNum change
    private int _choiceNum = 0;
    private int choiceNumNow = 0;

    private const float TIME_LIMIT = 4;
    private float limitTime=TIME_LIMIT;

    private readonly int[] SCORE = { 10, 7, 4, 1 };

    // Start is called before the first frame update
    void Start()
    {
        LectureChoiceGame();
    }

    // Update is called once per frame
    void Update()
    {
		//timer
		float time = Time.deltaTime;
		limitTime -= time;

        //To make sure you made your choice in time.
		if (limitTime <= 0)
		{
			if (_choiceNum == choiceNumNow)
			{
				GameManager.lectureChoiceScore[_choiceNum] = 1;
				limitTime = TIME_LIMIT;
				Debug.Log(1);
				_choiceNum++;
			}
		}

        //if u play the game 5 times, change to application scene.
		if (_choiceNum == 5)
        {
            SceneManager.LoadScene(2);
            //Destroy(this.gameObject);
        }

		//if u already made ur choice, do LectureChoiceGame() again.
		if (_choiceNum == choiceNumNow + 1)
        {
            LectureChoiceGame();
            choiceNumNow++;
        }
        
    }

    //set lecture order by goodness
    //apply ui
    private void LectureChoiceGame()
    {
        for(int i = 0; i < 4; i++)
        {
            _goodLectureOrder[i] = i;
        }

        Shuffle(_goodLectureOrder);
        //Debug.Log(_goodLectureOrder[0]+"    "+_goodLectureOrder[1]+"    "+_goodLectureOrder[2]+"    "+_goodLectureOrder[3]);
        for (int i = 0; i < 4; i++)
        {
            int x=_goodLectureOrder[i];
            buttonLectures[i].GetComponent<Image>().sprite = spriteLectureButtonBackground[x];
        }
    }

    //shuffles elements in array
    private void Shuffle(int[] array)
    {
        int n = array.Count();

        while (n > 1)
        {
            n--;
            int i = Random.Range(0, n + 1);
            int temp = array[i];
            array[i] = array[n];
            array[n] = temp;
        }
    }

    public void OnLecture0ButtonClicked()
    {
        //sample
        int goodOrder = _goodLectureOrder[0];
        GameManager.lectureChoiceScore[_choiceNum] = SCORE[goodOrder];
        
        Debug.Log(SCORE[goodOrder]);
        _choiceNum++;
    }

    //add this fuction as onClick() in ButtonLecture1 inspector window
    public void OnLecture1ButtonClicked()
    {
        int order1 = _goodLectureOrder[1];
        GameManager.lectureChoiceScore[_choiceNum] = SCORE[order1];
		
        Debug.Log(SCORE[order1]);
        _choiceNum++;
    }

    //add this fuction as onClick() in ButtonLecture2 inspector window
    public void OnLecture2ButtonClicked()
    {
        int order2 = _goodLectureOrder[2];
        GameManager.lectureChoiceScore[_choiceNum] = SCORE[order2];
		
        Debug.Log(SCORE[order2]);
        _choiceNum++;
    }

    //add this fuction as onClick() in ButtonLecture3 inspector window
    public void OnLecture3ButtonClicked()
    {
        int order3 = _goodLectureOrder[3];
        GameManager.lectureChoiceScore[_choiceNum] = SCORE[order3];
		
        Debug.Log(SCORE[order3]);
        _choiceNum++;
    }
}
