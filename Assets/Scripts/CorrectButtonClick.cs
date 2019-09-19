using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CorrectButtonClick : MiniGame
{
    public List<Image> imageArrowList;
    public List<Sprite> spriteArrowCandidate;

    public int score = 0;

    private int[] _randomInts = new int[6];

    private int _tryNumber = 0;
    private bool _trySucceeded = true;
    private int _currentButtonCount = 0;

    // Start is called before the first frame update
    void Start()
    {
        Shuffle();
    }

    // Update is called once per frame
    void Update()
    {
        if (_currentButtonCount >= 6)
        {
            if (_trySucceeded)
                score++;

            _tryNumber++;

            if (_tryNumber >= 6)
            {
                int result = 0;

                if (score >= 5)
                {
                    result = 0;
                }
                else if (score >= 3)
                {
                    result = 1;
                }
                else
                {
                    result = 2;
                }

                EndMinigame(result);
            }
            
            _currentButtonCount = 0;
            _trySucceeded = true;

            Shuffle();
        }
    }

    public void Shuffle()
    {
        for (int i = 0; i < 6; i++)
        {
            _randomInts[i] = Random.Range(0, 5);
            imageArrowList[i].sprite = spriteArrowCandidate[_randomInts[i]];
        }
    }

    public void OnButtonClick(int index)
    {
        if (_randomInts[_currentButtonCount] != index)
            _trySucceeded = false;

        _currentButtonCount++;
    }
}
