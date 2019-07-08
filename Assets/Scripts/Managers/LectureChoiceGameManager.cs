using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class LectureChoiceGameManager : MonoBehaviour
{
    //TODO: change lecture button's background and text
    //      save scores in _lectureChoiceSocre array
    //
    //1. apply background and text on each lecture button
    //1-1. using spriteLectureButtonBackground for background
    //2. add onClick() function at each lecture button inspector window
    //2-1. see ButtonLecture0 object in scene if you don't know
    //3. implement time limit with using TIME_LIMIT
    //3-1. note that if time limit is over, score must be stored as 1
    //4. make LectureChoiceGame() played 5 times
    //4-1. each score should be saved in lectureChoiceScore which is GameManager's variable
    //5. then change to lecture apllication scene
    //6. **if all goes right, delete annotations**
    //7. **add your own annotaiton about variables and methods**
    //
    //you can change, add, or delete variables and methods
    //if you have any question please feel free to ask me any time


    //z - shape order
    //buttonLectures[0] -> ButtonLecture0
    //buttonLectures[1] -> ButtonLecutre1
    //buttonLectures[2] -> ButtonLecutre2              
    //buttonLectures[3] -> ButtonLecutre3
    public GameObject[] buttonLectures = new GameObject[4];

    //background image for lecture buttons
    //ordered by degree of goodness
    //check LectureChoiceGameManager inspector window
    public Sprite[] spriteLectureButtonBackground = new Sprite[4];

    //array element value is decending order of goodness
    //value range: 0-3
    //if array elemnt value is 2, it is 3rd best choice
    private int[] _goodLectureOrder = new int[4];

    //for choice count
    //if lecture choiced, _choiceNum++
    private int _choiceNum = 0;

    private const float TIME_LIMIT = 4f;
    private readonly int[] SCORE = { 10, 7, 4, 1 };

    // Start is called before the first frame update
    void Start()
    {
   
    }

    // Update is called once per frame
    void Update()
    {
        
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
        for (int i = 0; i < 4; i++)
        {
            Debug.Log(_goodLectureOrder[i]);
        }

        //apply background and text for each lecture button
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
        GameManager.Inst.lectureChoiceScore[_choiceNum] = SCORE[goodOrder];
        _choiceNum++;
    }

    //add this fuction as onClick() in ButtonLecture1 inspector window
    public void OnLecture1ButtonClicked()
    {

    }

    //add this fuction as onClick() in ButtonLecture2 inspector window
    public void OnLecture2ButtonClicked()
    {

    }

    //add this fuction as onClick() in ButtonLecture3 inspector window
    public void OnLecture3ButtonClicked()
    {

    }
}
