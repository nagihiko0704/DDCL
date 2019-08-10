using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LectureChoiceGameManager : MonoBehaviour
{
    
    public GameObject[] buttonLectures = new GameObject[4];
    public Sprite[] manResoure = new Sprite[3];//0 is non, 1 is happy, 2 is angry
    public GameObject[] happyAndAngry = new GameObject[13];

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

    private int[] _happyEach = new int[4];


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
            _happyEach[i] = Random.Range(0, 13);
        }

        for(int i = 0; i < _happyEach.Length - 1; i++)
        {
            for(int j = i + 1; j < _happyEach.Length; j++)
            {
                int temp;
                if (_happyEach[i] > _happyEach[j])
                {
                    temp = _happyEach[i];
                    _happyEach[i] = _happyEach[j];
                    _happyEach[j] = temp;
                }
            }
        }//sort _happyEach
        

        Shuffle(_goodLectureOrder);
        for (int i = 0; i < 4; i++)
        {
            int x=_goodLectureOrder[i];
            setLectureChoiceMan(_happyEach[x],x);
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

    void setLectureChoiceMan(int happyMan,int goodLecture) {
        int totalMan;
        int angryMan;
        int noMan;
        int[] tempList = new int[13];
        

        //set the amount of people
        if (happyMan >= 8)
            totalMan = Random.Range(happyMan, 13);
        else
            totalMan = Random.Range(8, 13);

        //set the amout of angry people and non-people place
        noMan = 13 - totalMan;
        angryMan = totalMan - happyMan;

        //make a array[13], value is 0, 1, or 2.
        //non -people=>0, happy=>1, angry=>2
        for(int i = 0; i < noMan; i++){
            tempList[i] = 0;
        }
        for(int i=noMan; i < noMan + happyMan; i++)
        {
            tempList[i] = 1;
        }
        for(int i = noMan + happyMan; i < noMan + happyMan + angryMan; i++)
        {
            tempList[i] = 2;
        }

        //mix the array
        for(int i=0; i < 13; i++)
        {
            int temp=tempList[i];
            int randomOne = Random.Range(0, 13);

            tempList[i] = tempList[randomOne];
            tempList[randomOne] = temp;
        }

        //set the sprite
        for(int i = 0; i < 13; i++)
        {
            switch(tempList[i]){
                case 0:
                    happyAndAngry[i].GetComponent<Image>().sprite = manResoure[0];
                    break;
                case 1:
                    happyAndAngry[i].GetComponent<Image>().sprite = manResoure[1];
                    break;
                case 2:
                    happyAndAngry[i].GetComponent<Image>().sprite = manResoure[2];
                    break;
            }
        }

    }
}
