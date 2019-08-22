using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System;

public class EndingSceneManager : MonoBehaviour
{
	public GameObject endingImage;
	public GameObject endingText;
	public GameObject endingScriptImage;
	public GameObject endingScriptText;
	public GameObject endingButton;

	public Sprite[] endingImageSprite = new Sprite[8];
	public Sprite[] endingScriptSprite = new Sprite[8];

    public float[] score=new float[5];
    private int totalP;
    private int totalF;

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < 5; i++)
        {
            SetGradeCredit(GameManager.Inst.studyResultArray[i], i, GameManager.Inst.studyResultArray[i].Favor);
            Debug.Log("과목" + i + ":     " + score[i]);
        }
        EndCheck();
    }

    public void OnclickGoHome()
	{
		SceneManager.LoadScene(7);
	}

    void GoEnding(int endingNum)
	{
		SetSprite(endingNum);
		switch (endingNum)
		{
			case 0:
                endingText.GetComponent<Text>().text = "평범한 대학생";
				break;
			case 1:
                endingText.GetComponent<Text>().text = "해답은 하나 뿐";
				endingScriptText.GetComponent<Text>().text = "군대런";
				break;
            case 2:
                endingText.GetComponent<Text>().text = "나의 길을 찾아..";
				endingScriptText.GetComponent<Text>().text = "재수또는 전과";
				break;
			case 3:
                endingText.GetComponent<Text>().text = "이왕 파는 우물 제대로 파자";
				endingScriptText.GetComponent<Text>().text = "랩 인턴";
				break;
			case 4:
                endingText.GetComponent<Text>().text = "의외의 재능";
				endingScriptText.GetComponent<Text>().text = "체육계 스카웃";
				break;
			case 5:
                endingText.GetComponent<Text>().text = "갑작스러운 데뷔";
				endingScriptText.GetComponent<Text>().text = "연예인 데뷔";
				break;
			case 6:
					endingText.GetComponent<Text>().text = "뭐든 과하면 독";
					endingScriptText.GetComponent<Text>().text = "실려감";
					break;
			case 7:
                endingText.GetComponent<Text>().text = "이게 4차 산업혁명이지";
				endingScriptText.GetComponent<Text>().text = "유튜버 데뷔";
				break;

		}
	}

    void SetSprite(int num)
    {
        endingImage.GetComponent<Image>().sprite = endingImageSprite[num];
        endingScriptImage.GetComponent<Image>().sprite = endingScriptSprite[num];
    }

    void EndCheck()
    {
       if (GameManager.Inst.isEndingSix == true)
		{
			GoEnding(6);
			Debug.Log("66666");
		}
        else if (totalP >= 3)
            GoEnding(4);
        else if (totalF >= 2)
            GoEnding(1);
        else
        {
            int num = UnityEngine.Random.Range(0, 100);
            if (num <= 5)
                GoEnding(7);
            else
                GoEnding(0);
        }
    }

    
    public void SetGradeCredit(Study study, int num, int _favor)
    {
        if (study.studyType == Type.Major)
            switch (study.grade)
            {
                case "S":
                    if (_favor >= 75)
                        score[num] = 4.5f;
                    else if (_favor < 75 && _favor >= 35)
                        score[num] = 3.5f;
                    else if (_favor < 35 && _favor > 0)
                        score[num] = 2f;
                    else
                    {
                        totalF++;
                        score[num] = 0f;
                    }
                    break;

                case "A":
                    if (_favor >= 80)
                        score[num] = 4.5f;
                    else if (_favor < 80 && _favor >= 40)
                        score[num] = 3.5f;
                    else if (_favor < 40 && _favor >= 25)
                        score[num] = 2f;
                    else
                    {
                        totalF++;
                        score[num] = 0f;
                    }
                    break;

                case "B":
                    if (_favor >= 85)
                        score[num] = 4.5f;
                    else if (_favor < 85 && _favor >= 45)
                        score[num] = 3.5f;
                    else if (_favor < 45 && _favor >= 25)
                        score[num] = 2f;
                    else
                    {
                        totalF++;
                        score[num] = 0f;
                    }
                    break;

                case "C":
                    if (_favor >= 85)
                        score[num] = 4.5f;
                    else if (_favor < 85 && _favor >= 50)
                        score[num] = 3.5f;
                    else if (_favor < 50 && _favor >= 30)
                        score[num] = 2f;
                    else
                    {
                        totalF++;
                        score[num] = 0f;
                    }
                    break;
            }

        else if (study.studyType == Type.Sport)
            switch (study.grade)
            {
                case "S":
                    if (_favor >= 25)
                        totalP++;
                    else
                    {
                        totalF++;
                        score[num] = 0f;
                    }
                    break;

                case "A":
                    if (_favor >= 27)
                        totalP++;
                    else
                    {
                        totalF++;
                        score[num] = 0f;
                    }
                    break;

                case "B":
                    if (_favor >= 30)
                        totalP++;
                    else
                    {
                        totalF++;
                        score[num] = 0f;
                    }
                    break;

                case "C":
                    if (_favor >= 32)
                        totalP++;
                    else
                    {
                        totalF++;
                        score[num] = 0f;
                    }
                    break;
            }

        else if (study.studyType == Type.Discuss)
            switch (study.grade)
            {
                case "S":
                    if (_favor >= 70)
                        score[num] = 4.5f;
                    else if (_favor < 70 && _favor >= 30)
                        score[num] = 3.5f;
                    else if (_favor < 30 && _favor > 0)
                        score[num] = 2f;
                    else
                    {
                        totalF++;
                        score[num] = 0f;
                    }
                    break;

                case "A":
                    if (_favor >= 75)
                        score[num] = 4.5f;
                    else if (_favor < 75 && _favor >= 35)
                        score[num] = 3.5f;
                    else if (_favor < 35 && _favor >= 20)
                        score[num] = 2f;
                    else
                    {
                        totalF++;
                        score[num] = 0f;
                    }
                    break;

                case "B":
                    if (_favor >= 85)
                        score[num] = 4.5f;
                    else if (_favor < 85 && _favor >= 45)
                        score[num] = 3.5f;
                    else if (_favor < 45 && _favor >= 20)
                        score[num] = 2f;
                    else
                    {
                        totalF++;
                        score[num] = 0f;
                    }
                    break;

                case "C":
                    if (_favor >= 85)
                        score[num] = 4.5f;
                    else if (_favor < 85 && _favor >= 45)
                        score[num] = 3.5f;
                    else if (_favor < 45 && _favor >= 20)
                        score[num] = 2f;
                    else
                    {
                        totalF++;
                        score[num] = 0f;
                    }
                    break;
            }
    }
}
