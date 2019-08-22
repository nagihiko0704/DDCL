using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System;

public class EndingSceneManager : MonoBehaviour
{
	public Image endingImage;
	public Text endingText;
	public Image endingScriptImage;
	public Text endingScriptText;
	public GameObject endingButton;

	public Sprite[] endingImageSprite = new Sprite[8];
	public Sprite[] endingScriptSprite = new Sprite[8];

    private int endingNum=PlayerPrefs.GetInt("ending");

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        runEnding(endingNum);
    }

    public void OnclickGoHome()
	{
		SceneManager.LoadScene(7);
	}

    public void runEnding(int endingNum)
	{
		switch (endingNum)
		{
			case 0:
				endingImage.GetComponent<Image>().sprite = endingImageSprite[endingNum];
				endingScriptImage.GetComponent<Image>().sprite = endingScriptSprite[endingNum];
				endingText.GetComponent<Text>().text = "평범한 대학생";
				break;
			case 1:
				endingImage.GetComponent<Image>().sprite = endingImageSprite[endingNum];
				endingScriptImage.GetComponent<Image>().sprite = endingScriptSprite[endingNum];
				endingText.GetComponent<Text>().text = "해답은 하나 뿐";
				endingScriptText.GetComponent<Text>().text = "군대런";
				break;
            case 2:
				endingImage.GetComponent<Image>().sprite = endingImageSprite[endingNum];
				endingScriptImage.GetComponent<Image>().sprite = endingScriptSprite[endingNum];
				endingText.GetComponent<Text>().text = "나의 길을 찾아..";
				endingScriptText.GetComponent<Text>().text = "재수또는 전과";
				break;
			case 3:
				endingImage.GetComponent<Image>().sprite = endingImageSprite[endingNum];
				endingScriptImage.GetComponent<Image>().sprite = endingScriptSprite[endingNum];
				endingText.GetComponent<Text>().text = "이왕 파는 우물 제대로 파자";
				endingScriptText.GetComponent<Text>().text = "랩 인턴";
				break;
			case 4:
				endingImage.GetComponent<Image>().sprite = endingImageSprite[endingNum];
				endingScriptImage.GetComponent<Image>().sprite = endingScriptSprite[endingNum];
				endingText.GetComponent<Text>().text = "의외의 재능";
				endingScriptText.GetComponent<Text>().text = "체육계 스카웃";
				break;
			case 5:
				endingImage.GetComponent<Image>().sprite = endingImageSprite[endingNum];
				endingScriptImage.GetComponent<Image>().sprite = endingScriptSprite[endingNum];
				endingText.GetComponent<Text>().text = "갑작스러운 데뷔";
				endingScriptText.GetComponent<Text>().text = "연예인 데뷔";
				break;
			case 6:
				endingImage.GetComponent<Image>().sprite = endingImageSprite[6];
				endingScriptImage.GetComponent<Image>().sprite = endingScriptSprite[6];
				endingText.GetComponent<Text>().text = "뭐든 과하면 독";
				endingScriptText.GetComponent<Text>().text = "실려감";
				break;
			case 7:
				endingImage.GetComponent<Image>().sprite = endingImageSprite[endingNum];
				endingScriptImage.GetComponent<Image>().sprite = endingScriptSprite[endingNum];
				endingText.GetComponent<Text>().text = "이게 4차 산업혁명이지";
				endingScriptText.GetComponent<Text>().text = "유튜버 데뷔";
				break;

		}
	}
}
