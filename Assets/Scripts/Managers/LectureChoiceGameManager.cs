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

    public GameObject[] haa0 = new GameObject[13];
    public GameObject[] haa1 = new GameObject[13];
    public GameObject[] haa2 = new GameObject[13];
    public GameObject[] haa3 = new GameObject[13];


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
    private float limitTime = TIME_LIMIT;

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
        for (int i = 0; i < 4; i++)
        {
            _goodLectureOrder[i] = i;
        }

        SetHappy(_happyEach);

        Shuffle(_goodLectureOrder, _happyEach);

        for (int i = 0; i < 4; i++)
        {
            int x = _goodLectureOrder[i];
            SetLectureChoiceMan(_happyEach[i],i);
        }
    }

    //shuffles elements in array
    private void Shuffle(int[] array1, int[] array2)
    {
        int n = 4;

        while (n > 1)
        {
            n--;
            int i = Random.Range(0, n + 1);

            int temp = array1[i];
            array1[i] = array1[n];
            array1[n] = temp;

            temp = array2[i];
            array2[i] = array2[n];
            array2[n] = temp;
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

    //set the happy and angry man for the input lecture order.
    void SetLectureChoiceMan(int happyMan, int goodLecture)
    {
        int totalMan;
        int noMan;
        int[] tempList = new int[13];


        //set the amount of people
        if (happyMan > 8)
            totalMan = Random.Range(happyMan, 13);
        else
            totalMan = Random.Range(8, 13);

        //set the amout of angry people and non-people place
        noMan = 13 - totalMan;

        //make a array[13], value is 0, 1, or 2.
        //non -people=>0, happy=>1, angry=>2
        int count = 0;
        for (;count<noMan;count++)
        {
            tempList[count] = 0;
        }
        for (; count < noMan + happyMan; count++)
        {
            tempList[count] = 1;
        }
        for (; count < 13; count++)
        {
            tempList[count] = 2;
        }

        //mix the array
        for (int i = 0; i < 13; i++)
        {
            Swap(i, Random.Range(0,13), tempList);
        }

        //set the sprite
        for (int i = 0; i < 13; i++)
        {
            switch (tempList[i])
            {
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

        //apply to each button
        switch (goodLecture)
        {
            case 0:
                for (int i = 0; i < 13; i++)
                    haa0[i].GetComponent<Image>().sprite = happyAndAngry[i].GetComponent<Image>().sprite;
                break;
            case 1:
                for (int i = 0; i < 13; i++)
                    haa1[i].GetComponent<Image>().sprite = happyAndAngry[i].GetComponent<Image>().sprite;
                break;
            case 2:
                for (int i = 0; i < 13; i++)
                    haa2[i].GetComponent<Image>().sprite = happyAndAngry[i].GetComponent<Image>().sprite;
                break;
            case 3:
                for (int i = 0; i < 13; i++)
                    haa3[i].GetComponent<Image>().sprite = happyAndAngry[i].GetComponent<Image>().sprite;
                break;
        }

    }

    //swap two element.
    void Swap(int one, int two, int[] arr)
    {
        int temp = arr[one];
        arr[one] = arr[two];
        arr[two] = temp;
    }

    //set number of happyman for each order.
    //choice 4 number, and sort them to descending order.	
    void SetHappy(int[] arr)
    {
        //choic 4 number.
        for (int i = 0; i < arr.Length; i++)
        {
            int num = Random.Range(0, 13);
            while (arr.Contains(num))
            {
                num = Random.Range(0, 13);
            }
            arr[i] = num;
        }

        //sort
        for(int i = 0; i < arr.Length - 1; i++)
        {
            for(int j=i+1; j < arr.Length; j++)
            {
                if (i < j)
                {
                    int temp = i;
                    i = j;
                    j = temp;
                }
            }
        }
    }
}
    