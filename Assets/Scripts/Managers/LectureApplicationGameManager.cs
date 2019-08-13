﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LectureApplicationGameManager : MonoBehaviour
{
    public Button buttonApplication;
    public Image fire;
    public Sprite[] fireSprite = new Sprite[4];

    public const int GAME_TIME = 2;
    public float countTime = GAME_TIME;
    public int lectureCount;

    private int _clickCount;
    private int applicationScore;
    private int _amountOfClick;

    // Start is called before the first frame update
    void Start()
    {
        
        buttonApplication.onClick.AddListener(AddApplicationCount);

    }

    // Update is called once per frame
    void Update()
    {
        float time = Time.deltaTime;
        countTime -= time;

        if (countTime <= 0)
        {
            ApplicationEnd(lectureCount);
        }

        if (lectureCount == 5)
        {
            SceneManager.LoadScene(3);
        }

        ChangeSpriteFire(_amountOfClick);
            
    }

    private void AddApplicationCount()
    {
        _clickCount++;
        _amountOfClick++;
    }
    


    private void ApplicationEnd(int lecture)
    {
        //if game time is over, go lecture result scene
        //and save score in GameManage
        if (_clickCount >= 23)
            applicationScore = 10;
        else if (_clickCount >=19&&_clickCount<23)
            applicationScore = 7;
        else if (_clickCount >= 15&&_clickCount<19)
            applicationScore = 4;
        else
            applicationScore = 1;

        Debug.Log(lecture+" "+_clickCount+" "+applicationScore);

        
        GameManager.lectureApplicationScore[lecture] = applicationScore;

        lectureCount++;
        countTime = 2;
        _clickCount = 0;
    }

    private void ChangeSpriteFire(int count)
    {
        int num = count / 19;

        switch (num)
        {
            case 0:
                fire.GetComponent<Image>().sprite = fireSprite[0];
                break;
            case 1:
                fire.GetComponent<Image>().sprite = fireSprite[1];
                break;
            case 2:
                fire.GetComponent<Image>().sprite = fireSprite[2];
                break;
            default:
                fire.GetComponent<Image>().sprite = fireSprite[3];
                break;
        }
    }
}
 